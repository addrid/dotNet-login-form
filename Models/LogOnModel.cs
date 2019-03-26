using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ukol9.Models
{
    public class LogOnModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(40, ErrorMessage = "{0} cannot be longer than {1} characters")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}