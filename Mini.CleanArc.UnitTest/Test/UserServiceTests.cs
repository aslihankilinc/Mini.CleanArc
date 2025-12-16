using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mini.CleanArc.Core.Application.Models.UserDto;
using Mini.CleanArc.Infrastructure;
using Mini.CleanArc.Infrastructure.Persistence;
using Mini.CleanArc.Infrastructure.Service;

namespace Mini.CleanArc.UnitTest.Test
{
    public class UserServiceTests
    {
        private readonly IMapper _mapper;
        private readonly DbContextOptions<AppDbContext> _options;

        public UserServiceTests()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDb") // This requires the Microsoft.EntityFrameworkCore.InMemory package  
                .Options;

            var config = MapperConfig.RegisterMaps();
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task CreateUser_ShouldAddUser()
        {
            using var context = new AppDbContext(_options);
            var service = new UserService(context, _mapper);

            var user = await service.CreateAsync(new CreateUserDto
            {
                Name = "Test",
                Email = "test@example.com",
            });

            Assert.NotNull(user);
            Assert.Equal("Test", user.Name);
        }
    }

}
