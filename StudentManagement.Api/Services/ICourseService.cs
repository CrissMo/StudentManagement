using StudentManagement.Api.DTOs;

namespace StudentManagement.Api.Services;

public interface ICourseService
{
    Task<List<CourseDto>> GetAllAsync();
    Task<CourseDto?> GetByIdAsync(int id);
    Task<CourseDto> CreateAsync(CreateCourseDto courseDto);
    Task<bool> UpdateAsync(int id, UpdateCourseDto courseDto);
    Task<bool> DeleteAsync(int id);
}
