﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationService.Models
{
    public class AuthenticationInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsThirdPartyAccount { get; set; }
        public string Role { get; set; } // Khai bao danh muc cho value nay
        public string ValidateString { get; set; }
        public bool IsValidated { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiredDate { get; set; }
    }
}