namespace Springboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Application")]
    public partial class Application
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOpen { get; set; }

        public bool Resolved { get; set; }

        public string  UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Guid? JobPostingId { get; set; }
        public virtual JobPosting JobPosting { get; set; }
    }
}
