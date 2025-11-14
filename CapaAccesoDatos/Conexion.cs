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
        // Patron de Diseño Singleton
        private static readonly Conexion _instancia = new Conexion();
        public static Conexion Instancia
        {
            get { return Conexion._instancia; }
        }

        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();

            // 🚀 CORRECCIÓN APLICADA: 
            // 1. Se eliminó el punto y coma (;) innecesario después de DBCocina.
            // 2. Se unificó toda la cadena de conexión en una sola expresión válida.
            cn.ConnectionString = "Data Source=DESKTOP-PK88VMC\\YENCI_RX;Initial Catalog=DBCocina;Integrated Security=true";

            return cn;
        }
    }
}
