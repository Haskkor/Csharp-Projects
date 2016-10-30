using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestMVCScaffold.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("StatusId")]
        public virtual int StatusId { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
   
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string Name { get; set; }
    }
   
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        public string Description { get; set; }
        public int? TaskId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}