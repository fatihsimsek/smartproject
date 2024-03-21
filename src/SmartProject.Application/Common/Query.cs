using System;
using MediatR;

namespace SmartProject.Application.Common
{
    public abstract record Query<T> : IRequest<T>;
}

