<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="MyShop.Sales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row ">
        <div class="col container shadow py-3 rounded">
            <div>
                <asp:Label ID="msg" runat="server" CssClass="text-center text-info"></asp:Label>
                <p class="text-start fw-bold text-primary">Add New Sales!</p>

                <asp:Label runat="server" Text="Transaction Date:" class="form-label fw-bold"></asp:Label>
                <asp:TextBox ID="dateTb" runat="server" class="form-control mb-3" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label runat="server" Text="Item Name:" class="form-label  fw-bold"></asp:Label>
                <asp:DropDownList  AutoPostBack="true" ID="itemDdl" runat="server" CssClass="form-control" OnSelectedIndexChanged="itemDdl_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div>
                <asp:Label runat="server" Text="Purchase Quantity:" class="form-label fw-bold"></asp:Label>
                <asp:TextBox AutoCompleteType="Disabled" ID="PqtyTb" runat="server" class="form-control mb-3"></asp:TextBox>
            </div>
            <div class="mb-2">
                <asp:Label runat="server" Text="Available Quantity:" class="form-label  fw-bold"></asp:Label>
                <asp:Label runat="server" ID="QtyAvlLb" Text="0" CssClass="fw-bold text-danger"></asp:Label>
            </div>
            <div class="mb-2">
                <asp:Label runat="server" Text="RatePerItem:" class="form-label fw-bold"></asp:Label>
                <asp:Label runat="server" ID="RateLb" Text="0.0" CssClass=" text-warning fw-bold"></asp:Label>
            </div>
              <div class="mb-2">
                <asp:Label runat="server" Text="Total Amount:" class="form-label fw-bold"></asp:Label>
                <asp:Label ID="TotalTb" runat="server" class="form-lable mb-3 text-warning fw-bolder"></asp:Label>
            </div>
            <div>
                <asp:Button ID="saveBtn" runat="server" Text="Save" CssClass="btn btn-danger mt-3 mx-2  btn-sm" OnClick="saveBtn_Click" />
                <asp:Button ID="CkeckId" runat="server" Text="Check" CssClass="btn btn-primary mx-2 mt-3 btn-sm" OnClick="CkeckId_Click" />
                <asp:Button ID="clearBtn" runat="server" Text="Clear" CssClass="btn btn-warning mx-2  mt-3  btn-sm" OnClick="clearBtn_Click" />
            </div>
        </div>

        <div class="col container">
            <p class="text-center fw-bold mt-2 text-primary">Sales Table</p>

            <asp:GridView ID="GridView1" runat="server" CssClass="table table-dark table-bordered table-hover">
            </asp:GridView>
        </div>
    </div>
</asp:Content>
