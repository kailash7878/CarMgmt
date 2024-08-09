using BankApplication.Common;
using BankApplication.Models;

namespace BankApplication.Intereface
{
    public interface ICar
    {
        ResponseModel Create(CarRequestModel Car);
        ResponseModel Update(CarRequestModel Car);
        bool ActiveInActive(int id);
        ResponseModel ListCar(int id);
    }
}
