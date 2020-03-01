using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_And_Model_Layer.Marthon_Office_Model
{
    public interface IStoredProcedures
    {
        void pInitializationAllParticipnat();
        void pStartinPayment(string name, string surname, string mail);
        void pCreateEmptyStartList();
        void pStartParticipantFromList(int list_id);
    }

    public class StoredProceduresOfficeMarathon : IStoredProcedures
    {
        public void pCreateEmptyStartList()
        {
            SqlConnection connect = new SqlConnection(SqlConnectionString.ConnectionString());
            connect.Open();
            SqlCommand selectcommand2 = connect.CreateCommand();
            selectcommand2.CommandText = "[dbo].[pCreateEmptyStartList]";
            selectcommand2.CommandType = CommandType.StoredProcedure;
            selectcommand2.CommandTimeout = 3000;
            SqlDataReader read2 = selectcommand2.ExecuteReader();
            read2.Close();
            connect.Close();
        }

        public void pInitializationAllParticipnat()
        {
            SqlConnection connect = new SqlConnection(SqlConnectionString.ConnectionString());
            connect.Open();
            SqlCommand selectcommand2 = connect.CreateCommand();
            selectcommand2.CommandText = "[dbo].[pInitilizationParticipant]";
            selectcommand2.CommandType = CommandType.StoredProcedure;
            selectcommand2.CommandTimeout = 3000;
            SqlDataReader read2 = selectcommand2.ExecuteReader();
            read2.Close();
            connect.Close();           
        }

        public void pStartinPayment(string name, string surname, string email)
        {
            
            SqlConnection connect = new SqlConnection(SqlConnectionString.ConnectionString());
            connect.Open();
            SqlCommand selectcommand2 = connect.CreateCommand();
            selectcommand2.CommandText = "[dbo].[pStartingFee]";
            selectcommand2.CommandType = CommandType.StoredProcedure;
            selectcommand2.CommandTimeout = 3000;
            SqlParameter param = new SqlParameter("name", name);
            SqlParameter param2 = new SqlParameter("surname", surname);
            SqlParameter param3 = new SqlParameter("email", email);
            
            param.Direction = ParameterDirection.Input;
            param2.Direction = ParameterDirection.Input;
            param3.Direction = ParameterDirection.Input;
            
            selectcommand2.Parameters.Add(param);
            selectcommand2.Parameters.Add(param2);
            selectcommand2.Parameters.Add(param3);
           
            SqlDataReader read2 = selectcommand2.ExecuteReader();
            read2.Close();
            connect.Close();
           
        }

        public void pStartParticipantFromList(int list_id)
        {
            SqlConnection connect = new SqlConnection(SqlConnectionString.ConnectionString());
            connect.Open();
            SqlCommand selectcommand2 = connect.CreateCommand();
            selectcommand2.CommandText = "[participant].[pStartParticipantFromList]";
            selectcommand2.CommandType = CommandType.StoredProcedure;
            selectcommand2.CommandTimeout = 3000;
            SqlParameter param = new SqlParameter("list_id", list_id);
          
            param.Direction = ParameterDirection.Input;
           
            selectcommand2.Parameters.Add(param);

            SqlDataReader read2 = selectcommand2.ExecuteReader();
            read2.Close();
            connect.Close();
        }
    }

    public interface IListOfStoredProcedures
    {
        StoredProcedure_Office getOneProcedureByName(IListOfStoredProcedures iStoredProcedure,string name);
        List<StoredProcedure_Office> getAllProcedure();
    }

    public class StoredProcedure_UseInOffice : IListOfStoredProcedures
    {
        public StoredProcedure_Office getOneProcedureByName(IListOfStoredProcedures iStoredProcedure, string name)
        {
            throw new NotImplementedException();
        }

        public List<StoredProcedure_Office> getAllProcedure()
        {
            throw new NotImplementedException();
        }
    }

    public class StoredProcedure_Office
    {
        public string ProcedurName { get; set; }
        public List<string> parameterString { get; set; }
        public List<int> paramtersInt { get; set; }
    }

}
