// Copyright: Maxim Saplin 2010, 2011
// Under LGPL License

using System;
using System.Web.UI.WebControls;

namespace SampleWebApplication
{
    public partial class DefaultUpdatePanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkBoxes1.Texts.SelectBoxCaption = "SelectBoxCaption";
                checkBoxes2.Style.SelectBoxWidth = 200;
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

        protected void postBackButton_Click(object sender, EventArgs e)
        {
            checkBoxes_SelcetedIndexChanged(checkBoxes2, e);
        }

        protected void changeStyleLinkButton_Click(object sender, EventArgs e)
        {
            checkBoxes1.Style.SelectBoxCssClass = "dd_chk_select_cust";
            checkBoxes1.Style.SelectBoxWidth = 200;
            checkBoxes1.Style.DropDownBoxBoxWidth = 200;
            checkBoxes1.Style.DropDownBoxBoxHeight = 100;
        }

        protected void switchSelectAllLinkButton_Click(object sender, EventArgs e)
        {
            checkBoxes3.UseSelectAllNode = !checkBoxes3.UseSelectAllNode;
        }


        protected void switchAutoPostBackLinkButton_Click(object sender, EventArgs e)
        {
            checkBoxes2.AutoPostBack = !checkBoxes2.AutoPostBack;
        }

        protected void switchButtonsLinkButton_Click(object sender, EventArgs e)
        {
            checkBoxes2.UseButtons = !checkBoxes2.UseButtons;
        }

        protected void showHideLinkButton_Click(object sender, EventArgs e)
        {
            checkBoxes1.Visible = !checkBoxes1.Visible;
        }


        protected void showHidePanelLinkButton_Click(object sender, EventArgs e)
        {
            updatePanel.Visible = !updatePanel.Visible;
        }

        protected void selectDeselectLinkButton_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in checkBoxes1.Items)
            {
                item.Selected = !item.Selected;
            }
        }
    }
}