using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LiveMatch.Models
{
    public class Entrada
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Display(Name = "Evento")]
        public int? EventoRefId { get; set; }
        [ForeignKey("EventoRefId")]
        public virtual Evento? Evento { get; set; }


        [Display(Name = "Parcialidad")]
        [Required(ErrorMessage = "Por favor, seleccione la parcialidad.")]
        public int? ParcialidadRefId { get; set; }
        [ForeignKey("ParcialidadRefId")]
        public virtual Parcialidad? Parcialidad { get; set; }

        [Display(Name = "TipoEspectador")]
        [Required(ErrorMessage = "Por favor, seleccione el tipo de espectador.")]
        public int? TipoEspectadorRefId { get; set; }
        [ForeignKey("TipoEspectadorRefId")]
        public virtual TipoEspectador? TipoEspectador { get; set; }

        [Display(Name = "UbicacionEstadio")]
        [Required(ErrorMessage = "Por favor, seleccione la ubicación.")]
        public int? UbicacionEstadioRefId { get; set; }
        [ForeignKey("UbicacionEstadioRefId")]
        public virtual UbicacionEstadio? UbicacionEstadio { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(50)]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Por favor, ingresar el precio")]
        [Display(Name = "Precio")]
        [Range(0, int.MaxValue, ErrorMessage = "El precio debe ser un valor no negativo.")]
        public int Precio { get; set; }

    }
}
