using Application.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IUnitOfWork unitOfWork) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await unitOfWork.Products.GetAllAsync();
        return Ok (data);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await unitOfWork.Products.GetByIdAsync(id);
        if (data == null) return Ok();
        return Ok(data);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(Product product)
    {
        var data = await unitOfWork.Products.AddAsync(product);
        return Ok(data);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Products.DeleteAsync(id);
        return Ok(data);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(Product product)
    {
        var data = await unitOfWork.Products.UpdateAsync(product);
        return Ok(data);
    }
}
