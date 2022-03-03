using EventBus.Messages.Events;
using MassTransit;
using Ordering.Api.Domain;
using Ordering.Api.Repository;

namespace Ordering.Api.EventBus.Consumers
{
    public class BasketCheckoutEventHandler : IConsumer<BasketCheckoutEvent>
    {
        private readonly IOrderRepository orderRepository;

        public BasketCheckoutEventHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            Order order = new Order
            {
                AddressLine = context.Message.AddressLine,
                CardName = context.Message.CardName,
                CardNumber = context.Message.CardNumber,
                Country = context.Message.Country,
                CVV = context.Message.CVV,
                EmailAddress = context.Message.EmailAddress,
                Expiration = context.Message.Expiration,
                FirstName = context.Message.FirstName,
                LastName = context.Message.LastName,
                PaymentMethod = context.Message.PaymentMethod,
                State = context.Message.State,
                TotalPrice = context.Message.TotalPrice,
                UserName = context.Message.UserName,
                ZipCode = context.Message.ZipCode,
            };
            await this.orderRepository.CreateOrder(order);
        }
    }
}
