using BankApplication.Common;
using BankApplication.Data.models;
using BankApplication.Data.Models;
using BankApplication.Intereface;
using BankApplication.Models;

namespace BankApplication.Services
{
    public class AccountService : ICar
    {
        private readonly IGenericRepository<Account> _repository;
        
        public AccountService(IGenericRepository<Account> repository, )
        {
            _repository = repository;
        }
        public ResponseModel Create(CarRequestModel account)
        {
            var errors = new List<string>();
            
            return new ResponseModel
            {
                IsSuccess = true,
                Data = "Success",
                message = "Success"
            };
        }
    }
}
