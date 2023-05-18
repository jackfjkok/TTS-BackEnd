using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TTS_BackEnd.Models;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;


namespace TTS_BackEnd.Controllers
{
    public class HomeController : Controller
    {

        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<GeneralData> generalDatas = new List<GeneralData>();
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration config)
        {
            this.configuration = config;
            con.ConnectionString = configuration.GetConnectionString("DefaultConnectionString");
        }

        private void FetchData()
        {
            if (generalDatas.Count > 0)
            {
                generalDatas.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [Members],[Billable Hours],[Non-Billable Hours] FROM GeneralData";
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    generalDatas.Add(new GeneralData()
                    {
                        member              = dr["Members"].ToString(),
                        BillableHours       = dr["Billable Hours"].ToString(),
                        Non_BillableHours   = dr["Non-Billable Hours"].ToString()
                    });
                }

                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public IActionResult Index()
        {
            string connectionstring = configuration.GetConnectionString("DefaultConnectionString");

            //SqlConnection connection = new SqlConnection(connectionstring);

            //connection.Open();
            //SqlCommand com = new SqlCommand("Select count(*) from TimeLog_UserInput", connection);
            //var count = (int)com.ExecuteScalar();

            //ViewData["TotalData"] = count;

            //connection.Close();
            //FetchData();

            return View(generalDatas);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello" + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public IActionResult Index_2()
        {
            return View();
        }
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public IActionResult Index_3()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
