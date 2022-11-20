using System.Collections.Generic;

namespace StoreWebApi_Alumni.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<CustomerOrderDTO> CustomerOrder { get; set; }
    }
}
