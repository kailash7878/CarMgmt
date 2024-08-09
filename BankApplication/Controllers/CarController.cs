using BankApplication.Common;
using CarMgmt.Intereface;
using CarMgmt.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarMgmt.Controllers
{
    public class CarController : BaseController
    {
        private readonly ICar _car;

        public CarController(ICar car)
        {
            _car = car;
        }

        [HttpPost]
        public ActionResult Create(CarRequestModel car)
        {
            return Ok(_car.Create(car));
        }

        [HttpPost]
        public ActionResult Update(CarRequestModel car)
        {
            return Ok(_car.Update(car));
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            return Ok(_car.GetById(id));
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_car.ListCar());
        }

        [HttpPost]
        public ActionResult UploadCarImage(long carId, List<IFormFile> files)
        {
            if (files.Any())
            {
                return Ok(_car.UploadCarImages(carId, files));
            }

            return Ok(new ResponseModel
            {
                IsSuccess = false,
                Data = null,
                message = "Please Select atleadt one Image to Upload"
            });

        }
    }
}
