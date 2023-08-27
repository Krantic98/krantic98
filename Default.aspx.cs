using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using OfficeOpenXml;
using ClosedXML.Excel;
using System.IO;
using Azure;
using System.Reflection.Emit;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace DataOfMovies
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptFilmovi.Visible = true;

                // Dodajte sledeću liniju kako biste izbegli problem sa renderiranjem Repeater kontrola
            
            }
        }

        protected void btnPrikazi_Click(object sender, EventArgs e)
        {
            string startGodinaValue = StartYearTextBox.Text.Trim();
            string endGodinaValue = EndYearTextBox.Text.Trim();
            string broadcastValue = BroadcastTextBox.Text.Trim();

            string connectionString = @"Data Source=DESKTOP-5IJUAB9\SQLEXPRESS01;Initial Catalog=MyDatabase;User ID=sa;Password=NovaLozinka77//";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ID, Name, Year, Genre, Director, Broadcast FROM dbo.Movies WHERE 1=1";

                    if (!string.IsNullOrEmpty(broadcastValue))
                    {
                        query += " AND Broadcast=@Broadcast";
                    }

                    if (!string.IsNullOrEmpty(startGodinaValue))
                    {
                        query += " AND Year >= @StartGodina";
                    }

                    if (!string.IsNullOrEmpty(endGodinaValue))
                    {
                        query += " AND Year <= @EndGodina";
                    }

                    SqlCommand command = new SqlCommand(query, connection);

                    // Dodajte parametre za svaki slučaj
                    if (!string.IsNullOrEmpty(broadcastValue))
                    {
                        command.Parameters.AddWithValue("@Broadcast", broadcastValue);
                    }

                    if (!string.IsNullOrEmpty(startGodinaValue))
                    {
                        command.Parameters.AddWithValue("@StartGodina", int.Parse(startGodinaValue));
                    }

                    if (!string.IsNullOrEmpty(endGodinaValue))
                    {
                        command.Parameters.AddWithValue("@EndGodina", int.Parse(endGodinaValue));
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    rptFilmovi.DataSource = dataTable;
                    rptFilmovi.DataBind();

                    int numResults = dataTable.Rows.Count;
                    LiteralNumResults.Text = $"Broj rezultata: {numResults}";

                    rptFilmovi.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Greška prilikom izvršavanja upita: " + ex.ToString());
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            StartYearTextBox.Text = string.Empty;
            EndYearTextBox.Text = string.Empty;
            BroadcastTextBox.Text = string.Empty;
            LiteralNumResults.Text = string.Empty;
            rptFilmovi.DataSource = null;
            rptFilmovi.DataBind();
            rptFilmovi.Visible = false;
        }


        protected void ExportToExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=finance.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            string startGodinaValue = StartYearTextBox.Text.Trim();
            string endGodinaValue = EndYearTextBox.Text.Trim();
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            htmlWrite.Write("<label for=\"StartYearTextBox\">Start Year:</label><br/>");
            htmlWrite.Write("<asp:TextBox ID=\"StartYearTextBox\" runat=\"server\">" + startGodinaValue + "</asp:TextBox> <br/>");
            htmlWrite.Write("<label for=\"EndYearTextBox\">End Year:</label> <br/>");
            htmlWrite.Write("<asp:TextBox ID=\"EndYearTextBox\" runat=\"server\">" + endGodinaValue + "</asp:TextBox> <br/>");
            htmlWrite.Write(" <asp:Label ID=\"LiteralNumResults\" runat=\"server\" CssClass=\"LiteralNumResults\">" + LiteralNumResults.Text + "</asp:Label> <br/><br/>");
          
            rptFilmovi.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }


    }
}
