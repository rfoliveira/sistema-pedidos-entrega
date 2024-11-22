<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="SisLog.Client.Scripts.Usuarios" %>

<asp:Content ID="UsuariosContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <section class="content">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title">Usuários</h3>
                    <div class="card-tools">
                        <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                            <i class="fas fa-minus"></i>
                        </button>
                        <button type="button" class="btn btn-tool" data-card-widget="remove" title="Remove">
                            <i class="fas fa-times"></i>
                        </button>
                    </div>
                </div>
                <div class="card-body p-0">
                    <table class="table table-striped projects">
                        <asp:Repeater ID="RptUsuarios" DataSourceID="DsUsuarios" runat="server">
                            <HeaderTemplate>
                                <tr>
                                    <th>#</th>
                                    <th>Nome</th>
                                    <th>Email</th>
                                    <th>Ações</th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#DataBinder.Eval(Container.DataItem, "Id") %></td>
                                    <td><%#DataBinder.Eval(Container.DataItem, "Nome") %></td>
                                    <td><%#DataBinder.Eval(Container.DataItem, "Email") %></td>
                                    <td class="project-actions text-right">
                                        <asp:LinkButton 
                                            CssClass="btn btn-primary btn-sm" 
                                            Text="Ver"
                                            CommandArgument="<%#DataBinder.Eval(Container.DataItem, "Id") %>"
                                            CommandName="View"
                                            OnCommand="Action_Command"
                                            runat="server">
                                            <i class="fas fa-folder"></i>
                                        </asp:LinkButton>

                                        <asp:LinkButton 
                                            CssClass="btn btn-info btn-sm"
                                            Text="Editar"
                                            CommandArgument="<%#DataBinder.Eval(Container.DataItem, "Id") %>"
                                            CommandName="Edit"
                                            OnCommand="Action_Command"
                                            runat="server">
                                            <i class="fas fa-pencil-alt"></i>
                                        </asp:LinkButton>

                                        <asp:LinkButton
                                            CssClass="btn btn-danger btn-sm"
                                            Text="Remover"
                                            CommandArgument="<%#DataBinder.Eval(Container.DataItem, "Id") %>"
                                            CommandName="Delete"
                                            OnCommand="Action_Command"
                                            runat="server">
                                            <i class="fas fa-trash"></i>
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </section>
    </div>

</asp:Content>
