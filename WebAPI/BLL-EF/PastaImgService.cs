using BLL.DTO;
using BLL.Interface;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model;
using System.Net;
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
            PastaImage pastaImage = new PastaImage()
            {
                CreateDate = DateTime.Now,
                DeleteDate = pastaImageRequest.DeleteDate,
                PastaBindID = pastaBind.PastaBindID,
                ImageData = byteArray,
                IsActive = true
            };

            context.PastaImages.Add(pastaImage);

            context.SaveChanges();
            pastaBind.ImgID=pastaImage.ImageID;
            context.SaveChanges();

            return globalKey;
        }

        public async Task<Stream> GetPastaImgByBindID(int BindID)
        {
            var pasta = await context.PastaBinds
            .Include(p => p.Image)
                .SingleOrDefaultAsync(p => p.PastaBindID == BindID);

            if (pasta == null || pasta.Image == null)
            {
                throw new KeyNotFoundException("Pasta o podanym kluczu nie istnieje lub nie ma przypisanego obrazu.");
            }

            return new MemoryStream(pasta.Image.ImageData);
        }

        public async Task<Stream> GetPastaImgByKey(string key, int CookID)
        {
            var pasta = await context.PastaBinds
                .Include(p => p.Image)
                .SingleOrDefaultAsync(p => p.GlobalKey == key);

            if (pasta == null || pasta.Image == null)
            {
                throw new KeyNotFoundException("Pasta o podanym kluczu nie istnieje lub nie ma przypisanego obrazu.");
            }
            var pastaSharing = await context
                .PastaSharingSettings
                .Include(pss => pss.PastaBind)
                .SingleOrDefaultAsync(pss => pss.CookID==CookID && pss.PastaBind.GlobalKey==key);
            // Jeśli użytkownik nie jest właścicielem obrazu lub nie ma jej udostępnionej, zapisz historię
            if (pasta.CookID != CookID || pastaSharing!=null)
            {
                context.PastaHistories.Add(new PastaHistory()
                {
                    CookID = CookID == 0? null : CookID,
                    VisitDate = DateTime.Now,
                    PastaBindID = pasta.PastaBindID
                });
                await context.SaveChangesAsync();
            }

            return new MemoryStream(pasta.Image.ImageData);
        }

        public IEnumerable<PastaImageResponse> GetPastaImgByUser(int CookID)
        {
            Cook cook = context.Cooks
                .Include(c => c.PastaBinds)
                .ThenInclude(pb => pb.Image)
                .SingleOrDefault(c => c.CookID == CookID);

            if (cook == null)
            {
                throw new KeyNotFoundException("Cook o podanym ID nie istnieje.");
            }

            if (!cook.PastaBinds.Any())
            {
               return [];
            }

            var imageResponses = new List<PastaImageResponse>();

            foreach (var item in cook.PastaBinds)
            {
                if (item.Image != null)
                {
                    imageResponses.Add(new PastaImageResponse()
                    {
                        IDBind = item.PastaBindID,
                        DeleteDate = item.Image.DeleteDate,
                        CreationDate = item.Image.CreateDate,
                        Key = item.GlobalKey
                    });
                }
            }
            return imageResponses;
        }

        public IEnumerable<PastaImageResponse> GetPastaImgByUserFromPastaSharing(int CookID)
        {
            var pastaImagesFromSharing = context.PastaSharingSettings
            .Include(pss => pss.PastaBind)
                .ThenInclude(pb => pb.Image)
            .Include(pss => pss.PastaBind)
                .ThenInclude(pb => pb.Cook)
            .Where(pss => pss.CookID == CookID && pss.PastaBind.Image != null) // Added condition for Image not being null
            .ToList();
            if (pastaImagesFromSharing == null)
            {
                throw new KeyNotFoundException("Cook o podanym ID nie udostępniono mu żadnych past.");
            }
            
            var imageResponses = pastaImagesFromSharing
                .Where(item => item.PastaBind?.Image != null)
                .Select(item => new PastaImageResponse
                {
                    IDBind = item.PastaBind.PastaBindID,
                    DeleteDate = item.EndSharingDate,
                    CreationDate = item.CreationDate,
                    Key = item.PastaBind.Cook.Login
                })
                .ToList();

            return imageResponses;
        }

    }

}
