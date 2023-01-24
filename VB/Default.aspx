<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v14.1, Version=14.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxTreeList ID="treeList" runat="server" ClientInstanceName="treeList" AutoGenerateColumns="False"
            KeyFieldName="ItemId" ParentFieldName="ParentId" KeyboardSupport="True" OnDataBinding="atlSelection_DataBinding" OnCustomCallback="treeList_CustomCallback">
            <Columns>
                <dx:TreeListTextColumn FieldName="Code" VisibleIndex="0">
                </dx:TreeListTextColumn>
                <dx:TreeListTextColumn FieldName="Name" VisibleIndex="1">
                </dx:TreeListTextColumn>
                <dx:TreeListTextColumn FieldName="Description" VisibleIndex="2">
                </dx:TreeListTextColumn>
                <dx:TreeListTextColumn FieldName="ItemType" Visible="false">
                </dx:TreeListTextColumn>
                <dx:TreeListTextColumn FieldName="Price" VisibleIndex="3">
                    <PropertiesTextEdit DisplayFormatString="{0:C}">
                    </PropertiesTextEdit>
                </dx:TreeListTextColumn>
            </Columns>
            <SettingsPager PageSize="20" Mode="ShowPager"></SettingsPager>
            <SettingsBehavior AllowFocusedNode="true" AutoExpandAllNodes="True" AllowSort="False"
                FocusNodeOnExpandButtonClick="true" />
            <SettingsSelection Enabled="True" />
            <SettingsEditing AllowNodeDragDrop="true" Mode="EditForm" />
        </dx:ASPxTreeList>
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Save selection" AutoPostBack="false">
            <ClientSideEvents Click="function (s, e) { treeList.PerformCallback('Save'); }" />
        </dx:ASPxButton>
        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Restore selection" AutoPostBack="false">
            <ClientSideEvents Click="function (s, e) { treeList.PerformCallback('Restore'); }" />
        </dx:ASPxButton>
    </form>
</body>
</html>