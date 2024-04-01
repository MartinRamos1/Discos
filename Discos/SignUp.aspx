﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Discos.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-lg-10 col-xl-9 mx-auto">
                <div class="card flex-row my-5 border-0 shadow rounded-3 overflow-hidden">
<%--                    <div class="card-img-left d-none d-md-flex">
                        <!-- Background image for card set in CSS! -->
                    </div>--%>
                    <div class="card-body p-4 p-sm-5">
                        <h5 class="card-title text-center mb-5 fw-light fs-5">Registro</h5>
                        <div>

                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtEmail" type="email" class="form-control" placeholder="name@example.com" runat="server"></asp:TextBox>
                                <label>Email</label>
                            </div>

                            <hr>

                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtPass" type="password" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                                 <label>Contraseña</label>
                            </div>

                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtPassConfirm" type="password" class="form-control" placeholder="Confirm Password" runat="server"></asp:TextBox>
                                <label>Confirmar Contraseña</label>
                            </div>

                            <div class="d-grid mb-2">
                                <asp:Label ID="lblErrorSignUp" CssClass="mb-1 text-danger" runat="server" Text=""></asp:Label>
                                <asp:Button ID="btnSignUp" OnClick="btnSignUp_Click" class="btn btn-lg btn-light border btn-login fw-bold text-uppercase" runat="server" Text="Registrarte" />
                            </div>

                            <a class="d-block text-center" href="Login.aspx">
                                <p class="text-muted">Ya estas registrado? Inicia sesión</p>
                            </a>

                            <hr class="my-4">

                            

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
