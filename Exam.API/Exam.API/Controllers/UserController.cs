
using Exam.API.Interfaces;
using Exam.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Exam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userRepository.GetAll();
            return new JsonResult(users);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] List<User> users)
        {
            foreach (var user in users)
            {
                var result = _userRepository.Get(user.id);
                if (result == null)
                {
                    _userRepository.Add(user);
                }
            }

            return new JsonResult(users);
        }

    }
}