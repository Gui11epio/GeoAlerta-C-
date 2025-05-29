using System.Runtime.InteropServices;

namespace GeoAlerta_C_.Application.DTOs.Request
{
    public class DadosClimaticosRequest
    {
        
        public double Chuva { get; set; }

        public double Umidade { get; set; }

        public double Temperatura { get; set; }

        public double Vento { get; set; }

        public double Nuvens { get; set; }

        public double Pressao { get; set; }

        public int UsuarioId { get; set; }

        public int EnderecoId { get; set; }
    }
}
