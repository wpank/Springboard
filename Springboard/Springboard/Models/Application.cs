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
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string SeekerId { get; set; }

        public int JobPostingId { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOpen { get; set; }

        public bool Resolved { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual JobPosting JobPosting { get; set; }
    }
}
