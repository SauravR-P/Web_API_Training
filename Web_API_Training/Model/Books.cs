using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_Training.Model
{
    public class Books
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Book_Name { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

    }
}
   
