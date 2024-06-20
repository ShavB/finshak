using api.Data;
using api.Dto.Stocks;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController(IStockRepository stockRepository) : ControllerBase
    {
        private readonly IStockRepository _stockRepository = stockRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockRepository.GetAllAsync();
            var stockData = stocks.Select(x => x.ToStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockRepository.GetById(id);
            if (stock != null)
            {
                return Ok(stock.ToStockDto());
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateData([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockRequestDto();
            await _stockRepository.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateData([FromRoute] int id, [FromBody] UpdateStockRequestDto updateStockRequestDto)
        {
            var stock = await _stockRepository.UpdateAsync(id, updateStockRequestDto);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStock([FromRoute] int id)
        {
            var stock = await _stockRepository.DeleteAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}