using System.ComponentModel.DataAnnotations.Schema;

namespace Beast_Chipping.Models
{
    public class Categoria
    {
        //public Categoria()
        //{
        //     Produtos = new HashSet<Produto>();
        // }

        public int Id { get; set; }                        //Id do produto

        public string NomeCategoria { get; set; }          //Nome da categoria

        // [ForeignKey(nameof(Produto))]                      //chave do produto
        // public int ProdutoFK { get; set; }
        // public Produto Produto { get; set; }

        public string Ficheiro { get; set; }                    //foto da categoria

        public ICollection<Produto> Produtos { get; set; }  //produtos que da mesma categoria

        //ligação muitos para muitos para produtos

    }
}