﻿using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class AspNetRolesCD
    {
        public List<AspNetRoles> ListarAspNetRoles()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.AspNetRoles.ToList();
            }
        }
    }
}
