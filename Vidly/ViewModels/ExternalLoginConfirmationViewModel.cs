﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Phone")]
        public string PhoneNo { get; set; }
    }
}