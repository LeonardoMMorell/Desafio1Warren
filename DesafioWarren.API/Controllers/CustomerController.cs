using AppServices;
using AppServices.Dtos;
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
            _customerAppService = customerAppService ?? throw new ArgumentNullException(nameof(customerAppService));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return SafeAction(() =>
            {
                var customers = _customerAppService.GetAll(null);
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
                    ? NotFound($"Client not found! for id: {id}")
                    : Ok(IdProtection);
            });
        }

        [HttpGet("getByFullName/{fullname}")]
        public IActionResult GetByFullName(string fullName)
        {
            return SafeAction(() =>
            {
                var FullNameProtection = _customerAppService.GetAllByFullName(fullName);
                return FullNameProtection.FirstOrDefault() is null
                    ? NotFound($"Client not found! For FullName: {fullName}")
                    : Ok(FullNameProtection);
            });
        }

        [HttpGet("getByEmail/{email}")]
        public IActionResult GetByEmail(string email)
        {
            return SafeAction(() =>
            {
                var EmailProtection = _customerAppService.GetAllByEmail(email);
                return EmailProtection.FirstOrDefault() is null
                    ? NotFound($"Client not found! For Email: {email}")
                    : Ok(EmailProtection);
            });
        }

        [HttpGet("getByCpf/{cpf}")]
        public IActionResult GetByCpf(string cpf)
        {
            return SafeAction(() =>
            {
                var CpfProtection = _customerAppService.GetAllByCpf(cpf);
                return CpfProtection.FirstOrDefault() is null
                    ? NotFound($"Client not found! For CPF: {cpf}")
                    : Ok(CpfProtection);
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