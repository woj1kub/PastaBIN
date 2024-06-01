using BLL.DTO;
using BLL.Interface;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Text;

namespace BLL_EF
{
    public class PastaImgService : IPastaImg
    {
        private readonly PastaBINContext context;

        public PastaImgService(PastaBINContext context)
        {
            this.context = context;
        }

        public string AddImgPasta(int? CookID, PastaImageRequest pastaImageRequest)
        {
            if (pastaImageRequest == null || pastaImageRequest.Image == null || pastaImageRequest.DeleteDate == null)
                return "";

            string globalKey;
            do
            {
                globalKey = KeyGenerator.GenerateKey();
            } while (context.PastaBinds.Any(p => p.GlobalKey == globalKey));

            PastaBind pastaBind = new PastaBind()
            {
                GlobalKey = globalKey,
                CookID = CookID!=0 ? CookID : null,
            };
            context.PastaBinds.Add(pastaBind);
            context.SaveChanges();
            string image = pastaImageRequest.Image;
            string[] parts = image.Split(',');
            int[] numbers = Array.ConvertAll(parts, int.Parse);
            byte[] byteArray = new byte[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0 || numbers[i] > 255)
                {
                    throw new ArgumentException("Liczba nie mieści się w zakresie bajtów (0-255)");
                }

                byteArray[i] = (byte)numbers[i];
            }


            context.PastaImages.Add(new PastaImage()
            {
                CreateDate = DateTime.Now,
                DeleteDate = pastaImageRequest.DeleteDate,
                PastaBindID = pastaBind.PastaBindID,
                ImageData = byteArray,
                IsActive = true
            });

            context.SaveChanges();

            return globalKey;
        }

        public PastaImageResponse GetPastaImgByKey(string key, int CookID)
        {
            var pasta = context.PastaBinds
                .Include(p => p.Image)
                .SingleOrDefault(p => p.GlobalKey == key);

            if (pasta != null)
            {
                if (pasta.Image == null)
                {
                    throw new KeyNotFoundException("Pasta o takim kluczu nie istnieje.");
                }

                if (pasta.CookID != CookID)
                {
                    context.PastaHistories.Add(new PastaHistory()
                    {
                        CookID = CookID,
                        VisitDate = DateTime.Now,
                        PastaBindID = pasta.PastaBindID
                    });
                    context.SaveChanges();
                }

                return new PastaImageResponse()
                {
                    IDBind = pasta.PastaBindID,
                    Image = pasta.Image.ImageData,
                    Key = key
                };
            }

            var pastaGroup = context.PastaGroupSharing
                .Include(pg => pg.PastaBind)
                .ThenInclude(pb => pb.Image)
                .SingleOrDefault(pg => pg.GroupKey == key);

            if (pastaGroup == null || pastaGroup.PastaBind == null || pastaGroup.PastaBind.Image == null)
            {
                throw new KeyNotFoundException("Pasta o takim kluczu nie istnieje.");
            }

            pasta = pastaGroup.PastaBind;

            if (pasta.CookID != CookID)
            {
                context.PastaHistories.Add(new PastaHistory()
                {
                    CookID = CookID,
                    VisitDate = DateTime.Now,
                    PastaBindID = pasta.PastaBindID
                });
                context.SaveChanges();
            }

            return new PastaImageResponse()
            {
                IDBind = pasta.PastaBindID,
                Image = pasta.Image.ImageData,
                Key = key
            };
        }

        public IEnumerable<PastaImageResponse> GetPastaImgByUser(int CookID)
        {
            var cook = context.Cooks
                .Include(c => c.PastaBinds)
                .ThenInclude(pb => pb.Image)
                .SingleOrDefault(c => c.CookID == CookID);

            if (cook == null)
            {
                throw new KeyNotFoundException("Cook o podanym ID nie istnieje.");
            }

            if (!cook.PastaBinds.Any())
            {
                throw new Exception("Cook nie ma powiązanych PastaBinds.");
            }

            var imageResponses = new List<PastaImageResponse>();

            foreach (var item in cook.PastaBinds)
            {
                if (item.Image != null)
                {
                    imageResponses.Add(new PastaImageResponse()
                    {
                        Image = item.Image.ImageData,
                        IDBind = item.PastaBindID,
                        DeleteDate = item.Image.DeleteDate,
                        CreationDate = item.Image.CreateDate,
                        Key = item.GlobalKey
                    });
                }
            }
            return imageResponses;
        }
    }

}
