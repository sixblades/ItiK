using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Primitives
{
    public record DomainEvent(Guid Id) : INotification;
}
