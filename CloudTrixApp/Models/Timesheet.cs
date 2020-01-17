using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace CloudTrixApp.Models
{
    [Table("Timesheet")]
    public class Timesheet
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        [Display(Name = "Timesheet I D")]
        public Int32 TimesheetID { get; set; }

        [Required]
        [Display(Name = "Employee I D")]
        public Int32 EmployeeID { get; set; }

        [Required]
        [Display(Name = "Project I D")]
        public Int32 ProjectID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [Required]
        [StringLength(8000)]
        [Display(Name = "Remarks")]
        public String Remarks { get; set; }

        // ComboBox
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }

    }
}
 
