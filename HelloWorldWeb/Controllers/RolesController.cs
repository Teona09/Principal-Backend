namespace HelloWorldWeb.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class RolesController : Controller
    {
        private RoleManager<IdentityRole> roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        // GET: RolesController
        public ActionResult Index()
        {
            return View(roleManager.Roles);
        }

        // GET: RolesController/Create
        public ActionResult Create()
        {
            return View(new IdentityRole());
        }

        // POST: RolesController/Create
        [HttpPost]
        public async Task<ActionResult> Create(IdentityRole role)
        {
            try
            {
                await roleManager.CreateAsync(role);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
