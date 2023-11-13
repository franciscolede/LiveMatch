using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveMatch.Models
{
    public class TipoEspectador
    {
            [Key]
            public int Id { get; set; }

            [Display(Name = "Nombre")]
            public string Nombre { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? FechaRegistro { get; set; }
    }
}
