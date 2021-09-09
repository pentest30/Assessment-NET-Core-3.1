using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace StudentManagement.Domaine.Entities
{
    public class Student :Person
    {
        public Student()
        {
            
        }
        public Student(string firtName, string lastName ,DateTime birthdate,  Guid specialityId,  Guid schoolYearId, StudentRegistrationStatus status)
        {
            LastName = lastName;
            BirthDate = birthdate;
            SpecialityId = specialityId;
            SchoolYearId = schoolYearId;
            Status = status;
            FirstName = firtName;
        }

     
        
        public Speciality Speciality { get; set; }
        public Guid SpecialityId { get; set; }
        public SchoolYear SchoolYear { get; set; }
        public Guid SchoolYearId { get; set; }
        public StudentRegistrationStatus Status { get; set; }
    }
}