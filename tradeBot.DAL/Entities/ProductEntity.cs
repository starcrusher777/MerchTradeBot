using tradeBot.DAL.Enums;

namespace tradeBot.DAL.Entities;

public class ProductEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ProductType Type { get; set; }
    public CharType CharType { get; set; }
    
}