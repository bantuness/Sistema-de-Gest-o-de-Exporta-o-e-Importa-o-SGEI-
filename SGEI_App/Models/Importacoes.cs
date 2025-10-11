using System;
using System.ComponentModel.DataAnnotations;

namespace SGEI_App.Models
{
    public class Importacoes
    {
        [Key]
        public int ID_IMPORTACAO { get; set; }
        public int ID_CLIENTE { get; set; }
        public DateTime DATA_IMPORTACAO { get; set; }
        public string PORTO_ORIGEM { get; set; }
        public string SITUACAO { get; set; }
        public string TIPO { get; set; }
    }
}
