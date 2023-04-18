using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Study_UserRegistrationLibrary.Entities;
using Study_UserRegistrationLibrary.Entities.DTOs;
using Study_UserRegistrationLibrary.Interfaces;

namespace Study_UserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository repository, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await _userRepository.GetAll();

            return user.Any() 
                ? Ok(user)
                : BadRequest("Doesn't exist registered users.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.GetById(id);

            // Mapeando propriedades usando AutoMapper através de injeção de dependencia
            var userReturn = _mapper.Map<UserDto>(user);
            //

            return userReturn != null
                ? Ok(userReturn)
                : BadRequest("User not found.");
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateUpdateDto user)
        {
            if (user == null) return BadRequest("Invalid data.");

            var userCreate = _mapper.Map<User>(user);

            _userRepository.Create(userCreate);

            return await _userRepository.SaveChangesAsync()
                ? Ok("User successfuly saved.")
                : BadRequest("Error saving user");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserCreateUpdateDto user)
        {
            if (id <= 0) return BadRequest("Uninformed user.");

            var dbUser = await _userRepository.GetById(id);
            //Faz a busca do usuário no banco

            var userUpdate = _mapper.Map(user, dbUser);
            //Aqui é necessário passar a origem(que trás a requisição) e o nosso destino

            _userRepository.Update(userUpdate);

            return await _userRepository.SaveChangesAsync()
                ? Ok("User succesfuly updated.")
                : BadRequest("Error updating user.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid user.");

            var userDelete = await _userRepository.GetById(id);

            if (userDelete == null) return NotFound("User not found.");

            _userRepository.Delete(userDelete);

            return await _userRepository.SaveChangesAsync()
                ? Ok("User succesfuly deleted.")
                : BadRequest("Error deleting user.");
        }
    }
}
