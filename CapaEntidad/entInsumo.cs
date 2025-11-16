using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entInsumo
    {
        public int idInsumo { get; set; }         
        public string nombreInsumo { get; set; }   
        public string unidadMedida { get; set; }   
        public decimal cantidad { get; set; }     
        public decimal precioUnitario { get; set; } 
        public bool estInsumo { get; set; }       
        public DateTime fecRegistro { get; set; }
        // --- NUEVO CAMPO ---
        public int IdCategoria { get; set; }
        // Opcional: Para mostrar el nombre en el DGV sin unir tablas en la App
        public string NombreCategoria { get; set; }
    }
}
