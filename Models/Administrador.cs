using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransferMarket.Models
{
    [Table("administradores")]
    public class Administrador
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        [MinLength(5, ErrorMessage = "Este campo tiene que tener minimo 5 caracteres")]
        [MaxLength(90, ErrorMessage = "Este campo tiene que tener Maximo 90 caracteres")]
        public string Nombre { get; set; }

        [Column("usuario")]
        [MinLength(5, ErrorMessage = "Este campo tiene que tener minimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "Este campo tiene que tener Maximo 90 caracteres")]
        public string Usuario { get; set; }

        [Column("contraseña")]
        [MinLength(5, ErrorMessage = "Este campo tiene que tener minimo 5 caracteres")]
        [MaxLength(255, ErrorMessage = "Este campo tiene que tener Maximo 255 caracteres")]
        public string Contraseña { get; set; }
    }
}