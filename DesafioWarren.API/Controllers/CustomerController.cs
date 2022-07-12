﻿using Application.Dtos;
using AppServices.ServicesApplication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
                var IdProtection = _customerAppService.GetById(id);
                return IdProtection is null
                    ? NotFound($"Client not found! for id: {id}")
                    : Ok(IdProtection);
            });
        }

        [HttpGet("getByFullName/{fullname}")]
        public IActionResult GetByFullName(string fullname)
        {
            return SafeAction(() =>
            {
                var fullnameProtection = _customerAppService.GetAllByFullname(fullname);
                return fullnameProtection.FirstOrDefault() is null
                    ? NotFound($"Client not found! For FullName: {fullname}")
                    : Ok(fullnameProtection);
            });
        }

        [HttpGet("getByEmail/{email}")]
        public IActionResult GetByEmail(string email)
        {
            return SafeAction(() =>
            {
                var emailProtection = _customerAppService.GetByEmail(email);
                return emailProtection is null
                    ? NotFound($"Client not found! For Email: {email}")
                    : Ok(emailProtection);
            });
        }

        [HttpGet("getByCpf/{cpf}")]
        public IActionResult GetByCpf(string cpf)
        {
            return SafeAction(() =>
            {
                var cpfProtection = _customerAppService.GetByCpf(cpf);
                return cpfProtection is null
                    ? NotFound($"Client not found! For CPF: {cpf}")
                    : Ok(cpfProtection);
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
                customerUp.Id = id;
                var updatedCustomer = _customerAppService.Update(customerUp);
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