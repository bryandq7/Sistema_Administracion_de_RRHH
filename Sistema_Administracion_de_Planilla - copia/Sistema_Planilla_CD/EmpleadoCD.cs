using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class EmpleadoCD
    {
        public List<EmpleadoCE> ListarEmpleados()
        {
            string sql = @"select e.Id_Empleado,e.FKId_Departamento_Empleado,e.FKId_Persona_Empleado,d.Id_Departamento,d.Nombre_Departamento,p.Id_Persona,p.Nombre_Persona+' '+p.Apellido1_Persona+' '+p.Apellido2_Persona as NombreCompletoPersona, u.Id as Id_Usuario, u.UserName,
				c.Id_Contrato, c.SalarioBruto_Contrato, c.FKId_TipoContrato_Contrato,c.FKId_Empleado_Contrato, c.FKId_Cargo_Contrato,c.FechaInicio_Contrato,c.FechaFin_Contrato,c.Activo_Contrato,
				tc.Id_TipoContrato,tc.Detalle_TipoContrato,ca.Id_Cargo,ca.Nombre_Cargo
                from Empleado e  
                inner join Persona p on e.FKId_Persona_Empleado = p.Id_Persona
				inner join Departamento d on e.FKId_Departamento_Empleado = d.Id_Departamento
				inner join AspNetUsers u on p.FKId_Usuario_Persona = u.Id
				inner join Contrato c on c.FKId_Empleado_Contrato = e.Id_Empleado
				inner join TipoContrato tc on tc.Id_TipoContrato = c.FKId_TipoContrato_Contrato
				inner join Cargo ca on ca.Id_Cargo = c.FKId_Cargo_Contrato
                where e.Activo_Empleado = 1";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<EmpleadoCE>(sql).ToList();
            }
        }

        public bool ExisteEmpleado(int personaID)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var ExisteEmpleado = db.Empleado
                    .Any(p => p.FKId_Persona_Empleado == personaID);

                return ExisteEmpleado;
            }
        }


        public EmpleadoCE ObtenerDetalleEmpleado(int idEmpleado)
        {

            string sql = @"select e.Id_Empleado,e.FKId_Departamento_Empleado,e.FKId_Persona_Empleado,d.Id_Departamento,d.Nombre_Departamento,p.Id_Persona,p.Nombre_Persona+' '+p.Apellido1_Persona+' '+p.Apellido2_Persona as NombreCompletoPersona, u.Id as Id_Usuario, u.UserName,
				c.Id_Contrato, c.SalarioBruto_Contrato, c.FKId_TipoContrato_Contrato,c.FKId_Empleado_Contrato, c.FKId_Cargo_Contrato,c.FechaInicio_Contrato,c.FechaFin_Contrato,c.Activo_Contrato,
				tc.Id_TipoContrato,tc.Detalle_TipoContrato,ca.Id_Cargo,ca.Nombre_Cargo
                from Empleado e  
                inner join Persona p on e.FKId_Persona_Empleado = p.Id_Persona
				inner join Departamento d on e.FKId_Departamento_Empleado = d.Id_Departamento
				inner join AspNetUsers u on p.FKId_Usuario_Persona = u.Id
				inner join Contrato c on c.FKId_Empleado_Contrato = e.Id_Empleado
				inner join TipoContrato tc on tc.Id_TipoContrato = c.FKId_TipoContrato_Contrato
				inner join Cargo ca on ca.Id_Cargo = c.FKId_Cargo_Contrato
                where e.Id_Empleado = @Cod_Empleado";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<EmpleadoCE>(sql, new SqlParameter("@Cod_Empleado", idEmpleado)).FirstOrDefault();
            }

        }

        public void Eliminar(int id_empleado)
        {


            using (var db = new RecursosHumanosDBContext())
            {
                var empleado = db.Empleado
                    .Where(e => e.Id_Empleado == id_empleado)
                    .FirstOrDefault();
                empleado.Activo_Empleado = false;
                //db.Persona.Remove(persona);
                db.SaveChanges();
            }
        }
    }
}
