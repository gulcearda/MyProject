using System;
namespace Core.Utilities.Results
{
    //hangi tipi bana döndüreceğini bize söyle demek için tip t
    //hemde bir iresult böylece success ve messega de var
    public interface IDataResult<T> : IResult
    {
        //Ayrıca t tipindeki dataları da al
        T Data { get; }

    }
}
