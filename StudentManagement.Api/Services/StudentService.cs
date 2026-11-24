using Microsoft.EntityFrameworkCore;
using StudentManagement.Api.DTOs;
using StudentManagement.Domain;
using StudentManagement.Infrastructure;

namespace StudentManagement.Api.Services;

public class StudentService : IStudentService
{
    private readonly SchoolDbContext _context;

    public StudentService(SchoolDbContext context)
    {
        _context = context;
    }

   

    public async Task<List<StudentDto>> GetAllAsync()
    {
        return await _context.Students
            .Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age,
                Email = s.Email,
                           })
            .ToListAsync();
    }

    public async Task<StudentDto?> GetByIdAsync(int id)
    {
        return await _context.Students
            .Where(s => s.Id == id)
            .Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age,
                Email = s.Email,
              
            })
            .FirstOrDefaultAsync();
    }

    public async Task<StudentDto> CreateAsync(CreateStudentDto studentDto)
    {
        var student = new Student(studentDto.Name, studentDto.Age, studentDto.Email);
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            Age = student.Age,
            Email = student.Email
         
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateStudentDto studentDto) 
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            return false;
        }
        student.Name = studentDto.Name;
        student.Age = studentDto.Age;
        student.Email = studentDto.Email;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
    var student = await _context.Students.FindAsync(id);
    if (student == null)
    {
        return false;
    }
    _context.Students.Remove(student);
    await _context.SaveChangesAsync();
    return true;
    }
        
}
