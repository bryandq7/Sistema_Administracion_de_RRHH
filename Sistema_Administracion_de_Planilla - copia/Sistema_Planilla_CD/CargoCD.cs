using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class CargoCD
    {
        public List<Cargo> ListarCargos()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                return db.Cargo.ToList();
            }
        }

        public List<EmpleadoCE> ListarCargos2()
        {
            string sql = @"select c.Id_Cargo, c.Nombre_Cargo, c.FechaActualizacion_Cargo
                        from Cargo c";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<EmpleadoCE>(sql).ToList();
            }
        }

        public void Crear(Cargo cargo)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                db.Cargo.Add(cargo);
                db.SaveChanges();
            }
        }

        public Cargo ObtenerCargo(int id)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                //return db.Cargo.Where(p => p.Id_Cargo == id).FirstOrDefault();
                return db.Cargo.Find(id);
            }
        }

        public void Editar(Cargo cargo)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.Cargo.Find(cargo.Id_Cargo);
                origen.Nombre_Cargo = cargo.Nombre_Cargo;
                origen.FechaActualizacion_Cargo = cargo.FechaActualizacion_Cargo;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var db = new RecursosHumanosDBContext())
            {

                var cargo = db.Cargo.Find(id);
                db.Cargo.Remove(cargo);
                db.SaveChanges();
            }

        }
    }
}
