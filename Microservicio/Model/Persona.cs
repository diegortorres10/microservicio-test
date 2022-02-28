using System.ComponentModel.DataAnnotations;

namespace Microservicio.Model
{
    public class Persona
    {
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(250, ErrorMessage = "Name can't be longer than 250 characters")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [StringLength(50, ErrorMessage = "Gender can't be longer than 50 characters")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Identification is required")]
        [StringLength(15, ErrorMessage = "Identification can't be longer than 15 characters")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(250, ErrorMessage = "Address can't be longer than 250 characters")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(45, ErrorMessage = "Phone can't be longer than 45 characters")]
        public string Telefono { get; set; }

    }
}
