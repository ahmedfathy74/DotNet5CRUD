﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5CRUD.Models
{
    public class Genre
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // this line in case type is byte otherwise will create idenetity by default
        public byte Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}
