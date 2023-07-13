<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Chart.aspx.cs" Inherits="MyShop.Report" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
                <p class="text-center fw-bold fs-4 text-uppercase text-primary"> Stocks Available</p>
        <div class="row">

            <div class="col-5 mt-5">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-dark table-bordered table-hover"></asp:GridView>
            </div>

            <div class="col-5 mx-3 mt-5 ">
                <div class="d-flex mx-2 ">
                    <div class="shadow p-2 rounded">
                <asp:Chart ID="Chart1" runat="server" Height="400px" Palette="Fire" Width="400px" BackImageAlignment="Center" BorderlineColor="Black" EnableViewState="True" >
                    <Titles>
                        <asp:Title Text="Quantity"></asp:Title>
                    </Titles>
                    <Series>
                        <asp:Series Name="Series1" XValueMember="Item_Name" YValueMembers="Available_Quantity" YValuesPerPoint="4" IsXValueIndexed="True" IsValueShownAsLabel="True" Font="MS Reference Sans Serif, 10.8pt, style=Bold" ShadowColor="CadetBlue" BorderColor="Black" CustomProperties="DrawSideBySide=False, LabelStyle=Top, EmptyPointValue=Zero, DrawingStyle=LightToDark" IsVisibleInLegend="False"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <Area3DStyle Enable3D="True" />
                        </asp:ChartArea>
                    </ChartAreas>
                    <BorderSkin BorderWidth="3" />
                </asp:Chart>
                <p class="text-center fw-bold mt-3 text-warning"> Column Chart</p>
                    </div>

                    <div class="shadow  p-2 rounded">
                <asp:Chart ID="Chart2" runat="server" Height="400px" Palette="SemiTransparent" Width="400px" BorderlineWidth="3" BackImageAlignment="Center" BorderlineColor="" BorderlineDashStyle="Solid">
                      <Titles>
                        <asp:Title Text="Quantity"></asp:Title>
                    </Titles>
                    <Series>
                        <asp:Series Name="Series1" ChartType="Pie" IsXValueIndexed="True" MarkerBorderColor="SlateBlue" MarkerColor="0, 0, 64" Font="Arial, 10.2pt, style=Bold" IsValueShownAsLabel="True" IsVisibleInLegend="False" Label="#VAL-#VALX" LabelBorderDashStyle="NotSet" MarkerStyle="Square" ShadowColor="DarkOliveGreen" BackImageWrapMode="TileFlipX" Color="192, 192, 0" Palette="SemiTransparent" ShadowOffset="5" CustomProperties="3DLabelLineSize=45, PieLabelStyle=Outside, PieLineColor=Black, CollectedColor=ActiveBorder" ></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                              <Area3DStyle Enable3D="True" />
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                    <p class="text-center fw-bold mt-3 text-warning">Pie Chart</p>
                    </div>
                </div>
              
            </div>
           
        </div>
    </div>
</asp:Content>
