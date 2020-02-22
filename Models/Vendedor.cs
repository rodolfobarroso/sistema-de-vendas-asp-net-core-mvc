using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} obrigatório.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do {0} deve ter no mínimo {2} e no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} obrigatório.")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "{0} obrigatório.")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} deve ser entre {1} e {2}.")]
        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; } //garantir a integridade referencial - foreignKey
        public ICollection<RegistroVendas> Vendas { get; set; } = new List<RegistroVendas>();

        public Vendedor()
        {

        }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AddVendas(RegistroVendas registroVenda)
        {
            Vendas.Add(registroVenda);
        }

        public void RemoveVendas(RegistroVendas registroVenda)
        {
            Vendas.Remove(registroVenda);
        }

        public double TotalVendas(DateTime inicial, DateTime final)
        {
            return Vendas.Where(registroVenda => registroVenda.Data >= inicial && registroVenda.Data <= final).Sum(registroVenda => registroVenda.Total);
        }
    }
}
