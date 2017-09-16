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

        private CGTDataEntities db = new CGTDataEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                FillData();
        }

        private void FillData()
        {
            this.customersGridView.DataSource = db.Customers.Select(customer => new
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
            Customer customer = db.Customers.Single(cu => cu.CustomerId.Equals(guid));
            db.Customers.Remove(customer);
            db.SaveChanges();
            FillData();
        }
    }
}