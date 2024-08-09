using Microsoft.AspNetCore.Mvc;

namespace Senac.Endereco.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    [HttpGet(Name = "GetEndereco")]
    public async Task<IActionResult> ObterEndereco(string cep)
    {
        var requisicao = await new ViaCepService()
    }
}
