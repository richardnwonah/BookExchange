using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookExchange.Api.Repositories;
using BookExchange.Core.Models;

namespace BookExchange.Api.Controllers;

[ApiController]
[Route("[controller]")]

    public class CategoryController : ControllerBase
    { 
    private readonly ICategoryRepository _categories;
        public CategoryController(ICategoryRepository categories)
        {
            _categories = categories;
        }
        [HttpGet]
   
            public async Task<IActionResult> GetCategory()
            {
                var categories = await _categories.GetAllCategoriesAync();
                return Ok(categories); 
            }     
            [HttpPost]
            public async Task<ActionResult<Category>> AddCategory(Category category)
            {
               var result =  _categories.PostCategory(category);
                if(!(await result))
                {

                }
                 return CreatedAtAction(nameof(GetCategory), new { categoryid = category.CategoryId }, category);
                //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
                
            }    
     }


