using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace stvsystem.Data
{
    public class PasswordItem
    {
        [Required]
        public string Password { get; set; }
        public PasswordStatus Status { get; set; }
    }
}
