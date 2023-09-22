using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation.Models
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

    }
}
