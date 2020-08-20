using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonsModels
{
    [Table("Person")]
    public class Person
    { 
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public DateTime? DoB { set; get; }
        public string Email { set; get; }
    }
}
