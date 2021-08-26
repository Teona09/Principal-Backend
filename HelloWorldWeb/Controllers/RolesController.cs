namespace HelloWorldWeb.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Roles Controller.
    /// </summary>
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="RolesController"/> class.
        /// </summary>
        /// <param name="roleManager">RoleManager &lt; IdentityRole &gt; parameter.</param>
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        /// <summary>
        /// Loads the Index page.
        /// </summary>
        /// <returns>Returns an implementation of IActionResult that has a Collection of roles.</returns>
        public ActionResult Index()
        {
            return View(roleManager.Roles);
        }

        /// <summary>
        /// Get endpoint to create a new role.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View(new IdentityRole());
        }

        /// <summary>
        /// Post endpoint to create a new role.
        /// </summary>
        /// <param name="role">The role to be created.</param>
        /// <returns>Redirect to Index page.</returns>
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
