using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Клиенты
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController
        : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPreferenceRepository _preferenceRepository;

        public CustomersController(ICustomerRepository customerRepository, IPreferenceRepository preferenceRepository)
        {
            _customerRepository = customerRepository;
            _preferenceRepository = preferenceRepository;
        }

        /// <summary>
        /// Получить список всех клиентов
        /// </summary>
        /// <returns>CustomerShortResponse</returns>
        [HttpGet]
        public async Task<ActionResult<ICollection<CustomerShortResponse>>> GetCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();

            var response = customers.Select(c => new CustomerShortResponse()
            {
                Email = c.Email,
                FirstName = c.FirstName,
                Id = c.Id,
                LastName = c.LastName,
            });

            return Ok(response);
        }

        /// <summary>
        /// Получить клиента по ИД
        /// </summary>
        /// <param name="id">дентификатор клиента</param>
        /// <returns>CustomerResponse</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponse>> GetCustomerAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null) 
                return NotFound(id);

            var response = new CustomerResponse()
            {
                Email = customer.Email,
                FirstName = customer.FirstName,
                Id = customer.Id,
                LastName = customer.LastName,
                PromoCodes = customer.PromoCodes
                    .Select(p => new PromoCodeShortResponse()
                    {
                        Code = p.Code,
                        BeginDate = p.BeginDate.ToString("dd-MM-yyyy HH:mm:ss"),
                        EndDate = p.EndDate.ToString("dd-MM-yyyy HH:mm:ss"),
                        Id = p.Id,
                        PartnerName = p.PartnerName,
                        ServiceInfo = p.ServiceInfo,
                    })
                    .ToList()
            };
            return Ok(customer);
        }

        /// <summary>
        /// Создать клиента
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ИД клиента</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCustomerAsync(CreateOrEditCustomerRequest request)
        {
            //TODO: Добавить создание нового клиента вместе с его предпочтениями
            var customer = new Customer()
            {
                FirstName = request.FirstName,
                LastName= request.LastName,
                Email = request.Email,
            };

            customer = await _customerRepository.CreateAsync(customer);
            return Ok(customer.Id);
        }

        /// <summary>
        /// Редактирование данные клиента
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCustomerAsync(Guid id, CreateOrEditCustomerRequest request)
        {
            //TODO: Обновить данные клиента вместе с его предпочтениями
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
                return NotFound(id);

            customer.LastName = request.LastName;
            customer.Email = request.Email;
            customer.FirstName = request.FirstName;
            await _customerRepository.UpdateAsync(customer);

            return Ok();
        }

        /// <summary>
        /// Удалить клиента по ИД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            //TODO: Удаление клиента вместе с выданными ему промокодами
            var entity = await _customerRepository.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            await _customerRepository.DeleteAsync(entity);
            return Ok();
        }
    }
}