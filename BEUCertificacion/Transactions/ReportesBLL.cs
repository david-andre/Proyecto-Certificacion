using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUCertificacion.Transactions
{
    public class ReportesBLL
    {
        public static List<GetDetallesByMonth_Result> GetPedidosByMonth(int idUsuario, int month, int year)
        {
            Entities db = new Entities();
            return db.GetDetallesByMonth(idUsuario,month,year).ToList();
        }

        public static List<GetDetallesEmpresasByMonth_Result> GetPedidosByEmpresa(int idUsuario, int month, int year)
        {
            Entities db = new Entities();
            return db.GetDetallesEmpresasByMonth(idUsuario, month, year).ToList();
        }

        public static List<GetMontoByServicio_Result> GetMontosByServicio(int idUsuario)
        {
            Entities db = new Entities();
            return db.GetMontoByServicio(idUsuario).ToList();
        }

        public static List<reportePrueba_Result> GetReportePrueba(int idUsuario, int month, int year)
        {
            Entities db = new Entities();
            return db.reportePrueba(idUsuario, month, year).ToList();
        }
    }
}
