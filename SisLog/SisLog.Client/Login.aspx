<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SisLog.Client.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>SisLog - Login</title>

    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="Content/adminlte.min.css" rel="stylesheet" />
</head>

<body class="hold-transition login-page">
    <div class="login-box">
        <div class="card card-outline card-primary">
            <div class="card-header text-center">
                SisLog
            </div>
            <div class="card-body">
                <p class="login-box-msg">Inicie sua sessão</p>

                <form action="~/login" method="post">
                    <div class="input-group mb-3">
                        <input type="email" class="form-control" placeholder="Email">
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <i class="fa-regular fa-envelope"></i>
                            </div>
                        </div>
                    </div>

                    <div class="input-group mb-3">
                        <input type="password" class="form-control" placeholder="Senha">
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <i class="fa-regular fa-lock"></i>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-8">
                            <div class="icheck-primary">
                                <input type="checkbox" id="lembrar">
                                <label for="lembrar">
                                    Lembrar
                                </label>
                            </div>
                        </div>
                        <div class="col-4">
                            <button type="submit" class="btn btn-primary btn-block">Acessar</button>
                        </div>
                    </div>
                </form>

                <p class="mb-1">
                    <a href="forgot-password.html">Esqueci a senha</a>
                </p>
                <p class="mb-0">
                    <a href="register.html" class="text-center">Cadastrar</a>
                </p>
            </div>
        </div>
    </div>

    <script src="Scripts/jquery-3.7.0.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <script src="Scripts/adminlte.min.js"></script>
</body>
</html>
