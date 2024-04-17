using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;
using Model;

namespace BLL_EF
{
    public class CookService : ICook
    {
        private readonly PastaBINContext _context;

        public CookService(PastaBINContext context)
        {
            _context = context;
        }

        public IEnumerable<CookResponseDTO> GetCooks()
        {
            return _context.Cooks
                .Select(c => new CookResponseDTO
                {
                    ID = c.ID,
                    Login = c.Login,
                    Password = c.Password,
                    Email = c.Email
                }).ToList();
        }

        public CookResponseDTO GetCook(int id)
        {
            var cook = _context.Cooks
                .Where(c => c.ID == id)
                .Select(c => new CookResponseDTO
                {
                    ID = c.ID,
                    Login = c.Login,
                    Password = c.Password,
                    Email = c.Email
                }).FirstOrDefault();

            return cook;
        }

        public void DeleteCook(int id)
        {
            var cook = _context.Cooks.Find(id);
            if (cook != null)
            {
                _context.Cooks.Remove(cook);
                _context.SaveChanges();
            }
        }

        public void PutCook(int id, CookRequestDTO cookRequest)
        {
            var cook = _context.Cooks.Find(id);
            if (cook != null)
            {
                cook.Login = cookRequest.Login;
                cook.Password = cookRequest.Password;
                cook.Email = cookRequest.Email;
                _context.SaveChanges();
            }
        }

        public void PostCook(CookRequestDTO cookRequest)
        {
            var cook = new Cook
            {
                Login = cookRequest.Login,
                Password = cookRequest.Password,
                Email = cookRequest.Email
            };
            _context.Cooks.Add(cook);
            _context.SaveChanges();
        }
    }
}
