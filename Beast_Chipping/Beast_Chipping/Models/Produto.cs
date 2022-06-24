using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beast_Chipping.Models
{
    public class Produto
    {

        public Produto()
        {
            Artigos = new HashSet<Artigo>();
            Fotos =  new List<Foto> { };
            Categorias = new HashSet<Categoria>();
          
        }

        [Key]
        public int Id { get; set; }                 //Id do produto

        public string Nome { get; set; }            //Nome do produto

        public string Descricao { get; set; }       //Descrição do produto

        public string Preco { get; set; }           //Preço do produto

        public string Especificacoes { get; set; }  //Especificações do produto  LISTA

        public DateTime DataCriacao { get; set; }   //Data de criação

        //public DateTime DataModificacao { get; set; }//Data de modificação
   
        public ICollection<Foto> Fotos { get; set; }

        public ICollection<Artigo> Artigos { get; set; }
    
        public ICollection<Categoria> Categorias { get; set; }


        //navigation property: configure one-t0-many relationship with Photo 
       
        //ligação muitos para muitos para Categorias


    }
}
