
/// <summary>
/// 请求类（包含订单信息）
/// </summary>
public class DiscountRequest
{
    public string OrderId { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal FinalPrice { get; set; }
    public string CustomerLevel { get; set; } // "Regular", "VIP", "SuperVIP"
}
