﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PhoneBook.DAL
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int CityId { get; set; }

        [Display(Name = "City Name")]
        [Required]
        public String CityName { get; set; } 
        public bool IsActive { get; set; } = true;


        [Required]
        [Display(Name = "State Name")]
        [ForeignKey("State")]
        public int StateId { get; set; }

        public virtual State State { get; set; }


    }
}