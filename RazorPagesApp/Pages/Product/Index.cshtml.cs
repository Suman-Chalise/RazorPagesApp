using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Data;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        //public Products Product { get; set; }

        public List<Products> Product_list { get; set; }
        public void OnGet()
        {
           Product_list =  _context.P_Products.ToList();
        }
    }
}
