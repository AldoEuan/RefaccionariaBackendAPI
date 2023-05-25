using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refaccionaria.Data.Maping
{

    public class Producto
    {
        [Display(Name = "Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [Column(TypeName = "VARCHAR(150)")]
        public string? Nombre { get; set; }

        [Display(Name = "Descripción")]
        [Required]
        [Column(TypeName = "VARCHAR(150)")]
        public string? Descripcion { get; set; }

        [Display(Name = "Precio de Compra")]
        [Required]
        [Column(TypeName = "SMALLMONEY")]
        public double Preciocosto { get; set; }

        [Display(Name = "Precio de Venta")]
        [Required]
        [Column(TypeName ="SMALLMONEY")]
        public double Precioventa { get; set; }

        [Display(Name = "Existencias")]
        [Required]
        [Column(TypeName = "SMALLMONEY")]
        public int Existencia { get; set; }
    }
}
