using DesafioWarren.API.Data;
using DesafioWarren.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioWarren.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices _repository;
        public CustomersController(ICustomerServices repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return SafeAction(() =>
            {
                var IdProtection = _repository.GetAll(x => x.Id.Equals(id));
                if (IdProtection is null) return NotFound($"Error 404 // Client not found! for id: {id}");
                return Ok(IdProtection);
            });
        }

        [HttpGet("getByFullName/{fullname}")]
        public IActionResult GetByFullName(string fullName)
        {
            return SafeAction(() =>
            {
                var FullNameProtection = _repository.GetAll(x => x.FullName == fullName);
                if (FullNameProtection.Capacity == 0) return NotFound($"Error 404 // Client not found! For FullName: {fullName}");
                return Ok(FullNameProtection);
            });
        }

        [HttpGet("getByEmail/{email}")]
        public IActionResult GetByEmail(string email)
        {
            return SafeAction(() =>
            {
                var EmailProtection = _repository.GetAll(x => x.Email == email);
                if (EmailProtection.Capacity == 0) return NotFound($"Error 404 // Client not found! For Email: {email}");
                return Ok(EmailProtection);
            });
        }

        [HttpGet("getByCpf/{cpf}")]
        public IActionResult GetByCpf(string cpf)
        {
            return SafeAction(() =>
            {
                var CpfProtection = _repository.GetAll(x => x.Cpf == cpf);
                if (CpfProtection.Capacity == 0) return NotFound($"Error 404 // Client not found! For CPF: {cpf}");
                return Ok(CpfProtection);
            });
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            return SafeAction(() =>
            {
                _repository.Add(customer);
                return Created("~api/customer", "Your registration was successfully created, ID: " + customer.Id);
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer customer)
        {
            return SafeAction(() =>
            {
                var CustomerPut = _repository.GetSingle(c => c.Id == id);
                if (CustomerPut == null) return NotFound($"Error: 404 // There is no such ID{id} in the list");
                _repository.Update(CustomerPut, customer);
                return Ok(customer);
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, Customer customer)
        {
            return SafeAction(() =>
            {
                var VariableDelete = _repository.GetSingle(c => c.Id == id);
                if (VariableDelete == null) return NotFound($"Error: 404 // This ID{id} is not in the list");
                _repository.DeleteCustomer(VariableDelete);
                return Ok("The customer was successfully deleted");
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