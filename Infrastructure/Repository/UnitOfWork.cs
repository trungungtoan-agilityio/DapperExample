using Application.Interfaces;

namespace Infrastructure.Repository;

public class UnitOfWork(IProductRepository productRepository) : IUnitOfWork
{
    public IProductRepository Products { get; } = productRepository;
}
