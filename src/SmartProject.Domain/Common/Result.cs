using System;
using System.Diagnostics;
using System.Net;

namespace SmartProject.Domain.Common
{
	public class Result<T> where T : class
	{
		public bool IsSuccess { get; set; }
		public T? Data { get; set; }

        public static Result<T> Success(T data)
        {
            return new Result<T>() { IsSuccess = true, Data = data };
        }

        public static Result<T> Fail()
        {
            return new Result<T>() { IsSuccess = false };
        }
    }
}

