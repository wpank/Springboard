namespace Springboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Skill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Skill()
        {
            SeekerAccounts = new HashSet<SeekerAccount>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "AI")]
        public int AI_Rank { get; set; }

        public int AI_Conf { get; set; }

        [Display(Name = "Algorithms")]
        public int Algo_Rank { get; set; }

        public int Algo_Conf { get; set; }

        public int BusAnalysis_Rank { get; set; }

        public int BusAnalysis_Conf { get; set; }

        public int Database_Rank { get; set; }

        public int Database_Conf { get; set; }

        public int Debug_Rank { get; set; }

        public int Debug_Conf { get; set; }

        public int GameProgramming_Rank { get; set; }

        public int GameProgramming_Conf { get; set; }

        public int MobileDev_Rank { get; set; }

        public int MobileDev_Conf { get; set; }

        public int OS_Rank { get; set; }

        public int OS_Conf { get; set; }

        [Display(Name = "C++")]
        public int Cpp_Rank { get; set; }

        public int Cpp_Conf { get; set; }

        public int Java_Rank { get; set; }

        public int Java_Conf { get; set; }

        public int Python_Rank { get; set; }

        public int Python_Conf { get; set; }

        public int Script_Rank { get; set; }

        public int Script_Conf { get; set; }

        public int ProjectMan_Rank { get; set; }

        public int ProjectMan_Conf { get; set; }

        public int SysArch_Rank { get; set; }

        public int SysArch_Conf { get; set; }

        public int SysDes_Rank { get; set; }

        public int SysDes_Conf { get; set; }

        public int SysInt_Rank { get; set; }

        public int SysInt_Conf { get; set; }

        public int TechWriting_Rank { get; set; }

        public int TechWriting_Conf { get; set; }

        public int UI_Rank { get; set; }

        public int UI_Conf { get; set; }

        public int WebDev_Rank { get; set; }

        public int WebDev_Conf { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeekerAccount> SeekerAccounts { get; set; }
    }
}
