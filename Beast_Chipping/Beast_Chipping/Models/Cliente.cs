using System.ComponentModel.DataAnnotations;

namespace Beast_Chipping.Models
{
    public class Cliente
    {
        public Cliente()
        {
            Encomendas = new HashSet<Encomenda>();
        }
        [Key]

        /// <summary>
        /// PK para a tabela dos Clientes
        /// </summary>
        public int IdCliente { get; set; }          //Id Cliente



        /// <summary>
        /// Nome do Cliente
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [StringLength(30, ErrorMessage = "O {0} não pode ter mais do que {1} carateres.")]
        [Display(Name = "Nome")]
        [RegularExpression("[A-ZÂÓÍa-záéíóúàèìòùâêîôûãõäëïöüñç '-]+", ErrorMessage = "Só pode escrever letras no {0}")]
        public string Nome { get; set; }            //Nome


        /// <summary>
        /// Número de Telemovel do Cliente
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} tem de ter 9 carateres.")]
        public string Telemovel { get; set; }       //Telemovel


        /// <summary>
        /// Email do Cliente
        /// </summary>
        [EmailAddress(ErrorMessage ="Escreva um {0} válido, pf.")]
        public string Email { get; set; }           //Email


        /// <summary>
        /// Número de IVA
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} tem de ter 9 carateres.")]
        [RegularExpression("[123578][0-9]{8}", ErrorMessage = "O {0} deve começar por 1,2,3,5,7,8 seguido de 8 digitos numéricos.")]
        public string NIF { get; set; }             //Email

        /// <summary>
        /// Morada
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        public string Morada { get; set; }          //Morada


        /// <summary>
        /// Código Postal
        /// </summary>
        //[RegularExpression("[123578][0-3]{4}", ErrorMessage = "O {0} deve começar por 1,2,3,5,7,8 seguido de 8 digitos numéricos.")]
        //[RegularExpression("[0-9]{1,4}[-]?[0-9]{0,3}", ErrorMessage = "")]
        public string CodigoPostal { get; set; }    //Codigo Postal


        /// <summary>
        /// Data de Criação do Cliente
        /// </summary>
        //formata a data em ano-mes-dia
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public string DataCriacao { get; set; }     //Data de Criação


        //RETIRAR DO MODELO???
        //public string DataModificacao { get; set; } //Data de Modificação



        /// <summary>
        /// conjunto de encomendas do cliente
        /// </summary>
        public ICollection<Encomenda> Encomendas { get; set; }

    }
}
