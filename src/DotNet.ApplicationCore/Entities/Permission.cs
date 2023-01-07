using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNet.ApplicationCore.Entities
{
    [Table("Permissions")]
    public class Permission
    {
        [Key]
        public int PermissionID { get; set; }
        public string PermissionName { get; set; }
        public string DisplayName { get; set; }
        public int MenuGroupID { get; set; }
        public int? ParentPermissionID { get; set; }
        public bool IsActive { get; set; }
        public string IconName { get; set; }
        public string RoutePath { get; set; }
        public int PermissionType { get; set; }
        public int OrderNo { get; set; }
        public int OrganizationID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
