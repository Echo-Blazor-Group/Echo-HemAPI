﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Echo_HemAPI.Data.Models
{
    /// <summary>
    /// Author: Samed Salman
    /// </summary>
    public class RealtorFirm
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, DisplayName("About this firm")]
        public string RealtorFirmPresentation { get; set; } = string.Empty;
        public string? Logotype { get; set; }
        public bool Active { get; set; } = true;
    }
}
