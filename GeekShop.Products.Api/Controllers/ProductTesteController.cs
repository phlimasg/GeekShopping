using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeekShop.Products.Api.Data.ValueObjects;
using GeekShop.Products.Api.Model.Context;
using GeekShop.Products.Api.Repository;
using NuGet.Protocol.Core.Types;

namespace GeekShop.Products.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductTesteController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductTesteController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET: api/ProductTeste
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> GetProductVO()
        {
            return Ok(await _repository.FindAll());
        }

        // GET: api/ProductTeste/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> GetProductVO(long id)
        {
            var productVO = await _repository.FindById(id);

            if (productVO == null)
            {
                return NotFound();
            }

            return productVO;
        }

        // PUT: api/ProductTeste/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductVO(long id, ProductVO productVO)
        {
            if (id != productVO.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repository.Update(productVO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductVOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductTeste
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductVO>> PostProductVO(ProductVO productVO)
        {
            await _repository.Create(productVO);
            return CreatedAtAction("GetProductVO", new { id = productVO.Id }, productVO);
        }

        // DELETE: api/ProductTeste/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductVO(long id)
        {
            await _repository.Delete(id);
            return NoContent();
        }

        private bool ProductVOExists(long id)
        {
            var product = _repository.FindById(id).Result;            
            return product is null ? false : true;
        }
    }
}
