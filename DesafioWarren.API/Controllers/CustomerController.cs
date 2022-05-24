using AppServices;
using DomainModels;
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
                    ? NotFound()
                    : Ok(customers);
            }); 
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return SafeAction(() =>
            {
                var IdProtection = _customerAppService.GetById(id);
                if (IdProtection is null) return NotFound($"Error 404 // Client not found! for id: {id}");
                return Ok(IdProtection);
            });
        }

        [HttpGet("getByFullName/{fullname}")]
        public IActionResult GetByFullName(string fullName)
        {
            return SafeAction(() =>
            {
                var FullNameProtection = _customerAppService.GetAllByFullName(fullName);
                if (FullNameProtection.Capacity == 0) return NotFound($"Error 404 // Client not found! For FullName: {fullName}");
                return Ok(FullNameProtection);
            });
        }

        [HttpGet("getByEmail/{email}")]
        public IActionResult GetByEmail(string email)
        {
            return SafeAction(() =>
            {
                var EmailProtection = _customerAppService.GetAllByEmail(email);
                if (EmailProtection.Capacity == 0) return NotFound($"Error 404 // Client not found! For Email: {email}");
                return Ok(EmailProtection);
            });
        }

        [HttpGet("getByCpf/{cpf}")]
        public IActionResult GetByCpf(string cpf)
        {
            return SafeAction(() =>
            {
                var CpfProtection = _customerAppService.GetAllByCpf(cpf);
                if (CpfProtection.Capacity == 0) return NotFound($"Error 404 // Client not found! For CPF: {cpf}");
                return Ok(CpfProtection);
            });
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            return SafeAction(() =>
            {
                _customerAppService.Add(customer);
                return Created("~api/customer", "Your registration was successfully created, ID: " + customer.Id);
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer customer)
        {
            return SafeAction(() =>
            {
                _customerAppService.Update(id, customer);
                return Ok(customer);
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return SafeAction(() =>
            {
                _customerAppService.DeleteCustomer(id);
                return NoContent();
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