﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiCore.Dtos;
using ApiCore.Dtos.Request;

namespace ApiCore.Controllers
{
    /// <summary>
    /// Controlador de tickets
    /// </summary>
    [RoutePrefix("Tickets")]
    public class TicketController : ApiController
    {

        public ITicketService TicketService { get; set; }
     

        // GET api/<controller>/5
        /// <summary>
        /// Devuelve un ticket
        /// </summary>
        /// <param name="ticket">id del Ticket</param>
        /// <returns></returns>

        [Route("{id}")]        
        [ResponseType(typeof(TicketResponse))]
        public string Get(int id)
        {
            var completeTicket = TicketService.GetById(id);

            if (completeTicket == null)
                throw new NotFoundException(ErrorMessages.TicketNotFound);

            var dto = Mapper.Map<TicketResponse>(completeTicket);
            
            return Ok(dto);
        }

        // POST api/<controller>
        /// <summary>
        /// Inserta un ticket
        /// </summary>
        /// <param name="ticket">Ticket a insertar</param>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(Entidad))]
        public void Post(TicketRequest ticket)
        {
            var result = TicketService.CreateTicket(ticket);

            return Created<Entidad>("", new Entidad { Id = result.Id });

        }

        // PUT api/<controller>/5
        /// <summary>
        /// Modifica un ticket
        /// </summary>
        /// <param name="ticket">Ticket a modificar</param>
        /// <returns></returns>
        public void Put(int id, TicketRequest ticket)
        {            
            var originalTicket = TicketService.GetById(id);
            
            var ret = TicketService.UpdateTicket(originalTicket, ticket);

            return Ok();
            
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// Elimina un ticket
        /// </summary>
        /// <param name="id">Ticket a eliminar</param>
        /// <returns></returns>
        public void Delete(int id)
        {

            if (id <= 0)
                return BadRequest();
            
            try
            {
               TicketService.DeleteTicket(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception(ex.Message));
            }
            
        }
    }
}