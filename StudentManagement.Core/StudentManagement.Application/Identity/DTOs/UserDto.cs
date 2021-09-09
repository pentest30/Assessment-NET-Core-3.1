using System;

namespace StudentManagement.Application.Identity.DTOs
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Role { get; set; }
        public Guid Id { get; set; }
    }
}