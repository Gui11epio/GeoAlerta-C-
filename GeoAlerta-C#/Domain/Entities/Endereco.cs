namespace GeoAlerta_C_.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        // Relacionamento com Usuario 1..1
        public int UsuarioId { get; set; } 
        public Usuario Usuario { get; set; }
    }
}
