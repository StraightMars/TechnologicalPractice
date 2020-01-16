<%--  Copyright: Maxim Saplin 2010, 2011
      Under LGPL License --%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleWebApplication.Default"
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
            <a href="DefaultUpdatePanel.aspx">Switch to UpdatePanel version</a>
            <br />
            <h1>
                DropDownCheckBoxes controls</h1>
            <br />
            <span style="width: 360px; display: inline-block">Drop down without buttons (AutoPostBack
                = 'True')</span>
            <asp:DropDownCheckBoxes ID="checkBoxes1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="checkBoxes_SelcetedIndexChanged"
                AddJQueryReference="True" meta:resourcekey="checkBoxes1Resource1" UseButtons="False"
                UseSelectAllNode="True">
                <Style SelectBoxWidth="100" />
                <Texts SelectBoxCaption="Some big text which doesn't fit the control" />
                <Items>
                    <asp:ListItem Text="Option 1" Value="1" meta:resourcekey="ListItemResource1" />
                    <asp:ListItem Text="Option 2" Value="2" meta:resourcekey="ListItemResource2" />
                    <asp:ListItem Text="Option 3 + Some big text which doesn't fit the control" Value="3"
                        meta:resourcekey="ListItemResource3" />
                    <asp:ListItem Text="Option 4" Value="4" meta:resourcekey="ListItemResource4" />
                    <asp:ListItem Text="Option 5" Value="5" meta:resourcekey="ListItemResource5" />
                    <asp:ListItem Text="Option 6" Value="6" meta:resourcekey="ListItemResource6" />
                    <asp:ListItem Text="Option 7" Value="7" meta:resourcekey="ListItemResource7" />
                </Items>
            </asp:DropDownCheckBoxes>
            <br />
            <asp:LinkButton ID="changeStyleLinkButton" runat="server" Text="Change style" OnClick="changeStyleLinkButton_Click"
                meta:resourcekey="changeStyleLinkButtonResource1" />
            <asp:LinkButton ID="selectDeselectLinkButton" runat="server" Text="Inverse selection server side"
                OnClick="selectDeselectLinkButton_Click" />
            <br />
            <br />
            <span style="width: 360px; display: inline-block">Drop down (AutoPostBack = '<%= checkBoxes2.AutoPostBack %>',
                'UseButtons' = '<%= checkBoxes2.UseButtons %>' )</span>
            <asp:DropDownCheckBoxes ID="checkBoxes2" runat="server" OnSelectedIndexChanged="checkBoxes_SelcetedIndexChanged"
                AddJQueryReference="True" meta:resourcekey="checkBoxes2Resource1" UseButtons="False"
                UseSelectAllNode="True">
                <Style SelectBoxWidth="" DropDownBoxBoxWidth="" DropDownBoxBoxHeight=""></Style>
                <Texts SelectBoxCaption="Some big text which doesn't fit the control" />
                <Items>
                    <asp:ListItem Text="Option 1" Value="1" meta:resourcekey="ListItemResource8" />
                    <asp:ListItem Text="Option 2" Value="2" meta:resourcekey="ListItemResource9" />
                    <asp:ListItem Text="Option 3 + Some big text which doesn't fit the control" Value="3"
                        meta:resourcekey="ListItemResource10" />
                    <asp:ListItem Text="Option 4" Value="4" meta:resourcekey="ListItemResource11" />
                    <asp:ListItem Text="Option 5" Value="5" meta:resourcekey="ListItemResource12" />
                    <asp:ListItem Text="Option 6" Value="6" meta:resourcekey="ListItemResource13" />
                    <asp:ListItem Text="Option 7" Value="7" meta:resourcekey="ListItemResource14" />
                </Items>
            </asp:DropDownCheckBoxes>
            <br />
            <asp:LinkButton ID="postBackButton" runat="server" Text="Do postback" OnClick="postBackButton_Click"
                meta:resourcekey="postBackButtonResource1" />
            &nbsp;
            <asp:LinkButton ID="switchAutoPostBackLinkButton" runat="server" Text="Switch 'AutoPostBack'"
                OnClick="switchAutoPostBackLinkButton_Click" meta:resourcekey="switchAutoPostBackLinkButtonResource1" />
            &nbsp;
            <asp:LinkButton ID="switchButtonsLinkButton" runat="server" Text="Switch 'UseButtons'"
                OnClick="switchButtonsLinkButton_Click" meta:resourcekey="switchButtonsLinkButtonResource1" />
            <br />
            <br />
            <span style="width: 360px; display: inline-block">Drop down with buttons (UseSelectAllNode
                = '<%= checkBoxes3.UseSelectAllNode%>')</span>
            <asp:DropDownCheckBoxes ID="checkBoxes3" runat="server" UseButtons="True" UseSelectAllNode="False"
                OnSelectedIndexChanged="checkBoxes_SelcetedIndexChanged" AddJQueryReference="True"
                meta:resourcekey="checkBoxes3Resource1">
                <Style SelectBoxWidth="" DropDownBoxBoxWidth="" DropDownBoxBoxHeight=""></Style>
                <Texts OkButton="Yes" CancelButton="No" SelectAllNode="ALL" SelectBoxCaption="Do selection" />
                <Items>
                    <asp:ListItem Text="Option 1" Value="1" meta:resourcekey="ListItemResource15" />
                    <asp:ListItem Text="Option 2" Value="2" meta:resourcekey="ListItemResource16" />
                    <asp:ListItem Text="Option 3" Value="3" meta:resourcekey="ListItemResource17" />
                    <asp:ListItem Text="Option 4" Value="4" meta:resourcekey="ListItemResource18" />
                    <asp:ListItem Text="Option 5" Value="5" meta:resourcekey="ListItemResource19" />
                    <asp:ListItem Text="Option 6" Value="6" meta:resourcekey="ListItemResource20" />
                    <asp:ListItem Text="Option 7" Value="7" meta:resourcekey="ListItemResource21" />
                </Items>
            </asp:DropDownCheckBoxes>
            <br />
            <asp:LinkButton ID="switchSelectAllLinkButton" runat="server" Text="Switch 'UseSelectAllNode'"
                OnClick="switchSelectAllLinkButton_Click" meta:resourcekey="switchSelectAllLinkButtonResource1" />
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
