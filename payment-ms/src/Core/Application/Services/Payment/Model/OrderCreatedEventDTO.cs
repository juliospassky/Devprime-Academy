namespace Application.Services.Payment.Model;
public class OrderCreatedEventDTO
{
    public string CustomerName { get; set; }
    public string CustomerTaxId { get; set; }
    public double Total { get; set; }
    public Guid ID { get; set; }
}