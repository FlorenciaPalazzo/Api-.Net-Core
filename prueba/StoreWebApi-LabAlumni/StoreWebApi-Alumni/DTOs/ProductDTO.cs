using System.Collections.Generic;

namespace StoreWebApi_Alumni.DTOs
{
    public class ProductDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public List<OrderDetailDTO> OrderDetail { get; set; }

    }
}
