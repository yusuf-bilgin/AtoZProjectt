using System.ComponentModel.DataAnnotations;

namespace AtoZProjectApi.DAL.Entity
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
