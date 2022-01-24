﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EtheReal.ViewModels
{
    public class VmLogin
    {
        [MaxLength(50),Required]
        //[DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [MaxLength(50), Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
