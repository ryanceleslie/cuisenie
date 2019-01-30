using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Entities.RecipeAggregate;
using Infrastructure.Data;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _service;
        private readonly IAppLogger<Recipe> _logger;

        public RecipesController(IRecipeService service, IAppLogger<Recipe> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: Recipes
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                _logger.Information("API.Controllers.RecipesController: Get()");

                var recipes = await _service.GetAll();

                //TODO mapper?

                return Ok(recipes);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"API.Controllers.RecipesController: Get() - Failed: {ex.Message}");
            }
            return BadRequest("GetAll - Failed");
        }

        // GET: Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                _logger.Information("API.Controllers.RecipesController: Get(int id)");

                var recipe = await _service.Get(id);

                //TODO mapper?

                return Ok(recipe);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"API.Controllers.RecipesController: Get(int id) - Failed: {ex.Message}");
            }
            return BadRequest("Get - Failed");
        }

        // PUT: Recipes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Recipe recipe)
        {
            try
            {
                if (id != recipe.Id)
                {
                    _logger.Warning("API.Controllers.RecipesController: Put(int id, Recipe recipe) - IDs don't match");

                    return BadRequest("IDs don't match");
                }

                _logger.Information("API.Controllers.RecipesController: Put(int id, Recipe recipe)");

                await _service.Edit(recipe);

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
                _logger.Error(ex, $"API.Controllers.RecipesController: Put(int id, Recipe recipe) - Failed: {ex.Message}");
            }
            return BadRequest("Put - Failed");
        }

        // POST: Recipes
        [HttpPost]
        public async Task<ActionResult> Post(Recipe recipe)
        {
            try
            {
                _logger.Information("API.Controllers.RecipesController: Post(Recipe recipe)");

                await _service.New(recipe);
                
                return CreatedAtAction("Get", new { id = recipe.Id }, recipe);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"API.Controllers.RecipesController: Post(Recipe recipe) - Failed: {ex.Message}");
            }
            return BadRequest("Post - Failed");
        }

        // DELETE: Recipes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _logger.Information("API.Controllers.RecipesController: Delete(int id)");

                var recipe = await _service.Get(id);

                if (recipe == null)
                {
                    return NotFound();
                }

                await _service.Remove(recipe);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"API.Controllers.RecipesController: Delete(int id) - Failed: {ex.Message}");
            }
            return BadRequest("Delete - Failed");
        }

        private async Task<bool> RecipeExists(int id)
        {
            var recipe = await _service.Get(id);

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
