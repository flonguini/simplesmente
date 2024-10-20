using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SimplesmenteUse.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpPost("Arquivos")]
    public async Task<IActionResult> Criar([FromForm] ObjetoDigitalizadoRequest request)
    {
        var context = new SimplesmenteUseContext();

        var objeto = new ObjetoDigitalizado
        {
            Codigotipoobjeto =request.Codigotipoobjeto,
            Descricao =request.Descricao,
            Datacriacao = request.Datacriacao,
            Nomearquivo = request.Nomearquivo,
            Localizacaofisica = request.Localizacaofisica,
            Idusuariosalvou = request.Idusuariosalvou,
            NaoVisualizar = request.NaoVisualizar
        };

        using (var ms = new MemoryStream())
        {
            request.Objeto!.CopyTo(ms);
            objeto.Objeto = ms.ToArray();
        }

        await context.AddAsync(objeto);
        try
        {
            await context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex) { 
            return BadRequest(ex);
        }

    }

    [HttpGet("Arquivos/{id:int}")]
    public async Task<byte[]?> BuscarPorId(int id)
    {
        var context = new SimplesmenteUseContext();
        var objeto = await context.ObjetoDigitalizados
            .Where(x => x.Idobjeto == id)
            .Select(o => o.Objeto)
            .FirstAsync();
        try
        {
            return objeto;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    [HttpGet("Arquivos")]
    public async Task<ActionResult<object>> BuscarTodos([FromBody] int id)
    {
        var context = new SimplesmenteUseContext();
        var arquivos = await context.ObjetoDigitalizados
            .Where(x => x.Idobjeto == id)
            .Select(o => new { o.Idobjeto, o.Descricao, o.Nomearquivo })
            .FirstAsync();
        try
        {
            return Ok(arquivos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}
