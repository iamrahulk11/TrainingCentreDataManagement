using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingCentreDataManagement.Models
{
    [Table("faculty")]
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }

        [Required]
        [StringLength(50)]
        [MaxLength(50)]
        public string FacultyName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Batchname { get; set; }

    }
    public interface IFaculty
    {
        //display
        IEnumerable<Faculty> getdata(int bname);

        //insert
        void AddNewRecord(Faculty model, int id);
        //update
        void EditARecord(Faculty model);

        //delete
        void DeleteRecord(Faculty model);
        //search
        Faculty search(int id);
    }
}
