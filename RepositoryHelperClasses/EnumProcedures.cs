using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace RepositoryHelperClasses
{
    public enum EnumProcedures
    {
        CreateCountry=0,
        GetCountries = 1
    }
    
    public class ProcedureHelper
    {
        

        public static string GetProc(EnumProcedures enumName)
        {
            string ProcName = "";
            switch (enumName)
            {                
                case EnumProcedures.CreateCountry:
                    ProcName = "spCreateCountry";
                    break;
                case EnumProcedures.GetCountries:
                    ProcName = "spGetCountries";
                    break;

                default:
                    throw new Exception("Procedure not associated with the Enum");
            }

            return ProcName;
        }

     

        
    }
}
