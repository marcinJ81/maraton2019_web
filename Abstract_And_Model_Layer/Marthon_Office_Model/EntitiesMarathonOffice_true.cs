using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_And_Model_Layer.Marthon_Office_Model
{

    public class vListParticipantsInOfficeRegisterCondition
    {
        public int kart_id { get; set; }
        public string kart_nazwisko { get; set; }
        public string kart_imie { get; set; }
        public string kart_email { get; set; }
        public string kart_dataUr { get; set; }
        public string dys_wartosc { get; set; }
        public string tag_LabelNumber { get; set; }
        public string list_nazwa { get; set; }
        public string kart_wpis_oplata { get; set; }
        public string kart_wpis_rezerwowa { get; set; }
        public string suma_czas { get; set; }
        public int iloscOdbic { get; set; }
        public string realDistance { get; set; }
    }
    public static class SqlConnectionString
    {
        public static string ConnectionString()
        {
            SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder();
            scb.DataSource = @"name";
            scb.InitialCatalog = "1208_MaratonMszana";
            scb.IntegratedSecurity = true;
            return scb.ToString();
        }
    }
    public static class AnotherWayToGetDataFromBase
    {
        public static DataTable getDataTableFromDataSet(SqlCommand selectcommand2)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(selectcommand2))
            {
                DataTable dtResult = new DataTable();
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                if (dataset.Tables.Count > 0)
                {
                    foreach (var i in dataset.Tables)
                    {

                        DataTable tmpTable = (DataTable)i;
                        if (tmpTable.Rows.Count > 0)
                        {
                            dtResult = tmpTable;
                        }
                    }
                }
                return dtResult;
            }
        }
    }
    public interface IOfficeEntities
    {
        List<vListParticipantsInOfficeRegisterCondition> FillData(IOfficeEntities ioffice);
        DataTable getDataFromBase();
    }

    public class OfficeEntities : IOfficeEntities
    {
        public DataTable getDataFromBase()
        {
            DataTable dt = new DataTable();

            string query = "select * from marathonOffice.vListParticipantsInOfficeRegisterCondition ";
                       
            SqlConnection connect = new SqlConnection(SqlConnectionString.ConnectionString());
            try
            {
                connect.Open();
                SqlCommand selectcommand2 = connect.CreateCommand();
                selectcommand2.CommandText = query;
                selectcommand2.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(selectcommand2);
                adapter.Fill(dt);

                connect.Close();
                return dt;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return null;
            }
        }

        public List<vListParticipantsInOfficeRegisterCondition> FillData(IOfficeEntities ioffice)
        {
            try
            {
                List<vListParticipantsInOfficeRegisterCondition> result = new List<vListParticipantsInOfficeRegisterCondition>();
                var dataTableSource = ioffice.getDataFromBase();
                if (dataTableSource != null)
                {
                    for (int i = 0; i < dataTableSource.Rows.Count; i++)
                    {
                        result.Add(new vListParticipantsInOfficeRegisterCondition
                        {
                            kart_id = int.Parse(dataTableSource.Rows[i]["kart_id"].ToString()),
                            kart_nazwisko = dataTableSource.Rows[i]["kart_nazwisko"].ToString().ToUpper(),
                            kart_imie = dataTableSource.Rows[i]["kart_imie"].ToString().ToUpper(),
                            kart_email = dataTableSource.Rows[i]["kart_email"].ToString().ToUpper(),
                            kart_dataUr = DateTime.Parse(dataTableSource.Rows[i]["kart_dataUr"].ToString()).ToShortDateString(),
                            dys_wartosc = dataTableSource.Rows[i]["dys_wartosc"].ToString(),
                            tag_LabelNumber = dataTableSource.Rows[i]["tag_LabelNumber"].ToString(),
                            list_nazwa = dataTableSource.Rows[i]["list_nazwa"].ToString(),
                            kart_wpis_oplata  = dataTableSource.Rows[i]["kart_wpis_oplata"].ToString() == "True" ? "tak" : "nie",
                            kart_wpis_rezerwowa = dataTableSource.Rows[i]["kart_wpis_rezerwowa"].ToString() == "True" ? "tak" : "nie",
                            suma_czas = dataTableSource.Rows[i]["suma_czas"].ToString() ,
                            iloscOdbic = String.IsNullOrEmpty(dataTableSource.Rows[i]["iloscOdbic"].ToString()) == true ? 0 : int.Parse(dataTableSource.Rows[i]["iloscOdbic"].ToString()),
                            realDistance = dataTableSource.Rows[i]["realDistance"].ToString()
                        });
                    }
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
                return null;
            }
        }
    }

}
