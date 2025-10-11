using System;
using System.ComponentModel.DataAnnotations;

namespace SGEI_App.Models
{
    public class Exportacoes
    {
        [Key]
        public int ID_EXPORTACAO { get; set; }
        public int ID_CLIENTE {  get; set; }
        public DateTime DATA_EXPORTACAO { get; set; }
        public string PORTO_DESTINO { get; set; }
        public string SITUACAO { get; set; }
        public string TIPO { get; set; }

    }
}
