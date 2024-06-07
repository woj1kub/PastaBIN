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

        public string AddTxtPasta(int? CookID, PastaTextRequest pastaTextRequest)
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
                GlobalKey = globalKey,
                CookID = CookID != 0 ? CookID : null,
            };
            context.PastaBinds.Add(pastaBind);
            context.SaveChanges();
            PastaTxt pastaTxt = new PastaTxt()
            {
                CreateDate = DateTime.Now,
                DeleteDate = pastaTextRequest.DeleteDate,
                PastaBindID = pastaBind.PastaBindID,
                Content = pastaTextRequest.Content,
                IsActive = true
            };
            context.PastaText.Add(pastaTxt);
            context.SaveChanges();
            pastaBind.TxtID=pastaTxt.PastaTxtID;
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
                        CookID = CookID== 0 ? null : CookID,
                        VisitDate = DateTime.Now,
                        PastaBindID = pasta.PastaBindID
                    });
                    context.SaveChanges();
                    return new PastaTextResponse()
                    {
                        IDBind = pasta.PastaBindID,
                        Content = pasta.Txt.Content,
                        Key = key,
                    };
                }

                return new PastaTextResponse()
                {
                    IDBind = pasta.PastaBindID,
                    Content = pasta.Txt.Content,
                    Key = key,
                    CreationDate= pasta.Txt.CreateDate,
                    DeleteDate = pasta.Txt.DeleteDate
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

        public IEnumerable<PastaTextResponse> GetPastaTxtByUserFromSharing(int CookID)
        {
            var pastaSharing = context.PastaSharingSettings
                .Include(pss=>pss.PastaBind)
                    .ThenInclude(pb=>pb.Cook)
                .Include(pss => pss.PastaBind)
                    .ThenInclude(pb=>pb.Txt)
                .Where(pss=>pss.CookID == CookID).ToList();

            if (pastaSharing.Count == 0 || pastaSharing == null)
            {
                throw new Exception("Cook nie ma powiązanych udostępnionych past txt.");
            }

            var textResponses = new List<PastaTextResponse>();

            foreach (var item in pastaSharing)
            {
                if (item.PastaBind.Txt != null)
                {
                    textResponses.Add(new PastaTextResponse()
                    {
                        Content = item.PastaBind.Txt.Content,
                        IDBind = item.PastaBind.PastaBindID,
                        DeleteDate = item.EndSharingDate,
                        CreationDate = item.CreationDate,
                        Key = item.PastaBind.Cook.Login
                    });
                }
            }
            return textResponses;
        }
    }

}
