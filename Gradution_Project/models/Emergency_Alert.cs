using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gradution_Project.models
{
    public class Emergency_Alert
    {
        [Key]
        public int alert_id { get; set; }
        public int sender_id { get; set; }
        public int receiver_id{get;set;}
        public string alert_type { get; set; }
        public DateTime timestamp {  get; set; }
        [ForeignKey("sender_id")]
        public virtual User Sender { get; set; }

        [ForeignKey("receiver_id")]
        public virtual User Receiver { get; set; }


    }
}
