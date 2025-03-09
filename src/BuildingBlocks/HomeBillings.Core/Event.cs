using MediatR;

namespace HomeBillings.Core
{
    public class Event : INotification
    {
        public string? AggregateId { get; set; }
    }
}
