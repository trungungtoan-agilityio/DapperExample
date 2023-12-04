using System.Data.SqlClient;
using Application.Interfaces;
using Core.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repository;

public class ProductRepository(IConfiguration configuration) : IProductRepository
{
    public async Task<int> AddAsync(Product entity)
    {
        entity.AddedOn = DateTime.Now;
        const string sql = "Insert into product (Name,Description,Barcode,Rate,AddedOn) VALUES (@Name,@Description,@Barcode,@Rate,@AddedOn)";
        await using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        var result = await connection.ExecuteAsync(sql, entity);
        return result;
    }

    public async Task<int> DeleteAsync(int id)
    {
        const string sql = "DELETE FROM product WHERE Id = @Id";
        await using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        var result = await connection.ExecuteAsync(sql, new { Id = id });
        return result;
    }

    public async Task<IReadOnlyList<Product>> GetAllAsync()
    {
        const string sql = "SELECT * FROM product";
        await using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        var result = await connection.QueryAsync<Product>(sql);
        return result.ToList();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        const string sql = "SELECT * FROM product WHERE Id = @Id";
        await using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        var result = await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
        return result;
    }

    public async Task<int> UpdateAsync(Product entity)
    {
        entity.ModifiedOn = DateTime.Now;
        const string sql = "UPDATE product SET Name = @Name, Description = @Description, Barcode = @Barcode, Rate = @Rate, ModifiedOn = @ModifiedOn  WHERE Id = @Id";
        await using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        var result = await connection.ExecuteAsync(sql, entity);
        return result;
    }
}