using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAuto.Modelos
{
    [Table("Vehiculo")]
    public class Auto
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        
        public string Marca { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        
        public string Modelo { get; set; }

        [Column(TypeName = "varchar(50)")]
        
        public string Color { get; set; }

        [Column(TypeName= "money")]
       
        public decimal Precio { get; set; }
    }
}
