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
                where e.Activo_Empleado = 1 and c.Activo_Contrato =1";

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

        public int ObtenerIdEmpleado()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                return db.Empleado.Max(p => p.Id_Empleado);
            }
        }


        public void Crear(EmpleadoCE empleado)
        {

            var empleado1 = new Empleado
            {
                FKId_Persona_Empleado = empleado.Id_Persona,
                FKId_Departamento_Empleado = empleado.Id_Departamento,
                Activo_Empleado = true
            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.Empleado.Add(empleado1);
                db.SaveChanges();
            }


            var idultimoregistroempleado = ObtenerIdEmpleado();

            var contrato = new Contrato
            {
                SalarioBruto_Contrato = empleado.SalarioBruto_Contrato,
                FechaInicio_Contrato = empleado.FechaInicio_Contrato,
                FechaFin_Contrato = empleado.FechaFin_Contrato,
                FKId_TipoContrato_Contrato = empleado.Id_TipoContrato,
                FKId_Empleado_Contrato = idultimoregistroempleado,
                FKId_Cargo_Contrato = empleado.Id_Cargo,
                Activo_Contrato = true

            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.Contrato.Add(contrato);
                db.SaveChanges();
            }


            var vacaciones = new Vacaciones
            {
                AcumuladoDias_Vacaciones = 0,
                FKId_Empleado_Vacaciones = idultimoregistroempleado

            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.Vacaciones.Add(vacaciones);
                db.SaveChanges();
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
                where e.Id_Empleado = @Cod_Empleado and c.Activo_Contrato=1";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<EmpleadoCE>(sql, new SqlParameter("@Cod_Empleado", idEmpleado)).FirstOrDefault();
            }

        }


        public void Editar(EmpleadoCE empleado)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.Empleado.Find(empleado.Id_Empleado);
                origen.FKId_Departamento_Empleado = empleado.Id_Departamento;
                //origen.FKId_StatusEmpleado = empleado.Id_StatusEmpleado;
                db.SaveChanges();
            }

            //using (var db = new RecursosHumanosDBContext())
            //{
            //    var origencon = db.Contrato.Find(empleado.Id_Contrato);

            //    int caseSwitch = empleado.Id_StatusEmpleado;


            //    switch (caseSwitch)
            //    {
            //        case 1:
            //            origencon.SalarioContrato_Contrato = empleado.SalarioBruto_Contrato;
            //            break;
            //        case 2:
            //            origencon.SalarioContrato_Contrato = 0;
            //            break;
            //        case 3:
            //            origencon.SalarioContrato_Contrato = empleado.SalarioBruto_Contrato;
            //            break;
            //        case 4:
            //            origencon.SalarioContrato_Contrato = empleado.SalarioBruto_Contrato;
            //            break;
            //        case 5:
            //            origencon.SalarioContrato_Contrato = empleado.SalarioBruto_Contrato;
            //            break;
            //        case 6:
            //            origencon.SalarioContrato_Contrato = empleado.SalarioBruto_Contrato / 2;
            //            break;
            //        case 7:
            //            origencon.SalarioContrato_Contrato = 0;
            //            break;


            //        default:
            //            Console.WriteLine("Default case");
            //            break;
            //    }






            //    origencon.SalarioContrato_Contrato = empleado.SalarioBruto_Contrato / 2;
            //    db.SaveChanges();
            //}


        }

        public void Eliminar(int id_empleado)
        {


            using (var db = new RecursosHumanosDBContext())
            {
                var empleado = db.Empleado
                    .Where(e => e.Id_Empleado == id_empleado)
                    .FirstOrDefault();
                //empleado.FKId_StatusEmpleado = 2;
                empleado.Activo_Empleado = false;
                //db.Persona.Remove(persona);
                db.SaveChanges();
            }

            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.Contrato
                .First(p => p.FKId_Empleado_Contrato == id_empleado && p.Activo_Contrato == true);
                origen.Activo_Contrato = false;
                db.SaveChanges();
            }
        }
    }
}
