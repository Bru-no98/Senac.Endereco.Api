using Newtonsoft.Json;
using Senac.Endereco.Dominio.Entities;

namespace Empresa.Endereco.Servico.ViaCep;

public class ViaCepService
{
    
    //Função assincrona que ira comunicar com o servidor da Via Cep
    public async Task<EnderecoEntity> ObterEnderecoPorCep(string cep)
    {
        // Abrindo uma comunicação de protocolo HTTP para comunicar com outro servidor
        var httpClient = new HttpClient();
        //Executando a operação de requisição para a rota da ViaCep, passando o CEP de forma dinâmica formatação de strng
        var retornoRequisicao = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json");
        
        //Verificando se a requisição respondeu com sucesso (status code 200)
        if(retornoRequisicao.IsSuccessStatusCode)
        {
            //Deu sucesso, conseguiu comunicar com a ViaCep
            //Obter a informação retornada pela Api
            var objetoSerializado = await retornoRequisicao.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<EnderecoEntity>(objetoSerializado);
        }
        return new EnderecoEntity();

    }
}
