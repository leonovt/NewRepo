﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KanBan_2024.ServiceLayer
{
    public class UserSL
    {
        public string email{  get; set; }
        public UserSL(string email)
        {
            this.email = email;
        }
    }
}
