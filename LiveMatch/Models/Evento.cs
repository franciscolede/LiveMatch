using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveMatch.Models
{
    public class Evento
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }


        [Display(Name = "Imagen")]
        public string? ImagenEvento { get; set; }

        [Display(Name = "Equipo local")]
        [Required(ErrorMessage = "Por favor, seleccione el equipo local.")]
        public string Local { get; set; }


        [Display(Name = "Equipo visitante")]
        [Required(ErrorMessage = "Por favor, seleccione el equipo visitante.")]
        public string Visitante { get; set; }


        [Display(Name = "Deporte")]
        [Required(ErrorMessage = "Por favor, seleccione del deporte.")]
        public int? DeporteRefId { get; set; }
        [ForeignKey("DeporteRefId")]
        public virtual Deporte? Deporte { get; set; }


        [Display(Name = "Estadio")]
        [Required(ErrorMessage = "Por favor, seleccione el estadio.")]
        public int? EstadioRefId { get; set; }
        [ForeignKey("EstadioRefId")]
        public virtual Estadio? Estadio { get; set; }



        [Display(Name = "Fecha evento")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? FechaEvento { get; set; }

        [NotMapped]
        public string NombreCompleto => $"{Local} vs {Visitante}";


       

    }
}
