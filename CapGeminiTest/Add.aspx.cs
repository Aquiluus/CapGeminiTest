using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace CapGeminiTest
{
    public partial class Add : System.Web.UI.Page, Utilities
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                VerifyFormsCorrect();
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

        public Boolean VerifyFormsCorrect()
        {
            var regexItemName = new Regex("^[a-zA-Zęóąśłżźćń]*$");
            var regexItemAddress = new Regex("^[a-zA-Z0-9 -ęóąśłżźćń]*$");
            var regexItemSurname = new Regex("^[a-zA-Zęóąśłżźćń ]*$");
            var regexItemTelephone = new Regex("0-9");
            try
            {
                if (!String.IsNullOrEmpty(this.TextBoxName.Text))
                {
                    if (!regexItemName.IsMatch(this.TextBoxName.Text))
                    {
                        throw new Exception("Name cotains invalid characters");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return true;
        }
    }
}