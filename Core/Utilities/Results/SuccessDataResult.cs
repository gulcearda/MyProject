using System;
namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }

        public SuccessDataResult(T data) : base(data, true)
        {

        }

        public SuccessDataResult(string message) : base(default, true, message)
        {
            //default datanın direkt kendisi dönsün değişmeden demek
            //bu ve alttaki frame genelde kullanılmıyor ama yazılır

        }

        public SuccessDataResult() : base(default, true)
        {

        }

    }
}
