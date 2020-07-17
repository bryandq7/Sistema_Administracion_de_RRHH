using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class TelefonoCD
    {
        public List<TelefonoCE> ObtenerListaTelefonosPersona(int FKId_Persona_Telefono)
        {
            string sql = @"select p.Id_Persona,p.Nombre_Persona,p.Apellido1_Persona,p.Apellido2_Persona, t.Id_Telefono,t.Numero_Telefono,t.FKId_Persona_Telefono 
                        from Telefono t 
                        inner join Persona p on t.FKId_Persona_Telefono = p.Id_Persona
                        where t.FKId_Persona_Telefono= @Cod_telefono";

            using (var db = new RecursosHumanosDBContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Database.SqlQuery<TelefonoCE>(sql, new SqlParameter("@Cod_telefono", FKId_Persona_Telefono)).ToList();
            }
        }
    }
}
