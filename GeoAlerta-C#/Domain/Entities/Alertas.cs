using GeoAlerta_C_.Domain.Enums;

namespace GeoAlerta_C_.Domain.Entities
{
    public class Alertas
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public NivelRisco NivelRisco { get; set; }
        public int Probabilidade { get; set; }
        public string Descricao { get; set; }

        // Relacionamento com Usuario N..1
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Relacionamento com Endereco N..1
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

    }
}
