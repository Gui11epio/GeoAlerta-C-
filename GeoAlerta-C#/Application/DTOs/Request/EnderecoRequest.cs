namespace GeoAlerta_C_.Application.DTOs.Request
{
    public class EnderecoRequest
    {
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        public int UsuarioId { get; set; } // FK do usuário ao qual pertence
    }
}
