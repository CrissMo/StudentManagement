using StudentManagement.Domain;

string[] names = { "Alice", "Bob", "Charlie" };
foreach (string name in names)
{
    Console.WriteLine(name);
}
// Add comments

List<Student> students = new List<Student>();
List<Course> courses = new List<Course>();

students.Add(new Student("Jane Smith", 22, "jane.smith@example.com", 8.5m));
students.Add(new Student("John Doe2", 20, "john.doe@example.com", 7.0m));
students.Add(new Student("Alice Johnson", 21, "alice.johnson@example.com", 3.0m));
students.Add(new Student("Bob Brown2", 19, "bob.brown@example.com", 8.0m));
students.Add(new Student("Charlie Davis", 19, "charlie.davis@example.com", 7.0m));


courses.Add(new Course("Programare c#", 8));
courses.Add(new Course("Programare Java", 6));
courses.Add(new Course("Programare Python", 7));

Console.WriteLine(students.Count);

foreach (Student student in students)
{
    Console.WriteLine(student.Name);
    //foreach (Course course in courses)
    //{
    //    Console.WriteLine(course.Name);
    //}
}

//numele primului student
Console.Write(students[0].Name);

//Adaugati un student nou
students.Add(new Student("New Student", 23, "george@test.com", 10m));

Console.WriteLine($"\nNumar studenti dupa adaugare: {students.Count}");

// Studentii cu media >= 5
var promotedStudents = students.Where(s => s.AverageGrade >= 5);

foreach (Student student in promotedStudents)
{
    Console.WriteLine($"{student.Name} - {student.AverageGrade}");
}

//  Sortare alfabetica
var orderedByName = students.OrderBy(s => s.Name);

foreach (Student student in orderedByName)
{
    Console.WriteLine(student.Name);
}

// Sortare dupa medie
var orderedByGrade = students.OrderByDescending(s => s.AverageGrade);

foreach (Student student in orderedByGrade)
{
    Console.WriteLine($"{student.Name} - {student.AverageGrade}");
}

//  Doar numele
var studentNames = students.Select(s => s.Name);

foreach (string name in studentNames)
{
    Console.WriteLine(name);
}

// Numarati studentii cu media < 5
int failedStudents =
    students.Count(s => s.AverageGrade < 5);

Console.WriteLine($"\nStudenti cu media sub 5: {failedStudents}");

//  Exista cel putin un student cu media 10?
bool hasPerfectGrade =
    students.Any(s => s.AverageGrade == 10);

Console.WriteLine($"\nExista student cu media 10? {hasPerfectGrade}");

// Toti studentii au varsta >= 18?
bool allAdults =
    students.All(s => s.Age >= 18);

Console.WriteLine($"\nToti au cel putin 18 ani? {allAdults}");

// Primul student cu numele Ana
Student ana =
    students.FirstOrDefault(s => s.Name == "Ana");

Console.WriteLine("\nCautare student Ana:");

if (ana != null)
{
    Console.WriteLine(ana.Name);
}
else
{
    Console.WriteLine("Student negasit");
}

// Ia primul student din lista >0
Console.WriteLine("\nPrimul student din lista:");

if (students.Count > 0)
{
    Student firstStudent = students[0];
    Console.WriteLine(firstStudent.Name);
}

//Sortare dupa varsta si nume
var orderedByAge = students
    .OrderBy(s => s.Age)
    .ThenBy(s => s.Name);

foreach (Student student in orderedByAge)
{
    Console.WriteLine($"{student.Name} - {student.Age}");
}

// Salvarea in List<Student>
List<Student> promotedList = students
    .Where(s => s.AverageGrade >= 5)
    .ToList();

// Varste distincte
var distinctAges = students
    .Select(s => s.Age)
    .Distinct();

foreach (int age in distinctAges)
{
    Console.WriteLine(age);
}