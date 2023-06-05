using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace TrialLoginAndRegistrationWeb.Models
{
    public class Order
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Order_ID { get; set; }

        [ForeignKey("AspNetUsers")]
        public string Order_UserID { get; set; }
        
        [ForeignKey("Clothes")]
        public int Order_ClothesID { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime Order_RentDate { get; set; }
        public string Order_PhoneNumber { get; set; }
        public string Order_Comment { get; set; }
        public decimal Order_Sum { get; set; }
        public string Order_Perfomance { get; set; }
    }
}
