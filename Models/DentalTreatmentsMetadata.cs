using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LFIDentalClinic.Models
{
    [MetadataType(typeof(DentalTreatmentsMetadata))]
    public partial class DentalTreatment { }
    public class DentalTreatmentsMetadata
    {
        [Display(Name = "Patient ID")]
        [Required(ErrorMessage = "Patient ID is required.")]
        public int PatientId { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [StringLength(10, ErrorMessage = "Date is too long.")]
        [Required(ErrorMessage = "Date is required.")]
        public string CreatedDate { get; set; }

        [Display(Name = "Service")]
        [Required(ErrorMessage = "Service is required.")]
        [StringLength(50, ErrorMessage = "Service is too long.")]
        public string Service { get; set; }

        [Display(Name = "Procedure Details")]
        [DataType(DataType.MultilineText)]
        [StringLength(3000, ErrorMessage = "Procedure details is too long.")]
        [Required(ErrorMessage = "Procedure details is required.")]
        public string ProcedureDetails { get; set; }
    }
}