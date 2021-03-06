using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_DATA_EF
{
    public class EnrollmentMetadata
    {
        [Required(ErrorMessage ="**Required**")]
        [Display(Name ="Student ID")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "**Required**")]
        [Display(Name = "Scheduled Class ID")]
        public int ScheduledClassId { get; set; }

        [Required(ErrorMessage = "**Required**")]
        [Display(Name = "Enrollment Date")]
        public System.DateTime EnrollmentDate { get; set; }
    }

    [MetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment
    {

    }
}
