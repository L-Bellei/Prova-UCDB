using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Prova_UCDB.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome do Pedido ")]
        
        public string NomePedido { get; set; }
        [Required]
        [Display(Name = "Valor do Pedido")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public double Valor { get; set; }
        
        [Required]
        [Display(Name = "Data do vencimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataVencimento { get; set; }
        
        [Display(Name = "Percentual de desconto(%)")]
        public double? DescontoPercentual { get; set; } = 0;
    }
}