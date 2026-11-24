using Microsoft.EntityFrameworkCore;
using StudentManagement.Api.DTOs;
using StudentManagement.Domain;
using StudentManagement.Infrastructure;

namespace StudentManagement.Api.Services;

public class CourseService : ICourseService
{
    private readonly SchoolDbContext _context;

    public CourseService(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<List<CourseDto>> GetAllAsync()
    {
        return await _context.Courses
            .Select(c => new CourseDto
            {
                Id = c.Id,
                Name = c.Name,
                Credits = c.Credits
            })
            .ToListAsync();
    }

    public async Task<CourseDto?> GetByIdAsync(int id)
    {
        return await _context.Courses
            .Where(c => c.Id == id)
            .Select(c => new CourseDto
            {
                Id = c.Id,
                Name = c.Name,
                Credits = c.Credits
            })
            .FirstOrDefaultAsync();
    }

    public async Task<CourseDto> CreateAsync(CreateCourseDto courseDto)
    {
        var course = new Course(courseDto.Name, courseDto.Credits);
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        return new CourseDto
        {
            Id = course.Id,
            Name = course.Name,
            Credits = course.Credits
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateCourseDto courseDto)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            return false;
        }

        course.Name = courseDto.Name;
        course.Credits = courseDto.Credits;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            return false;
        }

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
        return true;
    }
}
