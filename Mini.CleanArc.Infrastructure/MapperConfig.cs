using AutoMapper;
using Mini.CleanArc.Core.Application.Models.TaskDto;
using Mini.CleanArc.Core.Application.Models.UserDto;
using Mini.CleanArc.Core.Domain.Entity;

namespace Mini.CleanArc.Infrastructure
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var expression = new MapperConfigurationExpression();
            expression.CreateMap<User, UserResponseDto>();
            expression.CreateMap<CreateUserDto, User>();
            expression.CreateMap<UpdateUserDto, User>();
            //Task
            expression.CreateMap<TaskItem, TaskResponseDto>()
               .ForMember(dest => dest.AssignedUserName,
                          opt => opt.MapFrom(src => src.AssignedUser != null ? src.AssignedUser.Name : null));

            expression.CreateMap<CreateTaskDto, TaskItem>();
            expression.CreateMap<UpdateTaskDto, TaskItem>();
            var config = new MapperConfiguration(expression);
            return config;
        }
    }
}
