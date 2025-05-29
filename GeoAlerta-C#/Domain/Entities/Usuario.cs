namespace GeoAlerta_C_.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string User_name { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }

        // Relacionamento com Endereco 1..1
        public Endereco Endereco { get; set; }

        // / Relacionamento com Alertas 1..N
        public ICollection<Alertas> Alertas { get; set; } = new List<Alertas>();
    }
}
