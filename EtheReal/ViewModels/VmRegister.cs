﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EtheReal.ViewModels
{
    public class VmRegister
    {
        [MaxLength(50),MinLength(3)]
        public string UserName { get; set; }
        [MaxLength(50), MinLength(3)]
        public string FullName { get; set; }

        [MaxLength(100), Required]
        public string Email { get; set; }

        [MaxLength(50),Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [MaxLength(50), Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]

        public string RePassword { get; set; }

    }
}
