using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain;
using StudentManagement.Infrastructure;

//string[] names = { "Alice", "Bob", "Charlie" };
//foreach (string name in names)
//{
//    Console.WriteLine(name);
//}
//// Add comments

//List<Student> students = new List<Student>();
//List<Course> courses = new List<Course>();

//students.Add(new Student("Jane Smith", 22, "jane.smith@example.com", 8.5m));
//students.Add(new Student("John Doe2", 20, "john.doe@example.com", 7.0m));
//students.Add(new Student("Alice Johnson", 21, "alice.johnson@example.com", 3.0m));
//students.Add(new Student("Bob Brown2", 19, "bob.brown@example.com", 8.0m));
//students.Add(new Student("Charlie Davis", 19, "charlie.davis@example.com", 7.0m));


//courses.Add(new Course("Programare c#", 8));
//courses.Add(new Course("Programare Java", 6));
//courses.Add(new Course("Programare Python", 7));

//Console.WriteLine(students.Count);

//foreach (Student student in students)
//{
//    Console.WriteLine(student.Name);
//    //foreach (Course course in courses)
//    //{
//    //    Console.WriteLine(course.Name);
//    //}
//}
//
////numele primului student
//Console.Write(students[0].Name);

////Adaugati un student nou
//students.Add(new Student("New Student", 23, "george@test.com", 10m));

//Console.WriteLine($"\nNumar studenti dupa adaugare: {students.Count}");

//// Studentii cu media >= 5
//var promotedStudents = students.Where(s => s.AverageGrade >= 5);

//foreach (Student student in promotedStudents)
//{
//    Console.WriteLine($"{student.Name} - {student.AverageGrade}");
//}

////  Sortare alfabetica
//var orderedByName = students.OrderBy(s => s.Name);

//foreach (Student student in orderedByName)
//{
//    Console.WriteLine(student.Name);
//}

//// Sortare dupa medie
//var orderedByGrade = students.OrderByDescending(s => s.AverageGrade);

//foreach (Student student in orderedByGrade)
//{
//    Console.WriteLine($"{student.Name} - {student.AverageGrade}");
//}

////  Doar numele
//var studentNames = students.Select(s => s.Name);

//foreach (string name in studentNames)
//{
//    Console.WriteLine(name);
//}

//// Numarati studentii cu media < 5
//int failedStudents =
//    students.Count(s => s.AverageGrade < 5);

//Console.WriteLine($"\nStudenti cu media sub 5: {failedStudents}");

////  Exista cel putin un student cu media 10?
//bool hasPerfectGrade =
//    students.Any(s => s.AverageGrade == 10);

//Console.WriteLine($"\nExista student cu media 10? {hasPerfectGrade}");

//// Toti studentii au varsta >= 18?
//bool allAdults =
//    students.All(s => s.Age >= 18);

//Console.WriteLine($"\nToti au cel putin 18 ani? {allAdults}");

//// Primul student cu numele Ana
//Student ana =
//    students.FirstOrDefault(s => s.Name == "Ana");

//Console.WriteLine("\nCautare student Ana:");

//if (ana != null)
//{
//    Console.WriteLine(ana.Name);
//}
//else
//{
//    Console.WriteLine("Student negasit");
//}

//// Ia primul student din lista >0
//Console.WriteLine("\nPrimul student din lista:");

//if (students.Count > 0)
//{
//    Student firstStudent = students[0];
//    Console.WriteLine(firstStudent.Name);
//}

////Sortare dupa varsta si nume
//var orderedByAge = students
//    .OrderBy(s => s.Age)
//    .ThenBy(s => s.Name);

//foreach (Student student in orderedByAge)
//{
//    Console.WriteLine($"{student.Name} - {student.Age}");
//}

//// Salvarea in List<Student>
//List<Student> promotedList = students
//    .Where(s => s.AverageGrade >= 5)
//    .ToList();

//// Varste distincte
//var distinctAges = students
//    .Select(s => s.Age)
//    .Distinct();

//foreach (int age in distinctAges)
//{
//    Console.WriteLine(age);
//}

