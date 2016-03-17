namespace Springboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class SkillRequirement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SkillRequirement()
        {
            JobPostings = new HashSet<JobPosting>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public int? AI { get; set; }

        public int? Algorithms { get; set; }

        public int? BusAnalysis { get; set; }

        public int? Database { get; set; }

        public int? Debugging { get; set; }

        public int? GameProgramming { get; set; }

        public int? MobileDev { get; set; }

        public int? OS { get; set; }

        public int? Cpp { get; set; }

        public int? Java { get; set; }

        public int? Python { get; set; }

        public int? Script { get; set; }

        public int? ProjectMan { get; set; }

        public int? SysArch { get; set; }

        public int? SysDes { get; set; }

        public int? SysInt { get; set; }

        public int? TechWritting { get; set; }

        public int? UI { get; set; }

        public int? WebDev { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobPosting> JobPostings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeekerAccount> SeekerAccounts { get; set; }

        public int MapSize
        {
            get
            {
                return Convert.ToInt16((from s in this.GetType().GetProperties()
                                        where s.PropertyType.Equals(typeof(int?))
                                        select s).Count());
            }
        }

        public double[] Map
        {
            get
            {
                int size = MapSize;
                List<double> listMap = new List<double>();
                foreach (var prop in this.GetType().GetProperties())
                {
                    if (prop.PropertyType.Equals(typeof(int?)))
                    {
                        object val = prop.GetValue(this);
                        if (val != null)
                        {
                            listMap.Add((int)val);
                        }
                        else
                        {
                            listMap.Add(size);
                        }
                    }
                }
                return listMap.ToArray();
            }
        }
    }
}
