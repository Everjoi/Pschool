﻿using Pschool.Shared.Interfaces;


namespace Pschool.Shared.Results
{
    public class Result<T> : IResult<T>
    {
        public List<string> Messages { get; set; } = new List<string>();
        public bool Succeeded { get; set; }
        public T Data { get; set; }
        public Exception Exception { get; set; } = new();
        public int Code { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        // Success
        public static Result<T> Success()
        {
            return new Result<T>
            {
                Succeeded = true
            };
        }

        public static Result<T> Success(string message)
        {
            return new Result<T>
            {
                Succeeded = true,
                Messages = new List<string> { message }
            };
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>
            {
                Succeeded = true,
                Data = data
            };
        }

        public static Result<T> Success(T data, string message)
        {
            return new Result<T>
            {
                Succeeded = true,
                Messages = new List<string> { message },
                Data = data
            };
        }

         
        // Fial
        public static Result<T> Failure()
        {
            return new Result<T>
            {
                Succeeded = false
            };
        }

        public static Result<T> Failure(string message)
        {
            return new Result<T>
            {
                Succeeded = false,
                Messages = new List<string> { message }
            };
        }

        public static Result<T> Failure(List<string> messages)
        {
            return new Result<T>
            {
                Succeeded = false,
                Messages = messages
            };
        }

        public static Result<T> Failure(T data)
        {
            return new Result<T>
            {
                Succeeded = false,
                Data = data
            };
        }

        public static Result<T> Failure(T data, string message)
        {
            return new Result<T>
            {
                Succeeded = false,
                Messages = new List<string> { message },
                Data = data
            };
        }

        public static Result<T> Failure(T data, List<string> messages)
        {
            return new Result<T>
            {
                Succeeded = false,
                Messages = messages,
                Data = data
            };
        }

        public static Result<T> Failure(Exception exception)
        {
            return new Result<T>
            {
                Succeeded = false,
                Exception = exception
            };
        }

         
        // Success Async
        public static Task<Result<T>> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public static Task<Result<T>> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }

        public static Task<Result<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        }

        public static Task<Result<T>> SuccessAsync(T data, string message)
        {
            return Task.FromResult(Success(data, message));
        }

        
        // Fail Async
        public static Task<Result<T>> FailureAsync()
        {
            return Task.FromResult(Failure());
        }

        public static Task<Result<T>> FailureAsync(string message)
        {
            return Task.FromResult(Failure(message));
        }

        public static Task<Result<T>> FailureAsync(List<string> messages)
        {
            return Task.FromResult(Failure(messages));
        }

        public static Task<Result<T>> FailureAsync(T data)
        {
            return Task.FromResult(Failure(data));
        }

        public static Task<Result<T>> FailureAsync(T data, string message)
        {
            return Task.FromResult(Failure(data, message));
        }

        public static Task<Result<T>> FailureAsync(T data, List<string> messages)
        {
            return Task.FromResult(Failure(data, messages));
        }

        public static Task<Result<T>> FailureAsync(Exception exception)
        {
            return Task.FromResult(Failure(exception));
        }

    }
}
