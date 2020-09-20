using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BEUCertificacion.Transactions
{
    public class EmpresaBLL
    {
        public static Empresa Get(int? id)
        {
            Entities db = new Entities();
            return db.Empresas.Find(id);
        }

        public static void Create(Empresa e)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Empresas.Add(e);
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

        public static void Update(Empresa e)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Empresas.Attach(e);
                        db.Entry(e).State = System.Data.Entity.EntityState.Modified;
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
                        Empresa e = db.Empresas.Find(id);
                        db.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                        foreach(Servicio s in db.Servicios.ToList())
                        {
                            if (s.idempresa == id)
                            {
                                db.Entry(s).State = System.Data.Entity.EntityState.Deleted;
                            }
                        }
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

        public static List<Empresa> List()
        {
            Entities db = new Entities();
            return db.Empresas.ToList();
        }

        public static List<Empresa> ListByUser(int id)
        {
            Entities db = new Entities();
            return db.Empresas.Where(x => x.idusuario == id).ToList();
        }
    }
}
