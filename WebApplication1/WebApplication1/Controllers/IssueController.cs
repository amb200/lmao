using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using AutoMapper;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueServices _issueRepository;
        private readonly IMapper _mapper;

        public IssueController(IIssueServices issueRepository, IMapper mapper)
        {
            _issueRepository = issueRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Issue>> Get()
        {
            return await _issueRepository.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _issueRepository.GetById(id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Issue issue)
        {
            await _issueRepository.Add(issue);
            return CreatedAtAction(nameof(GetById), new { id = issue.EventId }, issue);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Issue issue)
        {
            var currentIssue = await _issueRepository.GetById(id);

             if (currentIssue == null)
            {
                return NotFound();
            }

            
            _mapper.Map(issue, currentIssue);


            await _issueRepository.Update(currentIssue);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _issueRepository.Delete(id);
            return NoContent();
        }
    }

}
