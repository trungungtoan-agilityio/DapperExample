namespace Application.Interfaces;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
}