using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Data;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages.Product
{
	[BindProperties]
	public class DeleteModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;     
        }

        public Products Products { get; set; }

        public void OnGet(int? id)
        {
            Products = _db.P_Products.FirstOrDefault(p => p.Id == id);
        }

        public IActionResult OnPost() 
        {
            _db.P_Products.Remove(Products);
            _db.SaveChanges();
			TempData["Delete"] = "A Product Deleted successfully!";
			return RedirectToPage("Index");
        
        }
    }
}
