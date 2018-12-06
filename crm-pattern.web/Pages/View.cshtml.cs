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
        }

        public IEnumerable<Entity> Entities { get; set; }
        [BindProperty] public string Type { get; set; } = nameof(YouthHostel);

        public async Task OnGetAsync()
        {
//            var possibleTypes = _db.GetType().GetAssembly().GetTypes()
//                .Where(t => !string.IsNullOrWhiteSpace(t.Name))
//                .Where(t => t.IsSubclassOf(typeof(Entity)))
//                .ToDictionary(t => t.Name.ToLowerInvariant());
//            var lowerType = Type.ToLowerInvariant();
//
//            if (!possibleTypes.ContainsKey(lowerType)) throw new ArgumentException();
//            var type = possibleTypes[lowerType];
//
//
//            var dbSetMethodInfo = typeof(DbContext).GetMethod("Set");
//            var dbSet = dbSetMethodInfo.MakeGenericMethod(type).Invoke(_db, null);
//
//            var toListMethodInfo = typeof(EntityFrameworkQueryableExtensions).GetMethod("ToListAsync")
//                .MakeGenericMethod(type);
//            var toListMethod = (dynamic) toListMethodInfo.Invoke(dbSet, new[] {dbSet, default(CancellationToken)});
//            Entities = (IEnumerable<Entity>) await toListMethod;

            if (Type == nameof(ContactPerson)) Entities = await _db.ContactPersons.ToListAsync();

            if (Entities == null) Entities = await _db.YouthHostels.ToListAsync();
        }
    }
}