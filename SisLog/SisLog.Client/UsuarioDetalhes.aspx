<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioDetalhes.aspx.cs" Inherits="SisLog.Client.UsuarioDetalhes" %>

<asp:Content ID="UsuarioDetalhesContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="card card-info">
                        <div class="card-header">
                            <h3 class="card-title">Usuário</h3>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <p class="form-control-plaintext">
                                    ID: <%= Usuario.Id.ToString() %>
                                </p>
                            </div>
                            <div class="form-group">
                                <label for="TxtNome">Nome</label>
                                <input type="text" class="form-control" id="TxtNome" placeholder="Nome">
                            </div>
                            <div class="form-group">
                                <label for="TxtEmail">Email</label>
                                <input type="email" class="form-control" id="TxtEmail" placeholder="Email">
                            </div>
                            <div class="form-group">
                                <label for="TxtSenha">Password</label>
                                <input type="password" class="form-control" id="TxtSenha" placeholder="Password">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
