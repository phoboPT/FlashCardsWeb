using System.Collections.Generic;

namespace WebApplication1
{
    public class Customer
    {
        private static int _counter = 0;
        private int Id { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Address { get; set; }
        private string ZipCode { get; set; }
        private int Age { get; set; }

        // public string FirstName { get; set; }
        public Customer()
        {
            Id = ++_counter;
        }

        public static List<Customer> SampleCustomers = new List<Customer>()
        {
            new Customer()
                {Address = "Rua das flores", Age = 22, FirstName = "Ricardo", LastName = "Dias", ZipCode = "4930"},
            new Customer()
                {Address = "Rua das couves", Age = 35, FirstName = "João", LastName = "Pedro", ZipCode = "4900"}
        };

    }
}