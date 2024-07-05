namespace Managing_Teacher_Work.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Files
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public string FileForm { get; set; }
    }
}
