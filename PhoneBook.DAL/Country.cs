﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhoneBook.DAL
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int CuntryId { get; set; }

        [Display(Name = "Country Name")]
        [Required]
        public String CountryName { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual ICollection<State> States  { get; set; }



    }
}