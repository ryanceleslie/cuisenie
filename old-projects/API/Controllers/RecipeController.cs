using Core.Entities.RecipeAggregate;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class RecipeController : BaseController
    {
        private readonly IAppLogger<RecipeController> _logger;
        //TODO may need to create service in the API project? I struggle a bit with this, I know I should keep as much in the core as possible, but when do I know to put a service process closer to the API instead of Core?
        private readonly IRecipeService _recipeService;

        public RecipeController(IAppLogger<RecipeController> logger, IRecipeService recipeService)
        {
            _logger = logger;
            _recipeService = recipeService;
        }
        
        // GET: Recipe
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                _logger.Information("API.Controllers.RecipeController: Get()");
                var recipes = await _recipeService.GetAll();

                return Ok(recipes);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"API.Controllers.RecipeController: Get() - Failed: {ex.Message}");
            }
            return BadRequest("Get() - Failed");
        }

        //TODO May need to refactor this, add get recipe subitems or maybe in the API service folder since it may have dependencies? Not sure
        // GET: Recipe/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                _logger.Information("API.Controllers.RecipeController: Get(int id)");
                var result = await _recipeService.Get(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"API.Controllers.RecipeController: Get(int id) - Failed: {ex.Message}");
            }
            return BadRequest("Get(int id) - Failed");
        }

        // POST: Recipe/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Recipe recipe)
        {
            try
            {
                if (id != recipe.Id)
                {
                    _logger.Warning("API.Controllers.RecipeController: Put(int id, Recipe recipe) - IDs don't match");

                    return BadRequest("IDs don't match");
                }

                _logger.Information("API.Controllers.RecipeController: Put(int id, Recipe recipe)");

                await _recipeService.Edit(recipe);

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id).Result)
                {
                    return NotFound();
                }
                else
                {
                    throw; //TODO do I need to handle this?
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"API.Controllers.RecipeController: Put(int id, Recipe recipe) - Failed: {ex.Message}");
            }
            return BadRequest("Put(int id, Recipe recipe) - Failed");
        }

        // POST: Recipe
        [HttpPost]
        public async Task<ActionResult> Post(Recipe recipe)
        {
            try
            {
                _logger.Information("API.Controllers.RecipeController: Post(Recipe recipe)");

                await _recipeService.New(recipe);

                return CreatedAtAction("Get", new { id = recipe.Id }, recipe);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"API.Controllers.RecipeController: Post(Recipe recipe) - Failed: {ex.Message}");
            }
            return BadRequest("Post(Recipe recipe) - Failed");
        }

        // DELETE: Recipe/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _logger.Information("API.Controllers.RecipeController: Delete(int id)");

                var recipe = await _recipeService.Get(id);

                if (recipe == null)
                {
                    return NotFound();
                }

                await _recipeService.Remove(recipe);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"API.Controllers.RecipeController: Delete(int id) - Failed: {ex.Message}");
            }
            return BadRequest("Delete(int id) - Failed");
        }

        private async Task<bool> RecipeExists(int id)
        {
            var recipe = await _recipeService.Get(id);

            if (recipe == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}