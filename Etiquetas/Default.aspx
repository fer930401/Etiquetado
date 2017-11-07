<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Etiquetas._Default" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12" style="background-color: #FFEC9E;">
                <br />
                <div class="alert alert-warning text-center" role="alert">
                    <strong>
                        <span class="glyphicon glyphicon-folder-open" aria-hidden="true"></span> <asp:Label runat="server" Text="Por favor selecciona tu archivo Excel con la informacion solicitada." /></strong>
                </div>

                <br />
                <div class="form-inline">
                    <div class="form-group">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" Width="700" />
                    </div>
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-warning" OnClick="btnUpload_Click" />
                </div>
                <br />

                <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="PageIndexChanging" 
                              AllowPaging="true" HeaderStyle-BackColor="#363636" HeaderStyle-ForeColor="White"
                              CssClass="table table-hover" HeaderStyle-Height="50px" EmptyDataText="El archivo no tiene datos"
                              BackColor="White" PageSize="20" Width="50%">
                </asp:GridView>
                <asp:Button ID="btnImprimir" runat="server" Text="Imprime las etiquetas" CssClass="btn btn-success" OnClick="btnImprimir_Click" />
                <br />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
