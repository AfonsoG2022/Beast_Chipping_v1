using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beast_Chipping.Models
{
    public class Foto
    {
       

        public int Id { get; set; }

        
        [ForeignKey(nameof(Produto))]
        public int ProdutoFk { get; set; }
        public Produto Produto { get; set; }

        public string Ficheiro { get; set; }

        public string Descrição { get; set; }
    }
   
}
