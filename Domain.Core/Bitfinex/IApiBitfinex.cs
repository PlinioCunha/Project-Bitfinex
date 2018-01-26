using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces
{
    public interface IApiBitfinex
    {

        Task<T> GetAsnyc<T>(string urlPath);
        T Get<T>(string urlPath);
    }
}
