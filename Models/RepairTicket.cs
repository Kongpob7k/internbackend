namespace RepairRequestApi.Models
{
    public class RepairTicket
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";

        public string Description { get; set; } = "";

        public string Status { get; set; } = "Pending";

        public string Priority { get; set; } = "Medium";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }
    }
}
