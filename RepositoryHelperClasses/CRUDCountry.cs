using System;
using System.Collections.Generic;
using RepositoryHelperInterfaces;

using System.Data.Common;
using System.Data.SqlClient;
using RepositoryHelper.Models;
using Microsoft.Extensions.Configuration;

namespace RepositoryHelperClasses 
{
    public class CRUDCountry : ICRUDCountry
    {
        public IConfiguration confi = null;
        public CRUDCountry(IConfiguration configuration)
        {
            confi = configuration;
        }
        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(confi.GetConnectionString("DefaultConnection"));
            return con;
        }
        public void Create(string countryName)
        {
            string strStoredProc = ProcedureHelper.GetProc(EnumProcedures.CreateCountry);            

            SqlConnection con = GetConnection();
            
            SqlCommand cmd = new SqlCommand(strStoredProc, con);
            cmd.Parameters.AddWithValue("@cName", countryName);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<Country> List()
        {
            string strStoredProc = ProcedureHelper.GetProc(EnumProcedures.GetCountries);

            SqlConnection con = GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(strStoredProc, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Country> countries = new List<Country>();
            while(reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("Name")) && !reader.IsDBNull(reader.GetOrdinal("ID")))
                {
                    countries.Add(new Country() { Name= reader["Name"].ToString(), ID= reader["ID"].ToString() });
                }
            }
            con.Close();

            return countries;
        }


        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
