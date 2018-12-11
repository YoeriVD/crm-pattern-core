using System.Threading.Tasks;
using crm_pattern.core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    public class DetailModel : PageModel
    {
        private readonly CrmContext _db;

        public DetailModel(CrmContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }

        [BindProperty(SupportsGet = true)] public string Type { get; set; } = nameof(YouthHostel);
        [BindProperty(SupportsGet = true)] public int Id { get; set; } = 1;

        public Entity Entity { get; set; }

        public async Task OnGetAsync()
        {
            var set = EntityMetaDataFactory.Set(_db, Type);
            var entity = await set.FirstOrDefaultAsync(t => t.Id == Id);
            Entity = entity;
        }
    }
}