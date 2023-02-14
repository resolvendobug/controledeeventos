using Microsoft.AspNetCore.Mvc;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Application.Contratos;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{


    private readonly IEventoService eventoService;

    public EventoController(IEventoService eventoService)
    {
        this.eventoService = eventoService;


    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var eventos = await this.eventoService.GetAllEventosAsync(true);
            if (eventos == null) return NotFound("Nenhum evento encontrado");

            return Ok(eventos);
        }
        catch (Exception ex)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tentar recuperar eventos. Ero:" + ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var evento = await this.eventoService.GetEventoByIdAsync(id, true);
            if (evento == null) return NotFound("Nenhum evento encontrado");

            return Ok(evento);
        }
        catch (Exception ex)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tentar recuperar eventos. Erro:" + ex.Message);
        }
    }

    [HttpGet("{tema}/tema")]
    public async Task<IActionResult> GetByTema(string tema)
    {
        try
        {
            var eventos = await this.eventoService.GetAllEventosByTemaAsync(tema, true);
            if (eventos == null) return NotFound("Eventos por tema encontrados.");

            return Ok(eventos);
        }
        catch (Exception ex)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tentar recuperar eventos. Erro:" + ex.Message);
        }
    }


    [HttpPost]
    public async Task<IActionResult> Post(Evento model)
    {
        try
        {
            var evento = await this.eventoService.AddEventos(model);
            if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

            return Ok(evento);
        }
        catch (Exception ex)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tentar adicionar eventos. Erro:" + ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Evento model)
    {
        try
        {
            var evento = await this.eventoService.UpdateEvento(id, model);
            if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

            return Ok(evento);
        }
        catch (Exception ex)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tentar atualizar eventos. Erro:" + ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
           return await this.eventoService.DeleteEvento(id) ? Ok("Deletado") : BadRequest("Evento não deletado");
           
        }
        catch (Exception ex)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tentar deletar eventos. Erro:" + ex.Message);
        }
    }
}
