using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LFIDentalClinic.Models
{
    [MetadataType(typeof(PatientMetadata))]
    public partial class Patient { }
    public class PatientMetadata
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(50, ErrorMessage = "Email is too long.")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email is in incorrect format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [StringLength(10, ErrorMessage = "Gender is too long.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        [StringLength(10, ErrorMessage = "Birth date is too long.")]
        [DataType(DataType.Date)]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        [StringLength(10, ErrorMessage = "Birth date is too long.")]
        public string MaritalStatus { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(11, ErrorMessage = "Mobile number is too long.")]
        public string MobileNumber { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(11, ErrorMessage = "Telephone number is too long.")]
        public string TelephoneNumber { get; set; }

        public bool Palate { get; set; }

        public bool BadBreath { get; set; }

        public bool BleedingInMouth { get; set; }
        
        public bool GumsColorChange { get; set; }
        
        public bool LumpsInMouth { get; set; }
        
        public bool TeethColorChange { get; set; }
        
        public bool SensitiveTeeth { get; set; }
        
        public bool ClickingSound { get; set; }
        
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(500, ErrorMessage = "Past dental care or treatments is too long.")]
        public string PastDentalCareOrTreatments { get; set; }
        
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(500, ErrorMessage = "Heart ailment or disease is too long.")]
        public string HeartAilmentOrDisease { get; set; }
        
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(500, ErrorMessage = "Hospital admission is too long.")]
        public string HospitalAdmission { get; set; }
        
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(500, ErrorMessage = "Self-medication is too long.")]
        public string SelfMedication { get; set; }
        
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(500, ErrorMessage = "Allergies is too long.")]
        public string Allergies { get; set; }
        
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(500, ErrorMessage = "Operation is too long.")]
        public string Operation { get; set; }
        
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(500, ErrorMessage = "Tumors or growth is too long.")]
        public string TumorsOrGrowth { get; set; }
        
        public bool Diabetes { get; set; }
        
        public bool Sinusitis { get; set; }
        
        public bool BleedingGums { get; set; }
        
        public bool Hypertension { get; set; }
        
        public bool StomachDisease { get; set; }
        
        public bool BloodDisease { get; set; }
        
        public bool Headache { get; set; }
        
        public bool LiverDisease { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(500, ErrorMessage = "Pregnant is too long.")]
        public string Pregnant { get; set; }

        public bool Cold { get; set; }

        public bool Kidney { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(500, ErrorMessage = "Family history is too long.")]
        public string FamilyHistryOnAny { get; set; }
    }
}