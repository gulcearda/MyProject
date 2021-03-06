using System;
namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        object Get(string key);
        //diğer yazım şeklidir.

        void Add(string key, object value, int duration);
        //bir key, değeri ve tutma süresi saat dakika olabilir bu
        bool IsAdd(string key);
        //cache de var mı yok mu kontrol etme
        void Remove(string key);
        //cache den uçurma
        void RemoveByPattern(string pattern);
        //başı sonu önemli değil içinde bir şey desen olanı uçur
    }
}
