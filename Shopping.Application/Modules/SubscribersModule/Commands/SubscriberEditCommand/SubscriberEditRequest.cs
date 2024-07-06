using MediatR;
using Shopping.Domain.Models.Entities;
using System;

namespace Shopping.Application.Modules.SubscribersModule.Commands.SubscriberEditCommand
{
    public class SubscriberEditRequest : IRequest<Subscriber>
    {
        public int Id { get; set; }
        public string Email { get; set;}
    }
}
