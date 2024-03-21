using System;
namespace SmartProject.Application.Common
{
	public class Response
	{
        private readonly List<string> errors;

        public Response(bool isSuccess, List<string> errors)
        {
            this.IsSuccess = isSuccess;
            this.errors = errors;
        }

        public bool IsSuccess { get; private set; }

        public List<string> Errors
            => this.IsSuccess
                ? new List<string>()
                : this.errors;

        public static Response Success
            => new(true, new List<string>());

        public static Response Failure(IEnumerable<string> errors)
            => new(false, errors.ToList());
    }

    public class Response<TData> : Response
    {
        private readonly TData data;

        private Response(bool succeeded, TData data, List<string> errors)
            : base(succeeded, errors)
            => this.data = data;

        public TData Data
            => this.IsSuccess
                ? this.data
                : throw new InvalidOperationException(
                    $"{nameof(this.Data)} is not available with a failed result. Use {this.Errors} instead.");

        public static Response<TData> SuccessWith(TData data)
            => new(true, data, new List<string>());

        public new static Response<TData> Failure(IEnumerable<string> errors)
            => new(false, default!, errors.ToList());
    }
}

