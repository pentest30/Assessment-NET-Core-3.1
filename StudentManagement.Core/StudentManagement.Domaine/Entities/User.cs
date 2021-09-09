using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace StudentManagement.Domaine.Entities
{
    public class User : IdentityUser<Guid>
    {
        public Student Student { get; set; }
        public Guid? StudentId { get; set; }
       
    }
}