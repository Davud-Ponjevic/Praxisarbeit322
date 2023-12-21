namespace Praxisarbeit.Dto
{
    public class RegistrationDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PriorityId { get; set; }
        public int ServiceId { get; set; }

        public int? UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PickupDate { get; set; }
    }
}
