using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNet.ApplicationCore.DTOs.Common
{
    public class QueryObject
    {
        [Key]
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Designation { get; set; }
        public int AccessRight { get; set; }
        public string BPNumber { get; set; }
        public int AppliedPost { get; set; }
        public int UserID { get; set; }
        public int UnitID { get; set; }
        public string ApplicantName { get; set; }
        public int SessionID { get; set; }
       
    }
}
