using System.Text.Json.Serialization;

namespace Poc_Template_Domain.Model.Services
{
    public class ViaCEP
    {
        public ViaCEP() { }

        public ViaCEP(string cep, string logradouro, string complemento, string bairro, string localidade, string uf)
        {
            CEP = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Bairro = bairro;
            Localidade = localidade;
            UF = uf;
        }

        [JsonPropertyName("cep")]
        public string CEP { get; set; }
        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }
        [JsonPropertyName("complemento")]
        public string Complemento { get; set; }
        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }
        [JsonPropertyName("localidade")]
        public string Localidade { get; set; }
        [JsonPropertyName("uf")]
        public string UF { get; set; }
    }
}
