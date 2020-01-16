<%--  Copyright: Maxim Saplin 2010, 2011
      Under LGPL License --%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultUpdatePanel.aspx.cs"
    Inherits="SampleWebApplication.DefaultUpdatePanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DropDownCheckBoxes - sample page</title>
    <link rel="Stylesheet" type="text/css" href="Styles/Site.css" />
    <link rel="Stylesheet" type="text/css" href="Styles/CustomDDStyles.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <div style="padding: 2px 10px 10px 20px;">
                <div>
                    <a href="Default.aspx">Switch to NON UpdatePanel version</a>
                    <br />
                    <h1>
                        DropDownCheckBoxes controls</h1>
                    <br />
                    <span style="width: 360px; display: inline-block">Drop down without buttons (AutoPostBack
                        = 'True')</span>
                    <asp:DropDownCheckBoxes ID="checkBoxes1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="checkBoxes_SelcetedIndexChanged" Visible="false">
                        <Style SelectBoxWidth="100" />
                        <Texts SelectBoxCaption="Some big text which doesn't fit the control" />
                        <Items>
                            <asp:ListItem Text="Option 1" Value="1" />
                            <asp:ListItem Text="Option 2" Value="2" />
                            <asp:ListItem Text="Option 3 + Some big text which doesn't fit the control" Value="3" />
                            <asp:ListItem Text="Option 4" Value="4" />
                            <asp:ListItem Text="Option 5" Value="5" />
                            <asp:ListItem Text="Option 6" Value="6" />
                            <asp:ListItem Text="Option 7" Value="7" />
                        </Items>
                    </asp:DropDownCheckBoxes>
                    <br />
                    <asp:LinkButton ID="changeStyleLinkButton" runat="server" Text="Change style" OnClick="changeStyleLinkButton_Click" />
                    <asp:LinkButton ID="showHideLinkButton" runat="server" Text="Show/Hide" OnClick="showHideLinkButton_Click" />
                    <asp:LinkButton ID="selectDeselectLinkButton" runat="server" Text="Inverse selection server side" OnClick="selectDeselectLinkButton_Click" />
                    <br />
                    <br />
                    <span style="width: 360px; display: inline-block">Drop down (AutoPostBack = '<%= checkBoxes2.AutoPostBack %>',
                        'UseButtons' = '<%= checkBoxes2.UseButtons %>' )</span>
                    <asp:DropDownCheckBoxes ID="checkBoxes2" runat="server" OnSelectedIndexChanged="checkBoxes_SelcetedIndexChanged">
                        <Texts SelectBoxCaption="Some big text which doesn't fit the control" />
                        <Items>
                            <asp:ListItem Text="Option 1" Value="1" />
                            <asp:ListItem Text="Option 2" Value="2" />
                            <asp:ListItem Text="Option 3 + Some big text which doesn't fit the control" Value="3" />
                            <asp:ListItem Text="Option 4" Value="4" />
                            <asp:ListItem Text="Option 5" Value="5" />
                            <asp:ListItem Text="Option 6" Value="6" />
                            <asp:ListItem Text="Option 7" Value="7" />
                        </Items>
                    </asp:DropDownCheckBoxes>
                    <br />
                    <asp:LinkButton ID="postBackButton" runat="server" Text="Do postback" OnClick="postBackButton_Click" />
                    &nbsp;
                    <asp:LinkButton ID="switchAutoPostBackLinkButton" runat="server" Text="Switch 'AutoPostBack'"
                        OnClick="switchAutoPostBackLinkButton_Click" />
                    &nbsp;
                    <asp:LinkButton ID="switchButtonsLinkButton" runat="server" Text="Switch 'UseButtons'"
                        OnClick="switchButtonsLinkButton_Click" />
                    <br />
                    <br />
                    <span style="width: 360px; display: inline-block">Drop down with buttons (UseSelectAllNode
                        = '<%= checkBoxes3.UseSelectAllNode%>')</span>
                    <asp:DropDownCheckBoxes ID="checkBoxes3" runat="server" UseButtons="true" UseSelectAllNode="false"
                        OnSelectedIndexChanged="checkBoxes_SelcetedIndexChanged">
                        <Texts OkButton="Yes" CancelButton="No" SelectAllNode="ALL" SelectBoxCaption="Do selection" />
                        <Items>
                            <asp:ListItem Text="Option 1" Value="1" />
                            <asp:ListItem Text="Option 2" Value="2" />
                            <asp:ListItem Text="Option 3" Value="3" />
                            <asp:ListItem Text="Option 4" Value="4" />
                            <asp:ListItem Text="Option 5" Value="5" />
                            <asp:ListItem Text="Option 6" Value="6" />
                            <asp:ListItem Text="Option 7" Value="7" />
                        </Items>
                    </asp:DropDownCheckBoxes>
                    <br />
                    <asp:LinkButton ID="switchSelectAllLinkButton" runat="server" Text="Switch 'UseSelectAllNode'"
                        OnClick="switchSelectAllLinkButton_Click" />
                </div>
                <div style="padding-top: 20px;">
                    <h1>
                        Selected items (updated whenever postback from any of the controls occurs)</h1>
                    <asp:Panel ID="selectedItemsPanel" runat="server">
                    </asp:Panel>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:LinkButton ID="showHidePanelLinkButton" runat="server" Text="Show/Hide update panel" OnClick="showHidePanelLinkButton_Click" />
    </form>
</body>
</html>
