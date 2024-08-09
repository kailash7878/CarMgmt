using CarMgmt.Models;

namespace CarMgmt.Intereface
{
    public interface ICar
    {
        CarResponseModel Create();
        CarResponseModel Update();
        bool ActiveInActive();
        List<CarResponseModel> ListCar();
        CarResponseModel GetById (int id);
    }
}
