using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransferMarket.Models
{
    [Table("jugadores")]
    public class Jugador
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("imagen_url")]
        [StringLength(50, ErrorMessage = "El maximo de caracteres en este campo es de 50")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "imagen")]
        public string Imagen { get; set; }

        [Column("nacionalidad")]
        [StringLength(50, ErrorMessage = "El maximo de caracteres en este campo es de 50")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Nacionalidad")]
        public  string Nacionalidad { get; set; }

        [Column("nombre_completo")]
        [StringLength(50, ErrorMessage = "El maximo de caracteres en este campo es de 50")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Nombre Completo")]
        public  string NombreCompleto { get; set; }

        [Column("posicion")]
        [StringLength(50, ErrorMessage = "El maximo de caracteres en este campo es de 50")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Posicion")]
        public  string Posicion { get; set; }

        [Column("valor")]
        [Required(ErrorMessage = "El campo valor es requerido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El campo valor tiene que ser positivo y mayor que 0.")]
        [DataType(DataType.Currency, ErrorMessage = "Formato de valor invalido")]
        public double Valor { get; set; }
    }
}