namespace Managing_Teacher_Work.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReportMonth")]
    public partial class ReportMonth
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string ClassName { get; set; }

        public DateTime Date { get; set; }

        public string Files { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
