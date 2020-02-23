using System;
using VendasWebMvc.Models.Enums;

namespace VendasWebMvc.Models
{
    public class VendasRegistro
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Total { get; set; }
        public  StatusVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public VendasRegistro()
        {

        }

        public VendasRegistro(int id, DateTime data, double total, StatusVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Total = total;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
