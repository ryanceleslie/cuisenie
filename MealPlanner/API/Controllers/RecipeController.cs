using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        
        // GET: Recipes
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            _logger.Information("API.Controllers.RecipeController: Get()");
            var results = await _recipeService.GetAll();

            return Ok(results);
        }
    }
}