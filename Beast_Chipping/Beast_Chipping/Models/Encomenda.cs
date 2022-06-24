using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beast_Chipping.Models
{
    public class Encomenda
    {
        public Encomenda()
        {
            Artigo = new HashSet<Artigo>();
        }

        [Key]
        public int Id { get; set; }                 //ID da Encomenda

        public string Artigos { get; set; }         //Artigos

        public string Morada { get; set; }          //Morada

        public string DataEncomenda { get; set; }   //Data em que a encomenda foi realizada

        public string DataEnvio { get; set; }       //Data em que a encomenda foi enviada

        public decimal ValorTotal { get; set; }     //Valor Total da Encomenda


        //Ligacao entre a tabela 1 para Muitos
        [ForeignKey(nameof(Cliente))]  //  [ForeignKey("Cliente")]
        // public int ClienteFK { get; set; }
        public int IdCliente { get; set; }//este atributo e uma chave forasteira  para o Cliente
        public Cliente Cliente { get; set; }

   
        /// <summary>
        /// lista de artigos da encomenda
        /// </summary>
        public ICollection<Artigo> Artigo { get; set; }


    }
}
