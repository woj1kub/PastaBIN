using BLL.DTO;
using BLL.Interface;
using DAL;
using Model;

namespace BLL_EF
{
    public class CookService : ICook
    {
        private readonly PastaBINContext context;

        public CookService(PastaBINContext context)
        {
            this.context = context;
        }

        public bool AddUser(CookRequest cookRequest)
        {
            if (cookRequest == null || string.IsNullOrEmpty(cookRequest.Login) || string.IsNullOrEmpty(cookRequest.Password) || string.IsNullOrEmpty(cookRequest.Email))
                return false;

            if (context.Cooks.Any(c => c.Login == cookRequest.Login))
                return false;

            context.Cooks.Add(new Cook()
            {
                Email = cookRequest.Email,
                Login = cookRequest.Login,
                Password = cookRequest.Password
            });

            context.SaveChanges();
            return true;
        }

        public bool DeleteUser(int ID)
        {
            Cook cook = context.Cooks.SingleOrDefault(c => c.CookID == ID);
            if (cook == null)
                return false;

            context.Cooks.Remove(cook);
            context.SaveChanges();
            return true;
        }

        public bool UpdateUser(int cookID, CookRequestChangePassword cookRequest)
        {
            if (cookRequest == null ||  string.IsNullOrEmpty(cookRequest.Password))
                return false;

            if (context.Cooks.Any(c => c.CookID != cookID))
                return false;

            Cook cook = context.Cooks.SingleOrDefault(c => c.CookID == cookID);
            if (cook == null)
                return false;

            cook.Password = cookRequest.Password;

            context.SaveChanges();
            return true;
        }
    }
}
