namespace Application.Services.Payment.Model;
public class PaymentDeletedEventDTO
{
    public Guid ID { get; set; }
    public string CustomerName { get; set; }
    public Guid OrderId { get; set; }
    public double Value { get; set; }
}