using System;
using MediatR;

namespace SmartProject.Application.Common
{
    public abstract record Command<T> : IRequest<T>;
}

