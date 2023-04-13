using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingCentreDataManagement.Models
{
    [Table("batch")]
    public class Batch
    {
        [Key]
        public int BatchId { get; set; }

        [Required]
        [Display(Name ="Batch")]
        public string? Batchname { get; set; }
        
        
    }
    interface IBatch
    {
        //display
        IEnumerable<Batch> getdata();

        //insert
        void AddNewRecord(Batch model);
        //update
        void EditARecord(int id,Batch model);

        //delete
        void DeleteRecord(Batch id);

        Batch search(int id);

    }
}
