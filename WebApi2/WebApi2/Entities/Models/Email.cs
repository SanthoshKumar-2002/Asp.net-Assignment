﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities.Models
{
    public class Email
    {
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public Guid EmailId { get; set; }
        public string EmailAddress { get; set; }
        public Guid key { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdateBy { get; set; }
        public bool? IsActive { get; set; }
    }
}