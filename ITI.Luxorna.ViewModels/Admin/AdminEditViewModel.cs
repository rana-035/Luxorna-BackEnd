using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public class AdminEditViewModel
    {
        
        
        public int ID { get; set; }
        
        [MaxLength(100)]
        public string FirstName { get; set; }
        
        [MaxLength(100)]
        public string LastName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
       
        [MaxLength(100)]
        public string UserName { get; set; }
        
        [MaxLength(100)]
        public string Password { get; set; }
        
        [MaxLength(500)]
        public string Image { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; } = DateTime.Now;
   
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? CreateBy { get; set; }
        public int? UpdateBy { get; set; }
        public List<AdminRole> Roles{ get; set; }
    }
}
