using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace CapGeminiTest
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Saving new data to dabase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = this.TextBoxName.Text;
                string surname = this.TextBoxSurname.Text;
                string telephone = this.TextBoxTelephone.Text;
                string address = this.TextBoxAddress.Text;
                string code = this.TextBoxCode.Text;
                string city = this.TextBoxCity.Text;
                Utilities.VerifyFormsCorrect(name, surname, telephone, address, code, city);
                Customer customer = new Customer();
                customer.CustomerId = Guid.NewGuid();
                customer.Name = this.TextBoxName.Text;
                customer.Surname = this.TextBoxSurname.Text;
                customer.Telephone = this.TextBoxTelephone.Text;
                customer.Address = this.TextBoxAddress.Text + ", " + this.TextBoxCode.Text + " " + this.TextBoxCity.Text;
                DatabaseConnector.GetInstance().Database.Customers.Add(customer);
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