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

        private CGTDataEntities db = new CGTDataEntities();
        private string query;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                query = Request.QueryString["CustomerId"];
                Guid guid = new Guid(query);
                Customer customer = db.Customers.Single(cu => cu.CustomerId.Equals(guid));
                this.TextBoxName.Text = customer.Name;
                this.TextBoxSurname.Text = customer.Surname;
                this.TextBoxTelephone.Text = customer.Telephone;
                string address = customer.Address;
                string codeCity = address.Substring(address.IndexOf(',') + 2);
                int codeLength = codeCity.IndexOf(' ');
                this.TextBoxAddress.Text = address.Substring(0, address.IndexOf(','));
                this.TextBoxCode.Text = codeCity.Substring(0, codeLength);
                this.TextBoxCity.Text = codeCity.Substring(address.IndexOf(' ') + 1); 


            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                query = Request.QueryString["CustomerId"];
                Guid guid = new Guid(query);
                Customer customer = db.Customers.Single(cu => cu.CustomerId.Equals(guid));
                if (!String.IsNullOrEmpty(this.TextBoxName.Text))
                    customer.Name = this.TextBoxName.Text;
                if (!String.IsNullOrEmpty(this.TextBoxSurname.Text))
                    customer.Surname = this.TextBoxSurname.Text;
                if (!String.IsNullOrEmpty(this.TextBoxTelephone.Text))
                    customer.Telephone = this.TextBoxTelephone.Text;
                if (!String.IsNullOrEmpty(this.TextBoxAddress.Text) && !String.IsNullOrEmpty(this.TextBoxCode.Text) && !String.IsNullOrEmpty(this.TextBoxCity.Text))
                    customer.Address = this.TextBoxAddress.Text + ", " + this.TextBoxCode.Text + " " + this.TextBoxCity.Text;
                db.SaveChanges();
                Response.Redirect("Default.aspx");

            }
            catch
            {
                this.LabelMessage.Text = "Can't edit this customer!";
            }
        }
    }
}