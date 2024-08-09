using BankApplication.Common;
using CarMgmt.Core;
using CarMgmt.Intereface;
using CarMgmt.Models;
using CarMgmt.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

namespace CarMgmt.Services
{
    public class CarServices : ICar
    {
        private readonly IDataAccessLayer _layer;

        public CarServices(IDataAccessLayer layer)
        {
            _layer = layer;
        }
        public bool ActiveInActive(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseModel Create(CarRequestModel car)
        {
            var errorList = Validate(car);
            if (errorList.Any())
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Data = errorList,
                    message = CarConstant.CommonFailed
                };
            }


            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Brand", car.Brand));
            parameters.Add(new SqlParameter("@Class", car.Class));
            parameters.Add(new SqlParameter("@ModelName", car.ModelName));
            parameters.Add(new SqlParameter("@ModelCode", car.ModelCode));
            parameters.Add(new SqlParameter("@Description", car.Description));
            parameters.Add(new SqlParameter("@Feature", car.Feature));
            parameters.Add(new SqlParameter("@Price", car.Price));
            parameters.Add(new SqlParameter("@DateofManufacturing", car.DateOfManufacturing));
            parameters.Add(new SqlParameter("@Active", true));
            parameters.Add(new SqlParameter("@SortOrder", car.SortOrder));
            _layer.ExecuteNonQuery("CreateCar", parameters);

            return new ResponseModel()
            {
                IsSuccess = false,
                Data = CarConstant.CarAddSuccessfully,
                message = CarConstant.CommonSuccess
            };
        }

        public ResponseModel GetById(int id)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));
            var cardata = _layer.GetData("ListCar", parameters);

            return new ResponseModel()
            {
                IsSuccess = true,
                Data = cardata,
                message = CarConstant.CommonSuccess
            };
        }

        public ResponseModel ListCar()
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", null));
            var cardata = _layer.GetData("ListCar", parameters);

            return new ResponseModel()
            {
                IsSuccess = true,
                Data = cardata,
                message = CarConstant.CommonSuccess
            };
        }

        public ResponseModel Update(CarRequestModel car)
        {
            var errorList = Validate(car);
            if (errorList.Any())
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Data = errorList,
                    message = CarConstant.CommonFailed
                };
            }


            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", car.Id));
            parameters.Add(new SqlParameter("@Brand", car.Brand));
            parameters.Add(new SqlParameter("@Class", car.Class));
            parameters.Add(new SqlParameter("@ModelName", car.ModelName));
            parameters.Add(new SqlParameter("@ModelCode", car.ModelCode));
            parameters.Add(new SqlParameter("@Description", car.Description));
            parameters.Add(new SqlParameter("@Feature", car.Feature));
            parameters.Add(new SqlParameter("@Price", car.Price));
            parameters.Add(new SqlParameter("@DateofManufacturing", car.DateOfManufacturing));
            parameters.Add(new SqlParameter("@Active", true));
            parameters.Add(new SqlParameter("@SortOrder", car.SortOrder));
            _layer.ExecuteNonQuery("UpdateCar", parameters);

            return new ResponseModel()
            {
                IsSuccess = false,
                Data = CarConstant.CarUpdatedSuccessfully,
                message = CarConstant.CommonSuccess
            };
        }

        public ResponseModel UploadCarImages(long carId, List<IFormFile> files)
        {
            foreach (var item in files)
            {
                var parameters = new List<SqlParameter>();;
                parameters.Add(new SqlParameter("@carid", carId));
                parameters.Add(new SqlParameter("@Class", item.FileName));
                _layer.ExecuteNonQuery("InsertCarImage", parameters);
            }

            return new ResponseModel()
            {
                IsSuccess = false,
                Data = CarConstant.CarImageSaveSuccessfully,
                message = CarConstant.CommonSuccess
            };
        }


        private List<string> Validate(CarRequestModel car)
        {
            var error = new List<string>();
            if (string.IsNullOrWhiteSpace(car.Brand))
            {
                error.Add("Please enter car Brand");
            }

            if (string.IsNullOrWhiteSpace(car.Class))
            {
                error.Add("Please enter car Class");
            }

            if (string.IsNullOrWhiteSpace(car.ModelName))
            {
                error.Add("Please enter car Model Name");
            }

            if (string.IsNullOrWhiteSpace(car.ModelCode))
            {
                error.Add("Please enter car Model Code");
            }

            if (string.IsNullOrWhiteSpace(car.Description))
            {
                error.Add("Please enter car Model Description");
            }

            if (string.IsNullOrWhiteSpace(car.Feature))
            {
                error.Add("Please enter car Model Feature");
            }

            if (car.Price == 0)
            {
                error.Add("Please enter car Price Greter then 0");
            }

            if (car.DateOfManufacturing == default)
            {
                error.Add("Please enter date of manufacturing for Car");
            }

            return error;

        }
    }
}
