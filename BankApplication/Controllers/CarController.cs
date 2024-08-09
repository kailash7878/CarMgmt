using CarMgmt.Controllers;
using CarMgmt.Intereface;
using CarMgmt.Models;
using Microsoft.AspNetCore.Http;
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
    }
}
