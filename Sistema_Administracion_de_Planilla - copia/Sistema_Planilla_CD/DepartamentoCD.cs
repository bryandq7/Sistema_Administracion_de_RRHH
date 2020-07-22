using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class DepartamentoCD
    {

        public List<Departamento> ListarDepartamentos()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                return db.Departamento.ToList();
            }
        }

        public List<DepartamentoCE> ListarDepartamentos2()
        {
            string sql = @"select d.Id_Departamento, d.Nombre_Departamento, d.FechaActualizacion_Departamento
                        from Departamento d";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<DepartamentoCE>(sql).ToList();
            }
        }

        public void Crear(Departamento departamento)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                db.Departamento.Add(departamento);
                db.SaveChanges();
            }
        }

        public Departamento ObtenerDepartamento(int id)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                //return db.Departamento.Where(p => p.Id_Departamento == id).FirstOrDefault();
                return db.Departamento.Find(id);
            }
        }

        public void Editar(Departamento departamento)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.Departamento.Find(departamento.Id_Departamento);
                origen.Nombre_Departamento = departamento.Nombre_Departamento;
                origen.FechaActualizacion_Departamento = departamento.FechaActualizacion_Departamento;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var db = new RecursosHumanosDBContext())
            {

                var departamento = db.Departamento.Find(id);
                db.Departamento.Remove(departamento);
                db.SaveChanges();
            }

        }
    }




}
