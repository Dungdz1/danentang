using danentang.DbContexts;
using danentang.Dtos;
using danentang.Entity;
using danentang.Services.Abstract;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace danentang.Services.Implements
{
    public class UserService : BaseService, IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public UserService(ApplicationDbContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public UserDto CreateUser(CreateUserDto input)
        {
            var user = new User
            {
                Name = input.Name,
                Password = input.Password,
            };
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
            };
        }

        public void DeleteUser(int id)
        {
            var userFind = FindUserById(id);
            _dbContext.Users.Remove(userFind);
            _dbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            var result = _dbContext.Users.Select(s => new User
            {
                Id = s.Id,
                Name = s.Name,
                Password = s.Password,
            });
            return result.ToList();
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto input)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Name == input.Name && u.Password == input.Password);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            var token = GenerateJwtToken(user);

            return await Task.FromResult(new LoginResponseDto
            {
                UserId = user.Id,
                Name = user.Name,
                Password = user.Password,
                Token = token,
            });
        }


        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public void UpdateUser(UserDto input)
        {
            var userFind = FindUserById(input.Id);
            userFind.Name = input.Name;
            userFind.Password = input.Password;

            _dbContext.SaveChanges();
        }
    }
}
