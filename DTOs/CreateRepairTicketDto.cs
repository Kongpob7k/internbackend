using System.ComponentModel.DataAnnotations;

namespace RepairRequestApi.DTOs
{
    public class CreateRepairTicketDto
    {
        [Required]
        public string Title { get; set; } = "";

        [Required]
        public string Description { get; set; } = "";

        public string Priority { get; set; } = "Medium";
    }
}
