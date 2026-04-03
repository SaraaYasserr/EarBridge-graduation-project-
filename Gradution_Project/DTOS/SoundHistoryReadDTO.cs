namespace Gradution_Project.DTOS
{
    public class SoundHistoryReadDTO
    {
        public int LogId { get; set; }
        public string SoundLabel { get; set; }
        public string Confidence { get; set; }
        public DateTime Timestamp { get; set; }
        public string Username { get; set; }
    }
}