var options = new DbContextOptionsBuilder<SchoolDbContext>()
    .UseSqlServer(
        @"Server=localhost;Database=StudentManagementDb;Trusted_Connection=True;TrustServerCertificate=True;")
    .Options;
using var context = new SchoolDbContext(options);

//var options = new DbContextOptionsBuilder<SchoolDbContext>()
//    .UseSqlServer(
//        @"Server=localhost;Database=StudentManagementDemo;Trusted_Connection=True;TrustServerCertificate=True;")
//    .Options;
//using var context = new SchoolDbContext(options);

//var students = await context.Students.ToListAsync();
//foreach (var student in students)
//{
//    Console.WriteLine(student.Name);
//}

////1.Afisati numele si media tuturor studentilor care au AverageGrade mai mica decat 7
//var studentFiltrat = await context.Students
//    .Where(s => s.AverageGrade < 7)
//    .OrderByDescending(s => s.AverageGrade)
//    .ToListAsync();
//foreach (var student in studentFiltrat)
//{
//    Console.WriteLine($"Nume: {student.Name} - {student.AverageGrade}");
//}

////2.Afisati numele si emailul tuturor studentilor, sortati alfabetic dupa nume
//var studentiSortati = await context.Students
//    .OrderBy(s => s.Name)
//    .ToListAsync();

//foreach (var student in studentiSortati)
//{
//    Console.WriteLine($"Nume: {student.Name} - Email: {student.Email}");

//}
////3.Cautati primul student care are AverageGrade mai mare sau egala cu 9.Afisati numele si media lui.
//var studentTop = await context.Students
//    .FirstOrDefaultAsync(s => s.AverageGrade >= 9);

//if (studentTop != null)
//{
//    Console.WriteLine($"Nume: {studentTop.Name} - Media: {studentTop.AverageGrade}");
//}
//else
//{
//    Console.WriteLine("Nu exista niciun student cu media >= 9");
//}

////4.Afisati primii 2 studenti cu cele mai mari medii.Afisati doar numele si media fiecaruia.
//var top2Students = await context.Students
//    .OrderByDescending(s => s.AverageGrade)
//    .Take(2)
//    .ToListAsync();

//foreach (var student in top2Students)
//{
//    Console.WriteLine($"Nume: {student.Name} - Media: {student.AverageGrade}");
//}


//5.Afisati numele studentului si nota obtinuta la inscriere(Grade).Afisati doar inscrierile cu Grade >=7, sortate descrescator dupa nota.
//var enrollments = await context.Students
//    .Join(
//        context.Enrollments,
//        s => s.Id,
//        e => e.StudentId,
//        (s, e) => new
//        {
//            StudentName = s.Name,
//            e.Grade
//        })
//    .Where(x => x.Grade >= 7)
//    .OrderByDescending(x => x.Grade)
//    .ToListAsync();
//if (enrollments.Count == 0)
//{
//    Console.WriteLine("Nu exista inscrieri cu aceasta nota.");
//}
//else
//{
//    foreach (var enrollment in enrollments)
//    {
//        Console.WriteLine($"{enrollment.StudentName} - Nota: {enrollment.Grade}");
//    }
//}
//
////creat student
//var studentsAdd = new Student("Pop Emil",22,"emip@nie.com", 8.56m);
//
////Add student
//await context.Students.AddAsync(studentsAdd);
//
////save changes
//await context.SaveChangesAsync();
//
//update student    
//var studentToUpdate = await context.Students.FirstOrDefaultAsync(s => s.Id == 1);
//if (studentToUpdate != null)
//{
//    studentToUpdate.UpdateAverage(7.5m);
//    await context.SaveChangesAsync();
//    
//}
//
//delete student    
//var studentToDelete = await context.Students.FirstOrDefaultAsync(s => s.Id == 7);   
//if (studentToDelete != null)
//{
//    context.Students.Remove(studentToDelete);
//    await context.SaveChangesAsync();
//}

var enrolcrud = await context.Enrollments
    .Include(e => e.Student)
    .Include(e => e.Course)
    .Where(e => e.Grade >= 7)
    .ToListAsync();
foreach (var e in enrolcrud)
{
    Console.WriteLine($"Student: {e.Student.Name} - Curs: {e.Course.Name} - Nota: {e.Grade}");
}
