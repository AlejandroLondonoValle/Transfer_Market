using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TransferMarket.Models
{
    [Table("clubes")]
    public class Club
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("ciudad")]
        [StringLength(50, ErrorMessage = "El maximo de caracteres en este campo es de 50")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Ciudad")]
        public required string Ciudad { get; set; }

        [Column("nombre")]
        [StringLength(50, ErrorMessage = "El maximo de caracteres en este campo es de 50")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Nombre")]
        public required string Nombre { get; set; }

        [Column("estadio")]
        [StringLength(50, ErrorMessage = "El maximo de caracteres en este campo es de 50")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Estadio")]
        public required string Estadio { get; set; }

        [JsonIgnore]
        public virtual ICollection<Jugador> Jugadores { get; set; }
    }
}