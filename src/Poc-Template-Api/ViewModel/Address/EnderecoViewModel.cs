namespace Poc_Template_Api.ViewModel.Address
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel() { }

        public EnderecoViewModel(int id, string cep, string logradouro, string complemento, string bairro, string localidade, string uf)
        {
            Id = id;
            CEP = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Bairro = bairro;
            Localidade = localidade;
            UF = uf;
        }

        public int Id { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
    }
}
