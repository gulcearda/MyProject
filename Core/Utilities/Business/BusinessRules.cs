using System;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                //! ünlem başarısız ise demek
                if (!logic.Success)
                {
                    return logic;
                    //biz burada başarısız kuralı businesse direkt gönderiyoruz.
                }
            }

            return null;
        }
    }
}
