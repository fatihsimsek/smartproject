using System;
using MediatR;

namespace SmartProject.Application.Common
{
    public abstract class Command<T> : IRequest<T>
    {
    }
}

