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
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public DeleteModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        [BindProperty]
      public todo todo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.todo == null)
            {
                return NotFound();
            }

            var todo = await _context.todo.FirstOrDefaultAsync(m => m.ID == id);

            if (todo == null)
            {
                return NotFound();
            }
            else 
            {
                todo = todo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.todo == null)
            {
                return NotFound();
            }
            var todo = await _context.todo.FindAsync(id);

            if (todo != null)
            {
                todo = todo;
                _context.todo.Remove(todo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
