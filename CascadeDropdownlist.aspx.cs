using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace GridViewWebApp
{
    public partial class CascadeDropdownlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateContinentsDropDownList();
            }
        }

        private void PopulateContinentsDropDownList()
        {
            ContinentsDropDownList.DataSource = GetData("spGetContinents", null);
            ContinentsDropDownList.DataBind();

            ListItem liContinent = new ListItem("Select Continent", "-1");
            ContinentsDropDownList.Items.Insert(0, liContinent);

            ListItem liCountries = new ListItem("Select Countries", "-1");
            CountriesDropDownList.Items.Insert(0, liCountries);

            ListItem liCities = new ListItem("Select Cities", "-1");
            CitiesDropDownList.Items.Insert(0, liCities);

            CountriesDropDownList.Enabled = false;
            CitiesDropDownList.Enabled = false;
        }
        private DataSet GetData(string SPName,SqlParameter spparameter)
        {
          string cs =  ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(SPName,con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (spparameter != null)
            {
                da.SelectCommand.Parameters.Add(spparameter);
            }


            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        protected void ContinentsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ContinentsDropDownList.SelectedIndex == 0)
            {
                //CountriesDropDownList.SelectedIndex = 0;
                CountriesDropDownList.Enabled = false;
                // CitiesDropDownList.SelectedIndex = 0;
                CitiesDropDownList.Enabled = false;
            }
            else
            {
                CountriesDropDownList.Enabled = true;
                SqlParameter parameter = new SqlParameter("@ContinentId", ContinentsDropDownList.SelectedValue);
                DataSet dss = GetData("spGetCountriesByContinentId",parameter);
                CountriesDropDownList.DataSource = dss;
                CountriesDropDownList.DataBind();


                ListItem liCountries = new ListItem("Select Countries", "-1");
                CountriesDropDownList.Items.Insert(0, liCountries);

                CitiesDropDownList.SelectedIndex = 0;
                CitiesDropDownList.Enabled = false;
            }
        }

        protected void CountriesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CountriesDropDownList.SelectedIndex == 0)
            {
                CitiesDropDownList.SelectedIndex = 0;
                CitiesDropDownList.Enabled = false;
            }
            else
            {
                CitiesDropDownList.Enabled = true;
                SqlParameter parameter = new SqlParameter("@CountryId", CountriesDropDownList.SelectedValue);
                DataSet dss = GetData("spGetCitiesByCountryId", parameter);
                CitiesDropDownList.DataSource = dss;
                CitiesDropDownList.DataBind();
                ListItem liCities = new ListItem("Select Cities", "-1");
                CitiesDropDownList.Items.Insert(0, liCities);
            }
        }

    }
}