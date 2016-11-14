using System;

namespace MinimalApiWithVersionDemo.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class PersonV2 : Person
    {
        public DateTime DateOfBirth { get; set; }
    }
}