using MicrosoftStock.Models;

namespace MicrosoftStock.Repository;

public interface IStockRepository
{
    IEnumerable<Stock> GetAll();
}