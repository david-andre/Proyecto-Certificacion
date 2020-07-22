using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUCertificacion.Transactions
{
    public class ServicioBLL
    {
        public static Servicio Get(int? id)
        {
            Entities db = new Entities();
            return db.Servicios.Find(id);
        }
        public static void Create(Servicio s)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Servicios.Add(s);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Update(Servicio s)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Servicios.Attach(s);
                        db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Servicio s = db.Servicios.Find(id);
                        db.Entry(s).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<Servicio> List()
        {
            Entities db = new Entities(); 
            return db.Servicios.ToList(); 
        }
        public static List<Servicio> ListToNames()
        {
            {
                Entities db = new Entities();
                List<Servicio> resultado = new List<Servicio>();
                db.Servicios.ToList().ForEach(x => resultado.Add(new Servicio { nombre = x.nombre + " - " + x.Empresa.nombre, idservicio = x.idservicio }));
                return resultado;
            }
        }
    }
}
