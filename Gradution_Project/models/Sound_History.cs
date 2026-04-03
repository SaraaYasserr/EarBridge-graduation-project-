using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gradution_Project.models
{
    public class Sound_History
    {
        [Key]
        public int log_id {  get; set; }
        public int user_id {  get; set; }
        public  string sound_label {  get; set; }
        public string confidence { get; set; }
        public DateTime timestamp { get; set; }

        [ForeignKey("user_id")]
        public User Users { get; set; }

    }
}
