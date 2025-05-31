using System.ComponentModel.DataAnnotations;

namespace GeoAlerta_C_.Application.DTOs.Request
{
    public class UsuarioRequest
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 20 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [RegularExpression(
            @"\(?(" +
            "11|12|13|14|15|16|17|18|19|" +     // SP  
            "21|22|24|" +                      // RJ  
            "27|28|" +                         // ES  
            "31|32|33|34|35|37|38|" +          // MG  
            "41|42|43|44|45|46|" +             // PR  
            "47|48|49|" +                      // SC  
            "51|53|54|55|" +                   // RS  
            "61|" +                            // DF  
            "62|64|" +                         // GO  
            "63|" +                            // TO  
            "65|66|" +                         // MT  
            "67|" +                            // MS  
            "68|" +                            // AC  
            "69|" +                            // RO  
            "71|73|74|75|77|" +                // BA  
            "79|" +                            // SE  
            "81|87|" +                         // PE  
            "82|" +                            // AL  
            "83|" +                            // PB  
            "84|" +                            // RN  
            "85|88|" +                         // CE  
            "86|89|" +                         // PI  
            "91|93|94|" +                      // PA  
            "92|97|" +                         // AM  
            "95|" +                            // RR  
            "96|" +                            // AP  
            "98|99" +                          // MA  
            @")\)?\s?9[6-9]\d{3}-\d{4}",
            ErrorMessage = "Telefone inválido. Use um DDD válido e o formato (11) 91234-5678")]
        public string Telefone { get; set; }

    }
}
