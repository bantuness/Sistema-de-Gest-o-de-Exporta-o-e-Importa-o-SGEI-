using System.ComponentModel.DataAnnotations;

namespace SGEI_App.Models
{
   public class Produtos
    {
        [Key]
        public int ID_PRODUTO { get; set; }
        public string DESCRICAO { get; set; }
        public string CATEGORIA { get; set; }
        public decimal PESO { get; set; }
        public decimal VALORUNITARIO { get; set; }  

    }
}
