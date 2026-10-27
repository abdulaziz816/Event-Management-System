using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProposal_Part1.Models;

namespace WebProposal_Part1.Pages
{
    public class AddEventModel : PageModel
    {
        public Event ev = new Event();
        public string message = "";

        public void OnGet()
        {
            ev.eventdate = DateTime.Now.AddDays(7);
        }

        public IActionResult OnPost(Event ev)
        {
            this.ev = ev;

            if (ev.eventdate < DateTime.Now)
            {
                ModelState.AddModelError("ev.eventdate", "The event date must be in the future.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try

            {
                int newID = 1;


                foreach (Event e in DataStore.events)

                {
                    if (e.eventID >= newID) newID = e.eventID + 1;
                }

                ev.eventID = newID;
                DataStore.events.Add(ev);
                return RedirectToPage("Index");

            }

            catch (Exception ex)

            {
                message = "Something went wrong while saving the event: " + ex.Message;
                return Page();

            }
        }
    }
}