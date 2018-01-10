﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion.DomainModel
{
    public class Province
    {
        public virtual string Description { get; set; }
        public virtual int Id { get; set; }
        public virtual Country Country { get; set; }
        public virtual IList<City> Cities { get; set; }
    }
}