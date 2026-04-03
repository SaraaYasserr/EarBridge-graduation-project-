using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gradution_Project.models;

public class Pairing
{
    [Key]
    public int pairing_id { get; set; }

    public int deaf_user_id { get; set; }

    [ForeignKey("deaf_user_id")] 
    public virtual User DeafUser { get; set; }

    public int compainin_id { get; set; }

    [ForeignKey("compainin_id")] 
    public virtual User Companion { get; set; }

    public string pairing_code { get; set; }
    public string status { get; set; }
}