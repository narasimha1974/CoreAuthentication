using System;
using System.Collections.Generic;
using RepositoryHelper.Models;
namespace RepositoryHelperInterfaces
{
    public interface ICRUDCountry
    {
        void Create(string countryName);
        void Update();
        void Delete();
        List<Country> List();
    }
}
