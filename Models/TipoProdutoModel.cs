using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation.Models
{

    [Table("TipoProduto")]
    public class TipoProdutoModel
    {

        //[Column("NM_TIPO")]
        [Required(ErrorMessage = "O nome para o tipo do produto é obrigatório")]
        [StringLength(55)]
        [MinLength(3)]
        [Display(Name = "Nome do Tipo de Produto")]
        public string Nome { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoProdutoId { get; set; }

        [StringLength(256)]
        public string? Descricao { get; set; }



        [NotMapped]
        public string? Token {  get; set; }
    }
}
