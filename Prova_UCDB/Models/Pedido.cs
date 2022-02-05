using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prova_UCDB.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  NomeProduto { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public DateTime DataVencimento { get; set; }
    }
}