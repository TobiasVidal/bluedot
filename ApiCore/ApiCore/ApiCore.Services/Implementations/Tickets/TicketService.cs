﻿using ApiCore.Services.Contracts.Tickets;
using System;
using ApiCore.DomainModel;
using ApiCore.Dtos.Request;
using ApiCore.Repository.Contracts;
using ApiCore.Repository.Attributes;
using ApiCore.Library.Exceptions;
using ApiCore.Library.Mensajes;
using System.Collections.Generic;

namespace ApiCore.Services.Implementations.Tickets
{
    public class TicketService : ITicketService
    {
        public ITicketRepository TicketRepository { get; set; }
        public IConsortiumRepository ConsortiumRepository { get; set; }        
        public IStatusRepository StatusRepository { get; set; }
        public IFunctionalUnitRepository FunctionalUnitRepository { get; set; }
        public IPriorityRepository PriorityRepository { get; set; }        
        public IBacklogUserRepository BacklogUserRepository { get; set; }

        [Transaction]
        public Ticket CreateTicket(TicketRequest ticket)
        {
            var entityToInsert = new Ticket() { };
            MergeTicket(entityToInsert, ticket);
            TicketRepository.Insert(entityToInsert);
            return entityToInsert;
        }

        public Ticket GetById(int ticketId)
        {
            var ticket = TicketRepository.GetById(ticketId);
            if (ticket == null)
                throw new BadRequestException(ErrorMessages.TicketNoEncontrado);

            return ticket;
        }
        

        [Transaction]
        public Ticket UpdateTicket(Ticket originalTicket, TicketRequest ticket)
        {            
            this.MergeTicket(originalTicket, ticket);
            TicketRepository.Update(originalTicket);
            return originalTicket;

        }
        

        [Transaction]
        public void DeleteTicket(int ticketId)
        {
            var ticket = TicketRepository.GetById(ticketId);
            TicketRepository.Delete(ticket);
        }

        [Transaction]
        public IList<Ticket> GetAll()
        {
            var tickets = TicketRepository.GetAll();
            if (tickets == null)
                throw new BadRequestException(ErrorMessages.TicketNoEncontrado);

            var result = new List<Ticket>();
            var enumerator = tickets.GetEnumerator();
            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current);

            }
            return result ;
        }
        

        private void MergeTicket(Ticket originalTicket, TicketRequest ticket)
        {
            originalTicket.Customer = ticket.Customer;
            originalTicket.Consortium = this.ConsortiumRepository.GetById(ticket.ConsortiumId);
            originalTicket.Status = this.StatusRepository.GetById(ticket.StatusId);
            originalTicket.OpenDate = ticket.OpenDate;
            originalTicket.CloseDate = ticket.CloseDate;
            originalTicket.LimitDate = ticket.LimitDate;
            originalTicket.FunctionalUnit = this.FunctionalUnitRepository.GetById(ticket.FunctionalUnitId);
            originalTicket.Priority = this.PriorityRepository.GetById(ticket.PriorityId);
            originalTicket.Worker = this.BacklogUserRepository.GetById(ticket.WorkerId);
            originalTicket.Creator = this.BacklogUserRepository.GetById(ticket.CreatorId);
        }
        
    }
}
