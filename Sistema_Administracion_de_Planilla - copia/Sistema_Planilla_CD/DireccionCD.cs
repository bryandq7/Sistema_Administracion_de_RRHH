using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class DireccionCD
    {
        public DireccionCE ObtenerDireccion(int id_direccion)
        {
            string sql = @"select d.Id_Direccion, d.Detalle_Direccion,p.Id_Provincia,p.Nombre_Provincia,c.Id_Canton,c.Nombre_Canton,di.Id_Distrito,di.Nombre_Distrito
                from Direccion d 
                inner join Distrito di on d.FKIdDistrito_Direccion = di.Id_Distrito
                inner join Canton c on di.FKIdCanton_Distrito = c.Id_Canton
                inner join Provincia p  on c.FKIdProvincia_Canton = p.Id_Provincia
				where d.Id_Direccion=@Cod_Direccion";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<DireccionCE>(sql, new SqlParameter("@Cod_Direccion",id_direccion)).FirstOrDefault();
            }
        }
    }
}
