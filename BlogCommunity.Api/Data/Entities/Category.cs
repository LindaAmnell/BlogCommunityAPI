using System.ComponentModel.DataAnnotations;

namespace BlogCommunity.Api.Data.Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

    }
}
