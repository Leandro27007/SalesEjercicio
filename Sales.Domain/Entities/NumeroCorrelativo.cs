namespace Sales.Domain.Entities
{
    public class NumeroCorrelativo
    {
        public int UltimoNumero { get; set; }
        public int CantidadDigitos { get; set; }
        public string Gestion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
