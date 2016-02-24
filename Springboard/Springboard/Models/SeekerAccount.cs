namespace Springboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SeekerAccount")]
    public partial class SeekerAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SeekerAccount()
        {
            Users = new HashSet<ApplicationUser>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        //[Required]
        //[StringLength(128)]
        //public string AccountId { get; set; }

        //public int CultureId { get; set; }

        //public int SkillsId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationUser> Users { get; set; }

        //public virtual ApplicationUser User { get; set; }

        public Culture Culture { get; set; }

        public Skill Skill { get; set; }
    }
}
