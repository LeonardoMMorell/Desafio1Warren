using AppServices;
using DomainModels;
using DomainServices.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DesafioWarren.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomersController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return SafeAction(() =>
            {
                var customers = _customerAppService.GetAll();
                return !customers.Any()
                    ? NotFound("No registered customer found")
                    : Ok(customers);
            }); 
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return SafeAction(() =>
            {
                var IdProtection = _customerAppService.GetById(id);
                return IdProtection is null
                    ? NotFound($"Error 404 // Client not found! for id: {id}")
                    : Ok(IdProtection);
            });
        }

        [HttpGet("getByFullName/{fullname}")]
        public IActionResult GetByFullName(string fullName)
        {
            return SafeAction(() =>
            {
                var FullNameProtection = _customerAppService.GetAllByFullName(fullName);
                return FullNameProtection.Capacity == 0
                    ? NotFound($"Error 404 // Client not found! For FullName: {fullName}")
                    : Ok(FullNameProtection);
            });
        }

        [HttpGet("getByEmail/{email}")]
        public IActionResult GetByEmail(string email)
        {
            return SafeAction(() =>
            {
                var EmailProtection = _customerAppService.GetAllByEmail(email);
                return EmailProtection.Capacity == 0
                    ? NotFound($"Error 404 // Client not found! For Email: {email}")
                    : Ok(EmailProtection);
            });
        }

        [HttpGet("getByCpf/{cpf}")]
        public IActionResult GetByCpf(string cpf)
        {
            return SafeAction(() =>
            {
                var CpfProtection = _customerAppService.GetAllByCpf(cpf);
                return CpfProtection.Capacity == 0
                    ? NotFound($"Error 404 // Client not found! For CPF: {cpf}")
                    : Ok(CpfProtection);
            });
        }

        [HttpPost]
        public IActionResult Post(CustomerDto model)
        {
            return SafeAction(() => 
            {
                var id = _customerAppService.Add(model);
                return Created("~api/customer", "Your registration was successfully created, ID: " + id);
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, CustomerDto customerDto)
        {
            return SafeAction(() =>
            {
                return !_customerAppService.Update(id, customerDto)
                    ? NotFound()
                    : Ok(customerDto);
            });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return SafeAction(() =>
            {
                return !_customerAppService.DeleteCustomer(id)
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