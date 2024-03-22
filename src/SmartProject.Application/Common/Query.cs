using System;
using MediatR;

namespace SmartProject.Application.Common
{
    public abstract class Query<T> : IRequest<T>
    {
    }
}

