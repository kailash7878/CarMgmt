using BankApplication.Common;
using CarMgmt.Models;

namespace CarMgmt.Intereface
{
    public interface ICar
    {
        ResponseModel Create(CarRequestModel car);
        ResponseModel Update(CarRequestModel car);
        bool ActiveInActive(int id);
        ResponseModel ListCar();
        ResponseModel GetById (int id);
    }
}
