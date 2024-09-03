using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Data;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages.Product
{
    [BindProperties]
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
            
        }

       // [BindProperty]
        public Products Products { get; set; }
        public void OnGet(int? id)
        {
            Products = _context.P_Products.FirstOrDefault(a => a.Id == id);
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
				_context.P_Products.Update(Products);
				_context.SaveChanges();
                TempData["Edit"] = "Product Updated successfully!";

                return RedirectToPage("Index");


			}
            return Page();
          
        }
    }
}
