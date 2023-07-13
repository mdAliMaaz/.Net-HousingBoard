<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="MyShop.Stock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row">
 <div class="col shadow py-3 rounded">
     <asp:Label ID="msg" runat="server" class="fs-6 text-center text-info mb-4"></asp:Label>
     <p class="fw-bold mt-3 mb-5 text-primary">
         Add New Item Here!</p>
     <div class="mb-2">
        <asp:Label ID="Label1" runat="server" Text="Item Name:" class="form-label fw-bold "></asp:Label>
        <asp:TextBox AutoCompleteType="Disabled" ID="nameTb" runat="server"  class="form-control"></asp:TextBox>
      </div>

      <div class="mb-2">
        <asp:Label ID="Label2" runat="server" Text="Item Quantity:" class="form-label fw-bold"></asp:Label>
        <asp:TextBox AutoCompleteType="Disabled" ID="QuantityTb" runat="server" class="form-control"></asp:TextBox>
    </div>

    <div class="mb-2">
        <asp:Label ID="Label3" runat="server" Text="Rate Per Item:" class="form-label fw-bold"></asp:Label>
        <asp:TextBox AutoCompleteType="Disabled" ID="RateTb" runat="server" class="form-control"></asp:TextBox>
        <div>
         <asp:Button ID="Save" runat="server" Text="Save" class="btn btn-danger mt-3 mx-2 btn-sm" OnClick="Button1_Click" />
         <asp:Button ID="Clear" runat="server" Text="Clear" class="btn btn-warning mt-3 mx-2 btn-sm" OnClick="Clear_Click" />
        </div>
    </div>
        </div>

   <div class="col">
       <p class="text-center fw-bolder text-primary">Stock Table</p>
        <asp:GridView ID="GridView1" runat="server" class="table table-bordered  table-dark table-hover"></asp:GridView>
   </div>

</div>
</asp:Content>
