<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Discos.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.13.1/css/all.min.css" integrity="sha256-2XFplPlrFClt0bIdPgpz8H7ojnk10H69xRqd9+uTShA=" crossorigin="anonymous" />
    <link href="style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="m-2">
        <%--<%if ((dominio.User)Session["user"] != null && negocio.UserNegocio.isAdmin((dominio.User)Session["user"]))
            {%>
        <asp:Button ID="btnAgregarDisco" runat="server" CssClass="btn btn-primary" Text="Agregar disco" OnClick="btnAgregarDisco_Click" />
        <%}%>--%>
    </div>

    <div class="container">
        <div class="row mt-n5">
            <% foreach (dominio.Disco disco in ListaDiscos)
                { %>
            <div class="col-md-6 col-lg-4 mt-5 wow fadeInUp" data-wow-delay=".2s" style="visibility: visible; animation-delay: 0.2s; animation-name: fadeInUp;">
                <div class="blog-grid">
                    <div class="blog-grid-img position-relative">
                        <img src="<%: disco.UrlImagenTapa%>" class="card-img-top" alt="<%: disco.Titulo%>">
                    </div>
                    <div class="blog-grid-text p-4">
                        <h3 class="h5 mb-3"><a href="AgregarDisco.aspx?id=<%: disco.Id%>"><%: disco.Titulo%></a></h3>

                        <%if (disco.CantidadCanciones == 1)
                            { %>
                        <p class="display-30"><%: disco.CantidadCanciones%> canción</p>
                        <%}
                            else
                            {%>
                        <p class="display-30"><%: disco.CantidadCanciones%> canciones</p>
                        <%}%>

                        <%if ((dominio.User)Session["user"] != null && negocio.UserNegocio.isAdmin((dominio.User)Session["user"]))
                            {%>
                        <a href="AgregarDisco.aspx?id=<%: disco.Id%>" cssclass="btn btn-dark">Modificar</a>
                        <%}%>
                        <div class="meta meta-style2">
                            <ul>
                                <li><a href="#!"><i class="fas fa-calendar-alt"></i><%: disco.FechaLanzamiento.ToString("d/M/yyyy")%></a>
                            </ul>
                        </div>

                    </div>
                </div>
            </div>
            <%}%>
        </div>
    </div>














    <%--<asp:GridView ID="dgvDiscos" runat="server" CssClass="table table-striped"></asp:GridView>--%>
</asp:Content>
