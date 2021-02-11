using System;
namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        public ErrorDataResult(T data) : base(data, false)
        {

        }

        public ErrorDataResult(string message) : base(default, false, message)
        {
            //default datanın direkt kendisi dönsün değişmeden demek
            //bu ve alttaki frame genelde kullanılmıyor ama yazılır

        }

        public ErrorDataResult() : base(default, false)
        {

        }

    }
}
