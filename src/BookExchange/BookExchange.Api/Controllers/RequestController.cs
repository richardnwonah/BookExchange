using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookExchange.Api.Repositories;
using BookExchange.Core.Models;
using BookExchange.Api.DTOs;

namespace BookExchange.Api.Controllers;

[ApiController]
[Route("[controller]")]
//[Authorize]
    public class RequestController : ControllerBase
    { 
    private readonly IRequestRepository _requestRepository;
        public RequestController(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }  
      
        [HttpPost]
        [HttpPost, Route("MakeRequest")]
        public async Task<ActionResult<RequestDTO>> PostRequest(RequestDTO request)
            {
               var result =  _requestRepository.PostRequest(request);
                if((result == null))
                {
                    
                }
                 return Ok();
                 }

        [HttpPut("{id}")]    
        public IActionResult ApproveRequest (Guid id, [FromBody] ApproveRequestDTO approval)
        {
            _requestRepository.ApproveRequest(id, approval);
            
            return NoContent();
        }
     }


