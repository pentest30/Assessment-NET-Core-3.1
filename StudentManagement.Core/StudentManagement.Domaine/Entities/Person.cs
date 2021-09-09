using System;

namespace StudentManagement.Domaine.Entities
{
    public class Person :BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}