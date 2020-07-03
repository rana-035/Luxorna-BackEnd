using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public class UserEditViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]

        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string UserName { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        public string CountryName { get; set; }
        public int CountryID { get; set; }
        public int RoleID { get; set; }
        public string Role { get; set; }



    }
}
