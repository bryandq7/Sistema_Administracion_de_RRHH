using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class BancoCD
    {
        public List<Banco> ListarBancos()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Banco.ToList();
            }
        }

        public void Crear(Banco banco)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                db.Banco.Add(banco);
                db.SaveChanges();
            }
        }

        public Banco ObtenerBanco(int id)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                //return db.Banco.Where(p => p.Id_Banco == id).FirstOrDefault();
                return db.Banco.Find(id);
            }
        }

        public void Editar(Banco banco)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.Banco.Find(banco.Id_Banco);
                origen.Nombre_Banco = banco.Nombre_Banco;
                origen.FechaActualizacion_Banco = banco.FechaActualizacion_Banco;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var db = new RecursosHumanosDBContext())
            {

                var banco = db.Banco.Find(id);
                db.Banco.Remove(banco);
                db.SaveChanges();
            }

        }
    }
}
