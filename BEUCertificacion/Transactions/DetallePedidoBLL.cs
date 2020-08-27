using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUCertificacion.Transactions
{
    public class DetallePedidoBLL
    {
        public static DetallePedido Get(int? id)
        {
            Entities db = new Entities();
            return db.DetallePedidoes.Find(id);
        }

        public static void Create(DetallePedido dp)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        int ultimoPedido = PedidoBLL.List().Select(x => x.idpedido).Max();
                        dp.idpedido = ultimoPedido;
                        db.DetallePedidoes.Add(dp);
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

        public static List<DetallePedido> List()
        {
            Entities db = new Entities();
            return db.DetallePedidoes.ToList();
        }

        public static List<DetallePedido> List(int id)
        {
            Entities db = new Entities();
            return db.DetallePedidoes.Where(x => x.idpedido == id).ToList();
        }

    }
}
