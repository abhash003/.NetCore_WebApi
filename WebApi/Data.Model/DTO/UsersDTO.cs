﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.DTO
{
    public class UsersDTO
    {
        public string Name { get; set; }

        public string EmailId { get; set; }

        public string PhoneNo { get; set; }

        public string Password { get; set; }

        public List<string> Roles { get; set; }
    }
}
