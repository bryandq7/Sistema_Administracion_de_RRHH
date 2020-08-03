﻿using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class ContratoCD
    {

        public List<ContratoCE> ListarContratos()
        {
            string sql = @"select e.Id_Empleado,e.FKId_Departamento_Empleado,e.FKId_Persona_Empleado,p.Id_Persona,p.Nombre_Persona+' '+p.Apellido1_Persona+' '+p.Apellido2_Persona as NombreCompletoPersona, 
				c.Id_Contrato, c.SalarioBruto_Contrato, c.FKId_TipoContrato_Contrato,c.FKId_Empleado_Contrato, c.FKId_Cargo_Contrato,c.FechaInicio_Contrato,c.FechaFin_Contrato,c.Activo_Contrato,
				tc.Id_TipoContrato,tc.Detalle_TipoContrato,ca.Id_Cargo,ca.Nombre_Cargo, c.FKId_Turno_Contrato, t.Id_Turno,t.Nombre_Turno
                from Contrato c  
                inner join Empleado e on c.FKId_Empleado_Contrato = e.Id_Empleado
				inner join TipoContrato tc on c.FKId_TipoContrato_Contrato = tc.Id_TipoContrato
				inner join Cargo ca on c.FKId_Cargo_Contrato = ca.Id_Cargo
				inner join Persona p on e.FKId_Persona_Empleado = p.Id_Persona
				inner join Turnos t on c.FKId_Turno_Contrato = t.Id_Turno
                where c.Activo_Contrato = 1 and e.Activo_Empleado = 1";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<ContratoCE>(sql).ToList();
            }
        }

        public int ObtenerIdEmpleado(int personaID)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var empleado = db.Empleado
                    .First(p => p.FKId_Persona_Empleado == personaID);

                var idempleado = empleado.Id_Empleado;

                return idempleado;
            }
        }

        //public bool ObtenerEmpleadoActivo(int personaID)
        //{
        //    using (var db = new RecursosHumanosDBContext())
        //    {
        //        var empleado = db.Empleado
        //            .Any(p => p.FKId_Persona_Empleado == personaID && p.Activo_Empleado == true && p.FKId_StatusEmpleado== 1);


        //        return empleado;
        //    }
        //}

        //public int ExisteEmpleado(int personaID)
        //{
        //    using (var db = new RecursosHumanosDBContext())
        //    {
        //        var empleado = db.Empleado
        //            .Count(p => p.FKId_Persona_Empleado == personaID);


        //        return empleado;
        //    }
        //}



        public void Crear(ContratoCE contrato1)
        {

            var idempleado = ObtenerIdEmpleado(contrato1.Id_Persona);

            var contrato2 = new Contrato 
            {
                SalarioBruto_Contrato = contrato1.SalarioBruto_Contrato,
                FechaInicio_Contrato = contrato1.FechaInicio_Contrato,
                FechaFin_Contrato = contrato1.FechaFin_Contrato,
                FKId_TipoContrato_Contrato = contrato1.Id_TipoContrato,
                FKId_Empleado_Contrato = idempleado,
                FKId_Cargo_Contrato = contrato1.Id_Cargo,
                FKId_Turno_Contrato = contrato1.Id_Turno,
                Activo_Contrato = true
            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.Contrato.Add(contrato2);
                db.SaveChanges();
            }

            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.Contrato
                .First(p => p.FKId_Empleado_Contrato == idempleado && p.Activo_Contrato == true );
                origen.Activo_Contrato = false;
                db.SaveChanges();
            }


        }


        public ContratoCE ObtenerDetalleContrato(int idcontrato)
        {

            string sql = @"select e.Id_Empleado,e.FKId_Departamento_Empleado,e.FKId_Persona_Empleado,p.Id_Persona,p.Nombre_Persona+' '+p.Apellido1_Persona+' '+p.Apellido2_Persona as NombreCompletoPersona, 
				c.Id_Contrato, c.SalarioBruto_Contrato, c.FKId_TipoContrato_Contrato,c.FKId_Empleado_Contrato, c.FKId_Cargo_Contrato,c.FechaInicio_Contrato,c.FechaFin_Contrato,c.Activo_Contrato,
				tc.Id_TipoContrato,tc.Detalle_TipoContrato,ca.Id_Cargo,ca.Nombre_Cargo,c.FKId_Turno_Contrato, t.Id_Turno,t.Nombre_Turno
                from Contrato c  
                inner join Empleado e on c.FKId_Empleado_Contrato = e.Id_Empleado
				inner join TipoContrato tc on c.FKId_TipoContrato_Contrato = tc.Id_TipoContrato
				inner join Cargo ca on c.FKId_Cargo_Contrato = ca.Id_Cargo
				inner join Persona p on e.FKId_Persona_Empleado = p.Id_Persona
				inner join Turnos t on c.FKId_Turno_Contrato = t.Id_Turno
                where c.Activo_Contrato = 1 and e.Activo_Empleado = 1 and c.Id_Contrato=@Cod_Contrato";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<ContratoCE>(sql, new SqlParameter("@Cod_Contrato", idcontrato)).FirstOrDefault();
            }

        }


        public void Editar(ContratoCE contrato)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.Contrato.Find(contrato.Id_Contrato);
                origen.SalarioBruto_Contrato = contrato.SalarioBruto_Contrato;
                origen.FKId_Cargo_Contrato = contrato.Id_Cargo;
                origen.FKId_Turno_Contrato = contrato.Id_Turno;
                db.SaveChanges();
            }
        }

        //public void EditarActivo(ContratoCE contrato)
        //{
        //    using (var db = new RecursosHumanosDBContext())
        //    {
        //        var idempleado = ObtenerIdEmpleado(contrato1.Id_Persona);
        //        var origen = db.Contrato.Find(contrato.Id_Contrato);
        //        origen.Activo_Contrato = false;
        //        db.SaveChanges();
        //    }
        //}
    }
        
}