using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class Conexion
    {
            //patron de Diseño Singleton
            private static readonly Conexion _instancia = new Conexion();
            public static Conexion Instancia
            {
                get { return Conexion._instancia; }
            }

            public SqlConnection Conectar()
            {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=DESKTOP-PK88VMC\\YENCI_RX; Initial Catalog = DBCocina;" +//"User ID=sa; Password = 8421";
            "Integrated Security=true";
            return cn;
            }
    }
}
