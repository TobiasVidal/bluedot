﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.DomainModel;

namespace ApiCore.Repository.Mappings
{
    public class OwnerMap : EntityMap<Owner>
    {
        public OwnerMap() : base("propietario")
        {
            this.HasRequired(x => x.User).WithMany().Map(x => x.MapKey("user_id"));
            this.Property(x => x.FunctionalUnitId).IsOptional().HasColumnName("functional_unit_id");
            //this.HasRequired(x => x.FunctionalUnit).WithOptional().Map(x => x.MapKey("functional_unit_id"));

        }

    }
}

