using System.Data.Entity;

namespace ALBA.Models
{
    public class Tratamento
    {
        public string Prefixo { get; set; }
        public string Numero { get; set; }
        public string Causa { get; set; }
        public string Solucao { get; set; }
    }

    public class TratamentoDBContext : DbContext
    {
        public DbSet<Tratamento> Tratamentos { get; set; }
    }
}