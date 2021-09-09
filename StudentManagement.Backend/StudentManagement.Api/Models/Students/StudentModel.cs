using System;
using Newtonsoft.Json;

namespace StudentManagement.Api.Models.Students
{
    public class StudentModel
    {
        [JsonProperty(propertyName:"firstName")]
        public string FirstName { get; set; }
        [JsonProperty(propertyName:"lastName")]
        public string LastName { get; set; }
        [JsonProperty(propertyName:"birthDate")]
        public DateTime BirthDate { get; set; }
        [JsonProperty(propertyName:"specialityId")]
        public Guid SpecialityId { get; set; }
        [JsonProperty(propertyName:"schoolYearId")]
        public Guid SchoolYearId { get; set; }
    }
}