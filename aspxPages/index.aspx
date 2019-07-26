<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SalesTax.WebPages.index" %>
<!--
    HTML/ASP.NET code used in my solution for DealerOn's coding test.
    This page is designed to solve problem number two: Sales Taxes.
    Author: Jeffrey Trotz
    Date: 7/24/2019
-->
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Sales Taxes</title>     

        <!--
            Markup to make the page "responsive" and to import jQuery,  
            my CSS style sheet, and my Javascript script
        -->
        <meta name="viewport" content="width=device-width, initial-scale=1" />       
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
        <script src="../scripts/javaScript.js" type="text/javascript"></script>
        <link href="../css/styleSheet.css" rel="stylesheet" />
    </head>
    <body>        
        <div id="outerDiv">
            <div id="innerDiv" class="div">

                <!--
                    Form where the item name, price, etc is entered so
                    the sales tax and final price can be calculated
                    by the codebehind page
                -->
                <form id="entryForm" runat="server">
                    <asp:Label runat="server" Text="Item Type" />
                    <asp:DropDownList runat="server" CssClass="textBox" ID="ddList">
                        <asp:ListItem Value="Default" Text="Choose Item Type"></asp:ListItem>
                        <asp:ListItem Value="Book" Text="Book"></asp:ListItem>
                        <asp:ListItem Value="Food" Text="Food"></asp:ListItem>
                        <asp:ListItem Value="Medicaton" Text="Medication"></asp:ListItem>
                        <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label runat="server" Text="Item Name" />
                    <asp:TextBox runat="server" CssClass="textBox" ID="txtName" />
                    <br />
                    <br />
                    <asp:Label runat="server" Text="Price" />
                    <asp:TextBox runat="server" CssClass="textBox" ID="txtPrice" />         
                    <br />   
                    <br />
                    <asp:Label runat="server" Text="Quantity" />
                    <asp:TextBox runat="server" CssClass="textBox" ID="txtQuantity" />                
                    <br />
                    <br />
                    <asp:Label runat="server" Text="Imported" />
                    <asp:CheckBox runat="server" ID="cBxImported"/>
                    <br />
                    <br />
                    <asp:Button runat="server" CssClass="button" ID="btnReset" Text ="Reset Total" OnClick="BtnReset_Click" />
                    <asp:Button runat="server" CssClass="button" ID="btnClearForm" Text="Clear Form" OnClick="BtnClear_Click" />
                    <asp:Button runat="server" CssClass="button" ID="btnSubmit" Text="Submit Item" OnClick="BtnSubmit_Click" />
                </form>
            </div>

            <!--
                Div where an error message or the final results are shown
                after the data has been submited
            -->
            <div id="resultDiv" runat="server" class="div" Visible="false">
                <asp:Label runat="server" ID="lblResults" Text="" />                
                <asp:Label runat="server" ID="lblTaxTotal" Text="" />
                <asp:Label runat="server" ID="lblOrderTotal" Text="" />
            </div>
        </div>
    </body>
</html>