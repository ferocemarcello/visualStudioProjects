using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamPractiseMVC.Models
{
    public class BlogPost
    {
        public BlogPost(int id, string title, string content, DateTime date, string author)
        {
            ID = id;Title = title;Content = content;CreateDate = date;Author = author;
        }
        [Required]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        
        public DateTime CreateDate { get; set; }
        [Display(Name ="Create Author Name")]
        public string Author { get; set; }
    }
}