﻿using Microsoft.AspNetCore.Mvc;
using SaleemApi.Interface;
using SaleemApi.Model;
using SaleemApi.Unit_Of_Work;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaleemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericRepository<User> _userService;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IGenericRepository<User> userService, IUnitOfWork unitofwork)
        {
            _userService = userService;
            _unitOfWork = unitofwork;
        }
        // GET: api/<UserController>
        [HttpGet]
        public List<User> Get()
        {
            var users = _userService.GetAll();
            return users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var result = _userService.GetById(id);
            return result;
        }

        // POST api/<UserController>
        [HttpPost]
        public User Post([FromBody] User obj)
        {
            var user = _unitOfWork.Users.Add(obj);
            _unitOfWork.Save();
            //var user = _userService.Add(obj);
            return user;
        }


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public User Put(int id, [FromBody] User value)
        {
            if (id != value.Id)
            {
                throw new Exception("Please enter the valid details");
            }
            var result = _userService.Update(value, id);
            return result;
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            bool result = _userService.Delete(id);
            return result;
        }
    }
}
