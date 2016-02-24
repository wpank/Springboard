namespace Springboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Culture")]
    public partial class Culture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Culture()
        {
            JobPostings = new HashSet<JobPosting>();
            SeekerAccounts = new HashSet<SeekerAccount>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public int Accurate { get; set; }

        public int Analytical { get; set; }

        public int Creative { get; set; }

        public int Efficient { get; set; }

        public int FlexibleScheduling { get; set; }

        public int GoodListener { get; set; }

        public int LikeFastPace { get; set; }

        public int Logical { get; set; }

        public int MultiTasker { get; set; }

        public int OralCommunicator { get; set; }

        public int PeopleSkills { get; set; }

        public int Planner { get; set; }

        public int Punctual { get; set; }

        public int RealtionshipBuilder { get; set; }

        public int Researcher { get; set; }

        public int Stamina { get; set; }

        public int TeacherMentor { get; set; }

        public int TeamLeader { get; set; }

        public int TeamMentor { get; set; }

        public int UXUI { get; set; }

        public int WrittenCommunicator { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobPosting> JobPostings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeekerAccount> SeekerAccounts { get; set; }
    }
}
