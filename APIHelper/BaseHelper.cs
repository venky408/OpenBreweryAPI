using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBreweryAPI.APIHelper
{
    public static class BaseHelper
    {
        public const string BASE_URI = "https://api.openbrewerydb.org/";
        public const string GET_ALL_BREWERY_URL = "breweries";
        public const string GET_BREWERY_URL = "breweries?by_name=";
    }
}
