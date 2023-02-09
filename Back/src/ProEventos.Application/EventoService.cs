using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist geralPersist;
        private readonly IEventoPersist eventoPersist;
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            this.eventoPersist = eventoPersist;
            this.geralPersist = geralPersist;

        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                this.geralPersist.Add<Evento>(model);
                if (await this.geralPersist.SaveChangesAsync())
                {
                    return await this.eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await this.eventoPersist.GetEventoByIdAsync(eventoId , false);
                if(evento == null) return null;

                this.geralPersist.Update(model);
                if (await this.geralPersist.SaveChangesAsync())
                {
                    return await this.eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await this.eventoPersist.GetEventoByIdAsync(eventoId , false);
                if(evento == null) throw new Exception("Evento para deletar não foi encontrado.");

                this.geralPersist.Delete<Evento>(evento);
                return await this.geralPersist.SaveChangesAsync();
                

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await this.eventoPersist.GetAllEventosAsync(includePalestrantes);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string Tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await this.eventoPersist.GetAllEventosByTemaAsync(Tema , includePalestrantes);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await this.eventoPersist.GetEventoByIdAsync(EventoId , includePalestrantes);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}