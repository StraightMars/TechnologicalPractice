// Copyright: Maxim Saplin 2010, 2011
// Under LGPL License

using System;
using System.Web.UI.WebControls;

namespace SampleWebApplication
{
    public partial class Default2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var years = new int[20];
                var currentYear = DateTime.Now.Year;

                for (int i = 0; i < years.Length; i++)
                    years[i] = currentYear--;

                yearsDropDownCheckBoxes.DataSource = years;
                yearsDropDownCheckBoxes.DataBind();
            }
        }

        protected void checkBoxes_SelcetedIndexChanged(object sender, EventArgs e)
        {
            selectedItemsPanel.Controls.Clear();

            foreach (ListItem item in (sender as ListControl).Items)
            {
                if (item.Selected)
                    selectedItemsPanel.Controls.Add(new Literal() { Text = item.Text + " : " + item.Value + "<br/>" });
            }
        }
    }
}