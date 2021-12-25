using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        
        public string AuthorName { get; set; }
    
        public string AuthorImage { get; set; }
        
        public string AuthorAbout { get; set; }
      
        public string AuthorTitle { get; set; }
    
        public string AboutShort { get; set; }
     
        public string Mail { get; set; }
 
        public string Password { get; set; }
      
        public string PhoneNumber { get; set; }
        // public int RoleID { get; set; }
       // public virtual Role Role { get; set; }
    }
}
