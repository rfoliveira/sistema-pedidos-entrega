<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SisLog.Client.Register" %>

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

<body class="hold-transition register-page">
    <div class="register-box">
        <div class="card card-outline card-primary">
            <div class="card-header text-center">
                SisLog
            </div>
            <div class="card-body">
                <p class="login-box-msg">Registrar um novo usuário</p>
                <form runat="server" id="FrmRegistrar">
                    <div class="input-group mb-3">
                        <input type="text" class="form-control" placeholder="Nome Completo" name="TxtNome">
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-user"></span>
                            </div>
                        </div>
                    </div>

                    <div class="input-group mb-3">
                        <input type="email" class="form-control" placeholder="Email" name="TxtEmail">
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-envelope"></span>
                            </div>
                        </div>
                    </div>

                    <div class="input-group mb-3">
                        <input type="password" class="form-control" placeholder="Senha" name="TxtSenha">
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-lock"></span>
                            </div>
                        </div>
                    </div>

                    <div class="input-group mb-3">
                        <input type="password" class="form-control" placeholder="Confirme a senha" name="TxtConfirmarSenha">
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-lock"></span>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-8">
                            <div class="icheck-primary">
                                <input type="checkbox" id="aceiteTermos" name="termos" value="aceito">
                                <label for="aceiteTermos">
                                    Concordo com os <a href="#">termos</a>
                                </label>
                            </div>
                        </div>
                        <div class="col-4">
                            <button type="submit" class="btn btn-primary btn-block">Salvar</button>
                        </div>
                    </div>
                </form>

                <a href="Login.aspx" class="text-center">Já sou cadastrado</a>
            </div>
        </div>
    </div>

    <script src="Scripts/jquery-3.7.0.min.js"></script>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/adminlte/js") %>
    </asp:PlaceHolder>
</body>
</html>
