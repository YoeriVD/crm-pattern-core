using System.Collections.Generic;
using System.Threading.Tasks;
using crm_pattern.core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    public class ViewModel : PageModel
    {
        private readonly CrmContext _db;

        public ViewModel(CrmContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }

        public IEnumerable<Entity> Entities { get; set; }
        [BindProperty(SupportsGet = true)] public string Type { get; set; } = nameof(YouthHostel);


        public async Task OnGetAsync()
        {
            var set = EntityMetaDataFactory.Set(_db, Type);
            var list = await set.ToListAsync();
            Entities = list;
        }
    }
}