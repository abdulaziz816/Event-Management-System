using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProposal_Part1.Models;

namespace WebProposal_Part1.Pages
{
    public class IndexModel : PageModel
    {
        public List<Event> eventList = new List<Event>();
        public string message = "";

        public void OnGet()
        {
            eventList = DataStore.events;
        }

        public IActionResult OnPostDelete(int id)
        {
            try
            {
                Event? toDelete = null;
                foreach (Event e in DataStore.events)
                {
                    if (e.eventID == id) toDelete = e;
                }

                if (toDelete == null)
                {
                    throw new Exception("The event you tried to delete does not exist.");
                }

                DataStore.events.Remove(toDelete);
                DataStore.registrations.RemoveAll(r => r.eventID == id);
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                eventList = DataStore.events;
                return Page();
            }
        }
    }
}