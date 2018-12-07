using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bogus.Platform;
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
            var possibleTypes = _db.GetType().GetAssembly().GetTypes()
                .Where(t => !string.IsNullOrWhiteSpace(t.Name))
                .Where(t => t.IsSubclassOf(typeof(Entity)))
                .ToDictionary(t => t.Name.ToLowerInvariant());
            var lowerType = Type.ToLowerInvariant();

            if (!possibleTypes.ContainsKey(lowerType)) throw new ArgumentException();
            var type = possibleTypes[lowerType];


            var set = _db.Set(type).Cast<Entity>();
            var list = await set.ToListAsync();
            Entities = list;
        }
    }
}