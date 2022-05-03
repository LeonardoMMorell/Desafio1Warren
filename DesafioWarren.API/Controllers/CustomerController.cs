using DesafioWarren.API.Data;
using DesafioWarren.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DesafioWarren.API.Validators;

namespace DesafioWarren.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase

    {
        public readonly IRepository _repository;
        public CustomerController(IRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.Cadastros);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var cadastro = _repository.Cadastros.FindAll(c => c.Id == id);
            if (cadastro.Capacity == 0) return NotFound("The client was not found");
            return Ok(cadastro);
        }

        [HttpGet("getByfullName/{fullname}")]
        public IActionResult GetByfullname(string fullName)
        {
            var cadastro = _repository.Cadastros.FindAll(c => c.fullName == fullName);
            if (cadastro.Count == 0) return NotFound("The client was not found");
            return Ok(cadastro);
        }

        [HttpGet("getByemail/{email}")]
        public IActionResult GetByemail(string email)
        {
            var cadastro = _repository.Cadastros.FindAll(c => c.email == email);
            if (cadastro.Capacity == 0) return NotFound("The client was not found");
            return Ok(cadastro);
        }


        [HttpGet("getBycpf/{cpf}")]
        public IActionResult GetBycpf(string cpf)
        {
            var cadastro = _repository.Cadastros.FindAll(c => c.cpf == cpf);
            if (cadastro.Capacity == 0) return NotFound("The client was not found");
            return Ok(cadastro);
        }

        [HttpGet("getBycellphone/{cellphone}")]
        public IActionResult GetBycellPhone(string cellphone)
        {
            var cadastro = _repository.Cadastros.FindAll(c => c.cellphone == cellphone);
            if (cadastro.Capacity == 0) return NotFound("The client was not found");
            return Ok(cadastro);
        }

        [HttpGet("getBybirthdate/{birthdate}")]
        public IActionResult GetBybirthdate(DateTime birthdate)
        {
            var cadastro = _repository.Cadastros.FindAll(c => c.birthdate == birthdate);
            if (cadastro.Capacity == 0) return NotFound("The client was not found");
            return Ok(cadastro);
        }

        [HttpGet("getByemailSms/{emailSms}")]
        public IActionResult GetByemailSms(bool emailSms)
        {
            var cadastro = _repository.Cadastros.FindAll(c => c.emailSms == emailSms);
            if (cadastro.Capacity == 0) return NotFound("The client was not found");
            return Ok(cadastro);
        }

        [HttpGet("getBywhatsapp/{whatsapp}")]
        public IActionResult GetBywhatsapp(bool whatsapp)
        {
            var cadastro = _repository.Cadastros.FindAll(c => c.whatsapp == whatsapp);
            if (cadastro.Capacity == 0) return NotFound("The client was not found");
            return Ok(cadastro);
        }

        [HttpGet("getBycountry/{country}")]
        public IActionResult GetBycountry(string country)
        {
            var cadastro = _repository.Cadastros.FindAll(c => c.country == country);
            if (cadastro.Capacity == 0) return NotFound("The client was not found");
            return Ok(cadastro);
        }

        [HttpGet("getBycity/{city}")]
        public IActionResult GetBycity(string city)
        {
            var cadastro = _repository.Cadastros.FindAll(c => c.city == city);
            if (cadastro.Capacity == 0) return NotFound("The client was not found");
            return Ok(cadastro);
        }

        [HttpGet("getBypostalCode/{postalCode}")]
        public IActionResult GetBypostalCode(string postalCode)
        {
            var cadastro = _repository.Cadastros.FindAll(c => c.postalCode == postalCode);
            if (cadastro.Capacity == 0) return NotFound("The client was not found");
            return Ok(cadastro);
        }

        [HttpGet("getByaddress/{address}")]
        public IActionResult GetByaddress(string address)
        {
            var cadastro = _repository.Cadastros.FindAll(c => c.address == address);
            if (cadastro.Capacity == 0) return NotFound("The client was not found");
            return Ok(cadastro);
        }

        [HttpGet("getBynumber/{number}")]
        public IActionResult GetBynumber(int number)
        {
            var cadastro = _repository.Cadastros.FindAll(c => c.number == number);
            if (cadastro.Capacity == 0) return NotFound("The client was not found");
            return Ok(cadastro);
        }

        [HttpPost]
        public IActionResult Post(Cadastro cadastro)
        {
            if (Validation.ValidateEmail(cadastro))
            {
                _repository.add(cadastro);
                return Created("~api/customer", cadastro);
            }
            return BadRequest("Email incorrect");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Cadastro cadastro)
        {
            var cdt = _repository.Cadastros.FindAll(c => c.Id == id);
            if (cdt == null) return NotFound("Registration not found");
            return Ok(cadastro);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, Cadastro cadastro)
        {
            _repository.deleteCdt(cadastro);
            return Ok("Registration successfully removed");
        }
    }
}