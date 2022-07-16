using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Todo
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public IndexModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        public IList<todo> todoList { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.todo != null)
            {
                todoList = await _context.todo.ToListAsync();
            }
        }

        [BindProperty]
        public todo todo { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.todo == null || todo == null)
            {
                return Page();
            }

            _context.todo.Add(todo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
