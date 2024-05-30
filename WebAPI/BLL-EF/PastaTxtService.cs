using BLL.DTO;
using BLL.Interface;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;

namespace BLL_EF
{
    public class PastaTxtService : IPastaTxt
    {
        private readonly PastaBINContext context;

        public PastaTxtService(PastaBINContext context)
        {
            this.context = context;
        }

        public string AddTxtPasta(PastaTextRequest pastaTextRequest)
        {
            if (pastaTextRequest == null || string.IsNullOrEmpty(pastaTextRequest.Content))
                return "";

            string globalKey;
            do
            {
                globalKey = KeyGenerator.GenerateKey();
            } while (context.PastaBinds.Any(p => p.GlobalKey == globalKey));

            PastaBind pastaBind = new PastaBind()
            {
                GlobalKey = globalKey
            };
            context.PastaBinds.Add(pastaBind);

            context.PastaText.Add(new PastaTxt()
            {
                CreateDate = DateTime.Now,
                DeleteDate = pastaTextRequest.DeleteDate,
                PastaBindID = pastaBind.PastaBindID,
                Content = pastaTextRequest.Content,
                IsActive = true
            });

            context.SaveChanges();

            return globalKey;
        }

        public PastaTextResponse GetPastaTxtByKey(string key, int CookID)
        {
            var pasta = context.PastaBinds
                .Include(p => p.Txt)
                .SingleOrDefault(p => p.GlobalKey == key);

            if (pasta != null)
            {
                if (pasta.Txt == null)
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

                return new PastaTextResponse()
                {
                    IDBind = pasta.PastaBindID,
                    Content = pasta.Txt.Content,
                    Key = key
                };
            }

            var pastaGroup = context.PastaGroupSharing
                .Include(pg => pg.PastaBind)
                .ThenInclude(pb => pb.Txt)
                .SingleOrDefault(pg => pg.GroupKey == key);

            if (pastaGroup == null || pastaGroup.PastaBind == null || pastaGroup.PastaBind.Txt == null)
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

            return new PastaTextResponse()
            {
                IDBind = pasta.PastaBindID,
                Content = pasta.Txt.Content,
                Key = key
            };
        }

        public IEnumerable<PastaTextResponse> GetPastaTxtByUser(int CookID)
        {
            var cook = context.Cooks
                .Include(c => c.PastaBinds)
                .ThenInclude(pb => pb.Txt)
                .SingleOrDefault(c => c.CookID == CookID);

            if (cook == null)
            {
                throw new KeyNotFoundException("Cook o podanym ID nie istnieje.");
            }

            if (!cook.PastaBinds.Any())
            {
                throw new Exception("Cook nie ma powiązanych PastaBinds.");
            }

            var textResponses = new List<PastaTextResponse>();

            foreach (var item in cook.PastaBinds)
            {
                if (item.Txt != null)
                {
                    textResponses.Add(new PastaTextResponse()
                    {
                        Content = item.Txt.Content,
                        IDBind = item.PastaBindID,
                        DeleteDate = item.Txt.DeleteDate,
                        CreationDate = item.Txt.CreateDate,
                        Key = item.GlobalKey
                    });
                }
            }
            return textResponses;
        }
    }

}
