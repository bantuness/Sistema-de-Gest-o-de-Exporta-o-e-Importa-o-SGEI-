using System.ComponentModel.DataAnnotations;

namespace SGEI_App.Models
{     public class Cliente
    {
        [Key]
        public int ID_CLIENTE { get; set; }
        public string NOME { get; set; }
        public string CNPJ_CPF { get; set; }
        public string PAIS { get; set; }
    }


}

