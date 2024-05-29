using BLL.DTO;

namespace BLL.Interface
{
    public interface ICook
    {
        public void AddUser(CookRequest cookRequest);
        public void UpdateUser(int cookID, CookRequest cookRequest); // można potem przerobić wykorzystując JWT - chyba trochę bezpieczniej, można to zrobić w kontrolerze
        public void DeleteUser(int ID);
    }
}
