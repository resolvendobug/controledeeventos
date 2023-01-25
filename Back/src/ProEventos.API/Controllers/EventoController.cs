using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    public IEnumerable<Evento> _evento = new Evento[] {

            new Evento()
            {
                EventoId = 1,
                Tema = "Angular e .NET",
                Local = "Belo Horizonte",
                QtdPessoas = 250,
                Lote = "1º Lote",
                ImagemURL = "foto.png",
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")

            } ,
            new Evento()
            {

                EventoId = 2,
                Tema = "Angular e .NET",
                Local = "Belo Horizonte",
                QtdPessoas = 350,
                Lote = "2º Lote",
                ImagemURL = "foto.png",
                DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")

            }
        };

        
    public EventoController()
    {
        
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _evento;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
        return _evento.Where(evento => evento.EventoId == id);
    }

    [HttpPost]
    public string Post()
    {
        return "Exemplo de Post";
    }

    [HttpPut("{id}")]
    public string Put(int id)
    {
        return $"Exemplo de Put com id = {id}";
    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return $"Exemplo de Delete com id = {id}";
    }
}
