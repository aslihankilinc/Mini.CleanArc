
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mini.CleanArc.Core.Application.IContract;
using Mini.CleanArc.Core.Application.Models.UserDto;
using Mini.CleanArc.Core.Domain.Entity;
using Mini.CleanArc.Infrastructure.Persistence;

namespace Mini.CleanArc.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public UserService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
            => _mapper.Map<IEnumerable<UserResponseDto>>(await _db.Users.ToListAsync());

        public async Task<UserResponseDto?> GetByIdAsync(int id)
        {
            var user = await _db.Users.FindAsync(id);
            return _mapper.Map<UserResponseDto?>(user);
        }

        public async Task<UserResponseDto> CreateAsync(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<bool> UpdateAsync(int id, UpdateUserDto dto)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null) return false;
            _mapper.Map(dto, user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null) return false;
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return true;
        }
    }

}
