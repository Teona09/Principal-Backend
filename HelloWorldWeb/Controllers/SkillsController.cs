namespace HelloWorldWeb.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using HelloWorldWeb.Data;
    using HelloWorldWeb.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Skill Controller.
    /// </summary>
    public class SkillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillsController"/> class.
        /// </summary>
        /// <param name="context"> ApplicationContext parameter</param>
        public SkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Loads the index page.
        /// </summary>
        /// <returns> Returns an implementation of IActionResult that contains a list of Skills</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Skill.ToListAsync());
        }

        /// <summary>
        /// Returns skill by id.
        /// </summary>
        /// <param name="id"> id of the searched skill.</param>
        /// <returns>Returns an implementation of IActionResult that contains the searched Skill</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await _context.Skill
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        /// <summary>
        /// Get endpoint for create skill.
        /// </summary>
        /// <returns>Returns an implementation of IActionResult.</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// Post endpoint to create a new skill.
        /// </summary>
        /// <param name="skill"> Skill object to be added to database.</param>
        /// <returns>Returns an implementation of IActionResult that contains the added Skill.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SkillUrl")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(skill);
        }

        /// <summary>
        /// Get endpoint for editing skill.
        /// </summary>
        /// <param name="id">Id of the skill to be edited</param>
        /// <returns>Returns an implementation of IActionResult that contains skill to be edited.</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await _context.Skill.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        /// <summary>
        /// Post endpoint to edit a skill.
        /// </summary>
        /// <param name="id"> Id of the skill to be edited.</param>
        /// <param name="skill"> Modified skill.</param>
        /// <returns>Returns an implementation of IActionResult that contains the edited Skill.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SkillUrl")] Skill skill)
        {
            if (id != skill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillExists(skill.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(skill);
        }

        /// <summary>
        /// Get endpoint to delete a skill.
        /// </summary>
        /// <param name="id"> id of the skill to be deleted.</param>
        /// <returns>Returns an implementation of IActionResult that contains skill to be deleted.</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await _context.Skill
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        /// <summary>
        /// Get endpoint to delete a skill.
        /// </summary>
        /// <param name="id">id of the skill to be deleted.</param>
        /// <returns>Returns an implementation of IActionResult that contains the modified Skill list.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skill = await _context.Skill.FindAsync(id);
            _context.Skill.Remove(skill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillExists(int id)
        {
            return _context.Skill.Any(e => e.Id == id);
        }
    }
}
