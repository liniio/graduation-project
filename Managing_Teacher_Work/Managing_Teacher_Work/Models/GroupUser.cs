namespace Managing_Teacher_Work.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupUser")]
    public partial class GroupUser
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(255)]
        public string Name_GroupUser { get; set; }

        [StringLength(10)]
        public string CodeRole { get; set; }
    }
}
