using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Controllers
{
    public class ControllerCrudBase<T,R>: ControllerBase
        where T: EntityBase
        where R: Repository<T>
    {
        protected R repository;
        public ControllerCrudBase(R r)
        {
            repository = r;
        }

        // GET: api/T
        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return Ok(await repository.ListAll());
        }

        // GET: api/T/2
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            return Ok(await repository.GetById(id));
        }

        // PUT: api/T/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id,
            [FromBody] T entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != entity.Id) return BadRequest();

            T updated = await repository.Update(entity);

            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // POST api/T
        [HttpPost]
        public async Task<IActionResult> PostPublisher([FromBody] T entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await repository.Add(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // DELETE: api/T/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var deleted  = await repository.Delete(id);
            if (deleted == null) return NotFound();
            return Ok(deleted);
        }
    }
}
