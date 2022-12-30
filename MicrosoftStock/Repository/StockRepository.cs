using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Primitives;
using MicrosoftStock.Models;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace MicrosoftStock.Repository;

public sealed class StockRepository : IStockRepository
{
    private static readonly Lazy<IEnumerable<Stock>> _context = new(InitializeContext);

    private static readonly CsvConfiguration _csvConfig = new(CultureInfo.InvariantCulture)
    {
        Delimiter = ",",
        Encoding = Encoding.UTF8,
        HasHeaderRecord = true,
        BadDataFound = null,
        MissingFieldFound = null
    };

    private static IEnumerable<Stock> InitializeContext()
    {
        using StringReader reader = new(Database.Resource.Microsoft_Stock);
        using CsvReader csv = new(reader, _csvConfig);
        return csv.GetRecords<Stock>().ToList();
    }

    public IEnumerable<Stock> GetAll()
    {
        return _context.Value;
    }
}