using System.ComponentModel.DataAnnotations;

namespace LearningAPI.Models
{
    public class SuperHero
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }



        [Required]
        public string LastName { get; set; }

        [Required]
        public string Place { get; set; }


        [Required]
        public Guid uuid { get; set; } = Guid.NewGuid();


        [Required]
        public string HeroName { get; set; }
    }
}
