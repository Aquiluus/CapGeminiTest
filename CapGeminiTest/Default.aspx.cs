using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapGeminiTest
{
    public partial class Default : System.Web.UI.Page
    { 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                FillData();
        }

        private void FillData()
        {
            this.customersGridView.DataSource = DatabaseConnector.GetInstance().Database.Customers.Select(customer => new
            {
                Name = customer.Name,
                Surname = customer.Surname,
                Telephone = customer.Telephone,
                Address = customer.Address,
                CustomerId = customer.CustomerId
            }).ToList();
            this.customersGridView.DataBind();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField hiddenId = (HiddenField)linkButton.FindControl("HiddenFieldCustomerId");
            Guid guid = new Guid(hiddenId.Value);
            Customer customer = DatabaseConnector.GetInstance().Database.Customers.Single(cu => cu.CustomerId.Equals(guid));
            DatabaseConnector.GetInstance().Database.Customers.Remove(customer);
            DatabaseConnector.GetInstance().Database.SaveChanges();
            FillData();
        }
    }
}