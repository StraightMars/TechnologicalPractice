<%--  Copyright: Maxim Saplin 2010, 2011
      Under LGPL License --%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="SampleWebApplication.Default2"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DropDownCheckBoxes - sample page</title>
    <link rel="Stylesheet" type="text/css" href="Styles/Site.css" />
    <link rel="Stylesheet" type="text/css" href="Styles/CustomDDStyles.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 2px 10px 10px 20px;">
        <div>
            <h1>
                Please specify car parameters</h1>
            <br />
            <asp:DropDownCheckBoxes ID="makeDropDownCheckBoxes" runat="server" OnSelectedIndexChanged="checkBoxes_SelcetedIndexChanged"
                AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True">
                <Style SelectBoxWidth="160" DropDownBoxBoxWidth="160" DropDownBoxBoxHeight="115" />
                <Texts SelectBoxCaption="Car make" />
                <Items>
                    <asp:ListItem Text="Acura" Value="1" />
                    <asp:ListItem Text="BMW" Value="2" />
                    <asp:ListItem Text="Citroen" Value="3" />
                    <asp:ListItem Text="Ford" Value="4" />
                    <asp:ListItem Text="Jeep" Value="5" />
                    <asp:ListItem Text="Kia" Value="6" />
                    <asp:ListItem Text="Lancia" Value="7" />
                    <asp:ListItem Text="Lexus" Value="8" />
                    <asp:ListItem Text="Mazda" Value="8" />
                    <asp:ListItem Text="Mercedes" Value="8" />
                    <asp:ListItem Text="Mitsubishi" Value="8" />
                    <asp:ListItem Text="Toyota" Value="8" />
                </Items>
            </asp:DropDownCheckBoxes>
            &nbsp;
            <asp:DropDownCheckBoxes ID="engineDropDownCheckBoxes" runat="server" OnSelectedIndexChanged="checkBoxes_SelcetedIndexChanged"
                AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True">
                <Style SelectBoxWidth="160" DropDownBoxBoxWidth="160"  />
                <Texts SelectBoxCaption="Engine types" />
                <Items>
                    <asp:ListItem Text="Petrol" Value="1" />
                    <asp:ListItem Text="Diesel" Value="2" />
                    <asp:ListItem Text="LPG" Value="3" />
                    <asp:ListItem Text="Hybrid" Value="4" />
                    <asp:ListItem Text="Electric" Value="5" />
                </Items>
            </asp:DropDownCheckBoxes>
            <br />
            <br />
            <asp:DropDownCheckBoxes ID="countryDropDownCheckBoxes" runat="server" OnSelectedIndexChanged="checkBoxes_SelcetedIndexChanged"
                AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True">
                <Style SelectBoxWidth="160" DropDownBoxBoxHeight="60" />
                <Texts SelectBoxCaption="Country" />
            </asp:DropDownCheckBoxes>
            &nbsp;
            <asp:DropDownCheckBoxes ID="yearsDropDownCheckBoxes" runat="server" OnSelectedIndexChanged="checkBoxes_SelcetedIndexChanged"
                AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True">
                <Style SelectBoxWidth="160" DropDownBoxBoxWidth="160" DropDownBoxBoxHeight="80" />
                <Texts SelectBoxCaption="Year" />
            </asp:DropDownCheckBoxes>
            &nbsp;
        </div>
        <div style="padding-top: 20px;">
            <h1>
                Selected items (updated whenever postback from any of the controls occurs)</h1>
            <asp:Panel ID="selectedItemsPanel" runat="server" meta:resourcekey="selectedItemsPanelResource1">
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
