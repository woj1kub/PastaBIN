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
            PastaBind pasta = context.PastaBinds.Single(p => p.PastaBindID == BindID);
            if (pasta == null)
                return false;

            context.PastaBinds.Remove(pasta);
            return true;
        }

        public IEnumerable<PastaHistoryResponse> PastaHistoryByBindID(int BindID)
        {
            var pasta = context.PastaBinds
                .Include(p => p.Histories)
                    .ThenInclude(h => h.Cook)
                .FirstOrDefault(p => p.PastaBindID == BindID);

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
                        CookLogin = h.Cook != null ? h.Cook.Login : "Gość", // Ustawienie "Gość" gdy Login jest null
                        VisitDate = h.VisitDate
                    })
                    .ToList();
            }

            return historyResponses;
        }



    }

}
