﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.DAL
{
    public class State
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int SateId { get; set; }

        [Display(Name = "State Name")]
        [Required]
        public String StateName { get; set; }

        public bool IsActive { get; set; } = true;


        [Required]
        [Display(Name = "Country")]
        [ForeignKey("Country")]
        public int CountryId { get; set; }


        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }


    }
}