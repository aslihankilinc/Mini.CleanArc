using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mini.CleanArc.Core.Application.IContract;
using Mini.CleanArc.Core.Application.Models.TaskDto;
using Mini.CleanArc.Core.Application.Models.UserDto;
using Mini.CleanArc.Core.Domain.Entity;
using Mini.CleanArc.Infrastructure.Persistence;

namespace Mini.CleanArc.Infrastructure.Service
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public TaskService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<TaskResponseDto> CreateAsync(CreateTaskDto dto)
        {
            var task = _mapper.Map<TaskItem>(dto);
            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();
            return _mapper.Map<TaskResponseDto>(task);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _db.Tasks.FindAsync(id);
            if (task == null) return false;
            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TaskResponseDto>> GetAllAsync()
        => _mapper.Map<IEnumerable<TaskResponseDto>>(await _db.Tasks.ToListAsync());

        public async Task<TaskResponseDto?> GetByIdAsync(int id)
        {
            var user = await _db.Tasks.FindAsync(id);
            return _mapper.Map<TaskResponseDto?>(user);
        }

        public async Task<bool> UpdateAsync(int id, UpdateTaskDto dto)
        {
            var task = await _db.Tasks.FindAsync(id);
            if (task == null) return false;
            _mapper.Map(dto, task);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
