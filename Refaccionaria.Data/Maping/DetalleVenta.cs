using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refaccionaria.Data.Maping
{
    public class DetalleVenta
    {
        [Display(Name = "Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Id de Ventas")]
        [Required]
        public int IdVenta { get; set; }

        [Display(Name = "Id de Productos")]
        [Required]
        public int IdProducto { get; set; }

        [Display(Name = "Cantidad")]
        [Required]
        public int Cantidad { get; set; }

        [Display(Name = "Precio de venta")]
        [Required]
        [Column(TypeName = "SMALLMONEY")]
        public double Precioventa { get; set; }

        [ForeignKey("IdProducto")]
        public virtual Producto? Producto { get; set; }

        [ForeignKey("IdVenta")]
        public virtual Sale? Venta { get; set; }
    }
}
