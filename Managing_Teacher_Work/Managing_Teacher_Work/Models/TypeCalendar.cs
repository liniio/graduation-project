namespace Managing_Teacher_Work.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypeCalendar")]
    public partial class TypeCalendar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeCalendar()
        {
            CalendarWorking = new HashSet<CalendarWorking>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string TypeName { get; set; }

        [StringLength(255)]
        public string TypeDescription { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CalendarWorking> CalendarWorking { get; set; }
    }
}
