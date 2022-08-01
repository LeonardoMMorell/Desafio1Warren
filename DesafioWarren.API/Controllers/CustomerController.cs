using ApplicationModels.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Application.Interfaces;
using System.Linq;
using DomainModels;

namespace DesafioWarren.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomersController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService ?? throw new ArgumentNullException(nameof(customerAppService));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return SafeAction(() =>
            {
                var customers = _customerAppService.GetAll(null);
                return Ok(customers);
            }); 
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return SafeAction(() =>
            {
                return _customerAppService.GetBy(x => x.Id == id) is null
                    ? NotFound($"Client not found! For Id: {id}")
                    : Ok(_customerAppService.GetBy(x => x.Id == id));
            });
        }

        [HttpGet("getByFullName/{fullName}")]
        public IActionResult GetByFullName(string fullName)
        {
            return SafeAction(() =>
            {
                var customer = _customerAppService.GetAllByFullname(fullName);
                return customer.Any()
                    ? Ok(customer)
                    : NotFound($"Client not found! For FullName: {fullName}");
            });
        }

        [HttpGet("getByEmail/{email}")]
        public IActionResult GetByEmail(string email)
        {
            return SafeAction(() =>
            {
                return _customerAppService.GetByEmail(email) is null
                   ? NotFound($"Client not found! For Email: {email}")
                   : Ok(_customerAppService.GetByEmail(email));
            });
        }

        [HttpGet("getByCpf/{cpf}")]
        public IActionResult GetByCpf(string cpf)
        {
            return SafeAction(() =>
            {
                return _customerAppService.GetByCpf(cpf) is null
                   ? NotFound($"Client not found! For Cpf: {cpf}")
                   : Ok(_customerAppService.GetByCpf(cpf));
            });
        }

        [HttpPost]
        public IActionResult Post(CreateCustomerRequest createcustomer)
        {
            return SafeAction(() =>
            {
                var id = _customerAppService.Add(createcustomer);
                return Created("~api/customer", "ID:" + id);
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateCustomerRequest customerUp)
        {
            return SafeAction(() =>
            {
                var updatedCustomer = _customerAppService.Update(id, customerUp);
                return updatedCustomer.validation
                    ? Ok()
                    : NotFound(updatedCustomer.errorMessage);
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return SafeAction(() =>
            {
                return !_customerAppService.Delete(id)
                    ? NotFound()
                    : NoContent();            
            });
        }

        private IActionResult SafeAction(Func<IActionResult> action)
        {
            try
            {
                return action?.Invoke();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}