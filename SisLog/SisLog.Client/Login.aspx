<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SisLog.Client.Login" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>SisLog - Login</title>

    <webopt:BundleReference runat="server" Path="~/Content/fontawesome" />
    <asp:PlaceHolder runat="server">
        <%: Styles.Render("~/bundles/adminlte/css") %>
    </asp:PlaceHolder>
</head>

<body class="hold-transition login-page">
    <div class="login-box">
        <div class="card card-outline card-primary">
            <div class="card-header text-center">
                SisLog - Login
            </div>
            <div class="card-body">
                <p class="login-box-msg">Inicie sua sessão</p>

                <form runat="server" id="FrmLogin">
                    <div class="input-group mb-3">
                        <asp:Label runat="server" ID="LblErrorMessages" ForeColor="Red" />
                    </div>
                    <div class="input-group mb-3">
                        <input type="email" class="form-control" placeholder="Email" id="TxtEmail" runat="server">
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <i class="fa-solid fa-envelope"></i>
                            </div>
                        </div>
                    </div>

                    <div class="input-group mb-3">
                        <input type="password" class="form-control" placeholder="Senha" id="TxtSenha" runat="server">
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <i class="fa-solid fa-lock"></i>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-8">
                            <div class="icheck-primary">
                                <input type="checkbox" id="CbxLembrar" runat="server">
                                <label for="lembrar">Lembrar</label>
                            </div>
                        </div>
                        <div class="col-4">
                            <asp:Button ID="BtnVai" OnClick="BtnLogin_Click" Text="Vai Disgrama!" CssClass="btn btn-primary btn-block" runat="server" />
                        </div>
                    </div>
                </form>

                <p class="mb-0">
                    <a href="Register.aspx" class="text-center">Registrar</a>
                </p>
            </div>
        </div>
    </div>

    <script src="Scripts/jquery-3.7.0.min.js"></script>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/adminlte/js") %>
    </asp:PlaceHolder>
</body>
</html>
