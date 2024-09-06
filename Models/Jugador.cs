using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransferMarket.Models
{
    public class Jugador
    {
        public int Id { get; set; }
        public required string NombreCompleto { get; set; }
        public required string Posicion { get; set; }
        public decimal Valor { get; set; }
    }
}