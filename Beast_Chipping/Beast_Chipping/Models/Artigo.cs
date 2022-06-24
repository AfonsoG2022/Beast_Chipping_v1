using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beast_Chipping.Models
{
    public class Artigo
    {

        [Key]
        public int numeroSerie { get; set; }        //Número de serie do artigo

        public string Cor { get; set; }             //Cor do artigo

        public Boolean Vendido { get; set; }        //Artigo vendido 

       
        [ForeignKey(nameof(Produto))]
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }



    }
}
