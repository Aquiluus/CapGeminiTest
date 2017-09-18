using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapGeminiTest
{
    public partial class Edit : System.Web.UI.Page
    {
        /// <summary>
        /// String to hold sender query. 
        /// Used to get CustomerId
        /// </summary>
        private string query;
        
        /// <summary>
        /// In this method Forms are populated with data from database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                query = Request.QueryString["CustomerId"];
                Guid guid = new Guid(query);
                Customer customer = DatabaseConnector.GetInstance().Database.Customers.Single(cu => cu.CustomerId.Equals(guid));
                this.TextBoxName.Text = customer.Name.Trim();
                this.TextBoxSurname.Text = customer.Surname.Trim();
                this.TextBoxTelephone.Text = customer.Telephone.Trim();
                string address = customer.Address.Trim();
                string codeCity = address.Substring(address.IndexOf(',') + 2);
                int codeLength = codeCity.IndexOf(' ');
                this.TextBoxAddress.Text = address.Substring(0, address.IndexOf(','));
                this.TextBoxCode.Text = codeCity.Substring(0, codeLength);
                this.TextBoxCity.Text = codeCity.Substring(codeCity.IndexOf(' ') + 1); 


            }
        }

        /// <summary>
        /// Saving edited data to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = this.TextBoxName.Text;
                string surname = this.TextBoxName.Text;
                string telephone = this.TextBoxTelephone.Text;
                string address = this.TextBoxAddress.Text;
                string code = this.TextBoxCode.Text;
                string city = this.TextBoxCity.Text;
                Utilities.VerifyFormsCorrect(name, surname, telephone, address, code, city);
                query = Request.QueryString["CustomerId"];
                Guid guid = new Guid(query);
                Customer customer = DatabaseConnector.GetInstance().Database.Customers.Single(cu => cu.CustomerId.Equals(guid));
                customer.Name = this.TextBoxName.Text;
                customer.Surname = this.TextBoxSurname.Text;
                customer.Telephone = this.TextBoxTelephone.Text;
                customer.Address = this.TextBoxAddress.Text + ", " + this.TextBoxCode.Text + " " + this.TextBoxCity.Text;
                DatabaseConnector.GetInstance().Database.SaveChanges();
                Response.Redirect("Default.aspx");
            }
            catch (Exception exception)
            {
                this.LabelMessage.Text = exception.Message;
            }
        }
    }
}