using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapGeminiTest
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = new Customer();
                customer.CustomerId = Guid.NewGuid(); ;
                customer.Name = this.TextBoxName.Text;
                customer.Surname = this.TextBoxSurname.Text;
                customer.Telephone = this.TextBoxTelephone.Text;
                customer.Address = this.TextBoxAddress.Text + ", " + this.TextBoxCode.Text + " " + this.TextBoxCity.Text;
                DatabaseConnector.GetInstance().Database.Customers.Add(customer);
                DatabaseConnector.GetInstance().Database.SaveChanges();
                Response.Redirect("Default.aspx");
                
            }
            catch
            {
                this.LabelMessage.Text = "Can't add new Customer";
            }
        }
    }
}