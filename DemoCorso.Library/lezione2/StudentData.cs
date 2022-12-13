using System.Collections.ObjectModel;

namespace DemoCorso.Library.lezione2;

public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
}

public class StudentData
{
    public StudentData()
    {
        Students = new ObservableCollection<Student>()
        {
            new Student { Id = 1, Name = "Mario", Surname = "Rossi"},
            new Student { Id = 2, Name = "Luigi", Surname = "Bianchi"},
        };
    }

    public ObservableCollection<Student>? Students { get; private set; }
}
