﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmin.API.Data_Models
{
    public class Address
    {
        public Guid Id { get; set; }

        public string  PhysicalAddress  { get; set; }

        public string PostalAddress { get; set; }

        // Navigation Property

        public Guid StudentId { get; set; }
    }
}
