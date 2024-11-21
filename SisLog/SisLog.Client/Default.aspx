<%@ Page Title="SisLog - Principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SisLog.Client._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="hold-transition layout-top-nav">
        <div class="wrapper">
            <nav class="main-header navbar navbar-expand-md navbar-light navbar-white">
                <div class="container">
                    <a href="#" class="navbar-brand">
                        <span class="brand-text font-weight-light">SisLog</span>
                    </a>
                    <button class="navbar-toggler order-1"
                        type="button"
                        data-toggle="collapse"
                        data-target="#navbarCollapse"
                        aria-controls="navbarCollapse"
                        aria-expanded="false"
                        aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>

                    <div class="collapse navbar-collapse order-3" id="navbarCollapse">
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <a href="Usuarios.aspx" class="nav-link">Usuários</a>
                            </li>
                            <li class="nav-item">
                                <a href="Pedidos.aspx" class="nav-link">Pedidos</a>
                            </li>
                        </ul>
                    </div>

                    <ul class="order-1 order-md-3 navbar-nav navbar-no-expand ml-auto">
                        
                        <li class="nav-item">
                            <a class="nav-link" data-widget="control-sidebar" data-slide="true" href="#" role="button">
                                <i class="fas fa-th-large"></i>
                            </a>
                        </li>
                    </ul>
                </div>
            </nav>
        </div>
    </div>

</asp:Content>
