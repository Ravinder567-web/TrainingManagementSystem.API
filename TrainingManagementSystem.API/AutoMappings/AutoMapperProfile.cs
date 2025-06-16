namespace TrainingManagementSystem.API.Mappings
{
    using AutoMapper;
    
    using global::TrainingManagementSystem.API.DTOs;
    using global::TrainingManagementSystem.API.Models;

    namespace TrainingManagementSystem.API.Mappings
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                // Entity ↔ DTO
                CreateMap<Course, CourseDTO>().ReverseMap();
                CreateMap<Batch, BatchDTO>().ReverseMap(); // if you have BatchDTO
            }
        }
    }

}
