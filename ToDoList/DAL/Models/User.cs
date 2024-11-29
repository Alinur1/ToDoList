using System.ComponentModel.DataAnnotations;

namespace ToDoList.DAL.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [StringLength(200)]
        public string? username { get; set; }
        [StringLength(200)]
        public string? full_name { get; set; }
        [StringLength(200)]
        public string? password { get; set; }
        [EmailAddress]
        public string? email { get; set; }
    }
}
