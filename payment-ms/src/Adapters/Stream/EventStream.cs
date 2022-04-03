namespace DevPrime.Stream;
public class EventStream : EventStreamBase, IEventStream
{
    public override void StreamEvents()
    {
        Subscribe<IPaymentService>("Stream1", "OrderCreated", (payload, paymentService, Dp) =>
        {
            var dto = System.Text.Json.JsonSerializer.Deserialize<OrderCreatedEventDTO>(payload);

            var command = new Payment()
            {
                CustomerName = dto.CustomerName,
                OrderId = dto.ID,
                Value = dto.Total
            };

            paymentService.Add(command);

        });
    }
}