using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Users
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [DisplayName("First name")]
        [Required(ErrorMessage = "First name is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required(ErrorMessage = "Last name is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [DisplayName("Email address")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid email address")]
        [Required(ErrorMessage = "Email address is required")]
        [Column(TypeName = "nvarchar(256)")]
        public string Email { get; set; }

        [Column(TypeName = "datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime JoinnedDate { get; set; }
    }
}
