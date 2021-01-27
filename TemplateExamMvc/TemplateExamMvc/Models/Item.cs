using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TemplateExamMvc.Models
{
    public class Item
    {
        [Required]
        public int ItemNumber { get; set; }
        public Item(int im)
        {
            ItemNumber = im;
        }
    }
}