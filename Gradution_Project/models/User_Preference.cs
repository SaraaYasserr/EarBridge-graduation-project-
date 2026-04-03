using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gradution_Project.models
{
    public class User_Preference
    {
        [Key]
        public int pref_id {  get; set; }
        public int user_id {  get; set; }
        public bool vibration_enabled {  get; set; }
        public bool flash_enabled { get; set; }

        [ForeignKey("user_id")]
        public User Users { get; set; }


    }
}
