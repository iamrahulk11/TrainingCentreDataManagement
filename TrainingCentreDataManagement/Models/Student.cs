using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace TrainingCentreDataManagement.Models
{
    [Table("student")]
    public class Student
    {
        [Key]
        public int Studentid { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }
        
        [Required]
        [StringLength(10)]
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "School/College")]
        public string SC { get; set; }

        [Required]
        public string Batchname { get; set; }
    }
    interface Istudent
    {
        //display
        IEnumerable<Student> getdata(int id);

        //insert
        void AddNewRecord(Student sViewModel,int id);
        //update
        void EditARecord(Student sViewModel);

        //delete
        void DeleteRecord(Student sViewModel);
        
    }
}
