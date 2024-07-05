namespace Managing_Teacher_Work.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Teacher")]
    public partial class Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher()
        {
            Class = new HashSet<Class>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string Name_Teacher { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        [StringLength(255)]
        public string Avatar { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        public bool? IsDelete { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public int SicenceID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Class> Class { get; set; }

        public virtual Science Science { get; set; }
    }
}
