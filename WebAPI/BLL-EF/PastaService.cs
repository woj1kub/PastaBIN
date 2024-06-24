using BLL.DTO;
using BLL.Interface;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;

namespace BLL_EF
{
    public class PastaService : IPasta
    {
        PastaBINContext context;

        public PastaService(PastaBINContext context)
        {
            this.context = context;
        }
        public bool DeletePasta(int BindID)
        {
            PastaBind pasta = context.PastaBinds.SingleOrDefault(p => p.PastaBindID == BindID);
            Console.WriteLine(pasta.PastaBindID);
            if (pasta == null)
                return false;

            context.PastaBinds.Remove(pasta);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<PastaHistoryResponse> PastaHistoryByBindID(int BindID)
        {
            var pasta = context.PastaBinds
                .Include(p => p.Histories)
                    .ThenInclude(h => h.Cook)
                .SingleOrDefault(p => p.PastaBindID == BindID);

            if (pasta == null)
            {
                throw new KeyNotFoundException($"Pasta o ID {BindID} nie istnieje");
            }

            var historyResponses = new List<PastaHistoryResponse>();

            if (pasta.Histories != null)
            {
                historyResponses = pasta.Histories
                    .Select(h => new PastaHistoryResponse
                    {
                        CookLogin = h.Cook != null ? h.Cook.Login : "Gość", 
                        VisitDate = h.VisitDate
                    })
                    .ToList();
            }

            return historyResponses;
        }



    }

}
