namespace Springboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JobPosting")]
    public partial class JobPosting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobPosting()
        {
            Applications = new HashSet<Application>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string JobDescription { get; set; }

        [Required]
        [StringLength(128)]
        public string PosterId { get; set; }

        public int CultureId { get; set; }

        public int SkillRequirementsId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Application> Applications { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Culture Culture { get; set; }

        public virtual SkillRequirement SkillRequirement { get; set; }
    }
}
