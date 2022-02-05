using System;
using System.ComponentModel.DataAnnotations;

namespace Prova_UCDB.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NomePedido { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public DateTime DataVencimento { get; set; }
        public double? DescontoPercentual { get; set; } = 0;
    }
}