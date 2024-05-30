using BLL.DTO;

namespace BLL.Interface
{
    public interface ICook
    {
        public bool AddUser(CookRequest cookRequest);
        public bool UpdateUser(int cookID, CookRequest cookRequest); // można potem przerobić wykorzystując JWT - chyba trochę bezpieczniej, można to zrobić w kontrolerze
        public bool DeleteUser(int ID);
    }
}
