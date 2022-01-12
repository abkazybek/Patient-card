using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;


namespace EFSample.Model
{
   
    [Table("Patient", Schema = "Hospital")]
    public class Patient
    {
        [Display(Name = "ИИН Пациента")]
        public int PatientId { get; set; }

        [Required]
        [Display(Name = "ИИН")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "ФИО пациента")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Сотовый номер")]
        public string PhoneNumber { get; set; }

        public virtual List<Disease> Diseases { get; set; }


    }

    [Table("История пациента", Schema = "Hospital")]

    public class Doctor
    {
        [Display(Name = "ФИО доктора")]
        public int DoctorID { get; set; }

        [Required]
        [Display(Name = "Специализация")]
        public string doctor { get; set; }

        [Required]
        [Display(Name = "ФИО врача")]
        public string NameofDoctor { get; set; }



    }

    public class Disease
    {
        [Key]
        public int PatientId { get; set; }

        [Key]
        public int DoctorID { get; set; }

        [Required]
        [Display(Name = "Диагноз")]
        public string Diagnosis { get; set; }

        [Required]
        [Display(Name = "Жалоба")]
        public string Complaint { get; set; }

        [Required]
        [Display(Name = "Дата")]


        public string Date { get; set; }

        [Display(Name = "Пациент")]
        public Patient patient { get; set; }

        [Display(Name = "Доктор")]
        public Doctor doctor { get; set; }

    }

}
