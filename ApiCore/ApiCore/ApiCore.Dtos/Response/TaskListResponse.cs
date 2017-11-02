﻿using ApiCore.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCore.Dtos.Request
{
    public class TaskListResponse
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual TaskResult Result { get; set; }
        public virtual TicketStatus Status { get; set; }
        public virtual string Coments { get; set; }

    }
}
