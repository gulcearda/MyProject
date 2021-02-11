using System;
namespace Core.Utilities.Results
{
    //sen bir class sın ve resultsın.
    //result yapısını içeriyorsun. Ama bunun yapısı var diye de implement ediyoruz.
    public class DataResult<T> : Result, IDataResult<T>
    {
        //Dataresultın basei resulttur.

        public DataResult(T data, bool success, string message):base(success,message)
        {
            Data = data;
        }

        public DataResult(T data, bool success): base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
