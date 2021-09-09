using System;
using StudentManagement.Domaine.Entities;

namespace StudentManagement.Application.Students.DTOs
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Speciality{ get; set; }
        public string SchoolYear { get; set; }
        public StudentRegistrationStatus Status { get; set; }
    }
}