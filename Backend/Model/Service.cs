using System.ComponentModel.DataAnnotations;

namespace Praxisarbeit.Model
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        public string Beschreibung{ get; set; }

    }
}
