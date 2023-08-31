using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATV_2.Models
{
    public class PacotesTuristicos
    {
        public int IdPacotes { get; set; }
        public string Nome { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public string Atrativos { get; set; }
        public DateTime Saida { get; set; }
        public DateTime Retorno { get; set; }

        
        public int Usuario { get; set; }
        
        public Usuario UsuarioProprietario { get; set; }

        public int IdPacoteFavorito { get; set; }
    
        public PacotesTuristicos PacoteFavorito { get; set; }

    }
}
