using System.ComponentModel.DataAnnotations;

namespace WebProposal_Part1.Models
{
    public class Event
    {
        public int eventID { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
        public string title { get; set; }

        public EventCategory category { get; set; }
        public DateTime eventdate { get; set; }

        [Required(ErrorMessage = "Please enter a venue.")]
        public string venue { get; set; }

        [Range(1, 500, ErrorMessage = "Capacity must be between 1 and 500.")]
        public int capacity { get; set; }

        public Event() { }

        public Event(int eventID, string title, EventCategory category, DateTime eventdate, string venue, int capacity)
        {
            this.eventID = eventID;
            this.title = title;
            this.category = category;
            this.eventdate = eventdate;
            this.venue = venue;
            this.capacity = capacity;
        }

        public int getSpaces(int registeredCount)
        {
            return (capacity - registeredCount);
        }

        public bool isFull(int registeredCount)
        {
            return registeredCount >= capacity;
        }
    }
}