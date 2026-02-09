namespace Practice
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
