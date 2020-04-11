using System.ComponentModel.DataAnnotations;

namespace AutoLotDAL.Models
{
    public partial class Order
    {
        [Key]
        public int Orderld { get; set; }

        public int Custld { get; set; }

        public int Carld { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual inventory Inventory { get; set; }
    }
}
