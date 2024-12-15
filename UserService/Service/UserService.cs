using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.DTOs;
using UserService.Models;
using UserService.Repositories;
using Microsoft.Extensions.Configuration;

namespace UserService.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userRepository.GetAllUsersAsync();
                return _mapper.Map<IEnumerable<UserDTO>>(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all users.");
                throw;
            }
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id);
                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting user with ID {id}.");
                throw;
            }
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                var createdUser = await _userRepository.CreateUserAsync(user);
                return _mapper.Map<UserDTO>(createdUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new user.");
                throw;
            }
        }

        public async Task UpdateUserAsync(int id, UserDTO userDto)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id);
                if (user == null)
                {
                    throw new KeyNotFoundException($"User  with ID {id} not found.");
                }
                _mapper.Map(userDto, user);
                await _userRepository.UpdateUserAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating user with ID {id}.");
                throw;
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            try
            {
                await _userRepository.DeleteUserAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting user with ID {id}.");
                throw;
            }
        }
        public async Task<LoginResponseDTO> AuthenticateAsync(string username, string password)
        {
            try
            {
                var user = await _userRepository.VerifyLoginDetails(username);
                if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return null;
                }

                var token = await GenerateToken(user);
                if (token == null)
                {
                    _logger.LogError($"Something went wrong while generating the token with username {username}.");
                    throw new Exception("Something went wrong");
                }
                LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
                {
                    token = token,
                    userInfo = _mapper.Map<UserDTO>(user)
                };
                return loginResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while authenticating user with username {username}.");
                throw;
            }
        }

        private async Task<string> GenerateToken(User user)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim("sub", user.Id.ToString())
                      }),
                    Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while generating token.");
                return null;
            }
        }
    }
}