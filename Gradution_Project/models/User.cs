using System.ComponentModel.DataAnnotations;

namespace Gradution_Project.models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string role { get; set; }

        public User_Preference User_Preferences { get; set; }
        public ICollection<Pairing> DeafPairings { get; set; }
        public ICollection<Pairing> CompanionPairings { get; set; }
        public ICollection<Sound_History> Sound_History { get; set; }
        public virtual ICollection<Emergency_Alert> SentAlerts { get; set; }
        public virtual ICollection<Emergency_Alert> ReceivedAlerts { get; set; }
    }
}