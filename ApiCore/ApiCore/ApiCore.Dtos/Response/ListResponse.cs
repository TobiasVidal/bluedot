﻿using ApiCore.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCore.Dtos.Request
{
    public class ListResponse
    {
        public virtual int Id { get; set; }
        public virtual string Customer { get; set; }        
        public virtual int ConsortiumId { get; set; }                
        public virtual DateTime OpenDate { get; set; }
        public virtual string Coments { get; set; }
        public virtual List<TaskListResponse> Tasks {get;set;}

    }
}
