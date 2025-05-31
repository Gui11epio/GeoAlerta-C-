using GeoAlerta_C_.Application.DTOs.Request;
using GeoAlerta_C_.Application.DTOs.Response;
using GeoAlerta_C_.Domain.Entities;
using GeoAlerta_C_.Domain.Enums;
using GeoAlerta_C_.Infrastructure.Context;

namespace GeoAlerta_C_.Application.Services
{
    public class AlertaService
    {
        private readonly AppDBContext _context;

        public AlertaService(AppDBContext context)
        {
            _context = context;
        }

        public AlertaResponse CalcularAlerta(DadosClimaticosRequest dados)
        {
            int pontos = 0;

            if (dados.Chuva >= 10) pontos += 3;
            else if (dados.Chuva >= 5) pontos += 2;
            else if (dados.Chuva >= 1) pontos += 1;

            if (dados.Umidade > 80) pontos += 2;
            else if (dados.Umidade >= 60) pontos += 1;

            if (dados.Vento > 10) pontos += 2;
            else if (dados.Vento >= 5) pontos += 1;

            if (dados.Nuvens > 70) pontos += 1;
            if (dados.Pressao < 1000) pontos += 1;

            NivelRisco nivel;
            string descricao;
            int probabilidade;

            if (pontos <= 2)
            {
                nivel = NivelRisco.MUITO_BAIXO;
                descricao = "Sem riscos. Condições estáveis.";
                probabilidade = 5;
            }
            else if (pontos <= 4)
            {
                nivel = NivelRisco.BAIXO;
                descricao = "Chuvas leves. Nenhum risco visível.";
                probabilidade = 15;
            }
            else if (pontos <= 6)
            {
                nivel = NivelRisco.MODERADO;
                descricao = "Condições que merecem atenção.";
                probabilidade = 40;
            }
            else if (pontos <= 8)
            {
                nivel = NivelRisco.ALTO;
                descricao = "Risco relevante de deslizamento.";
                probabilidade = 70;
            }
            else
            {
                nivel = NivelRisco.CRITICO;
                descricao = "Risco crítico. Ações imediatas recomendadas.";
                probabilidade = 90;
            }

            var usuario = _context.Usuarios.Find(dados.UsuarioId);
            if (usuario == null) throw new Exception("Usuário não encontrado.");

            var endereco = _context.Enderecos.Find(dados.EnderecoId);
            if (endereco == null) throw new Exception("Endereço não encontrado.");

            var alerta = new Alertas
            {
                NivelRisco = nivel,
                Descricao = descricao,
                Probabilidade = probabilidade,
                DataHora = DateTime.Now,
                Usuario = usuario,
                Endereco = endereco
            };

            _context.Alertas.Add(alerta);
            _context.SaveChanges();

            return new AlertaResponse
            {
                NivelRisco = nivel.ToString(),
                Descricao = descricao,
                Probabilidade = probabilidade
            };
        }
    }
}
