﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestBackend.Models
{
    public class Category
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}
