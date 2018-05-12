using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Data;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public RoomBooking RoomBooking { get; set; }
        public HallBooking HallBooking { get; set; }

        public void OnGet()
        {

        }
    }
}
