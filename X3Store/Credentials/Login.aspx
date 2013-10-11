<%@ Page Title="Login / Register" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="X3Store.Web.Credentials.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPH" runat="server">
    <link href="/AJAX.css" rel="stylesheet" />
    <style type="text/css">
        .pHeader
         {
            color: white;
            background-color: #719DDB;
            font: bold 11px "Trebuchet MS", Verdana;
            font-size: 12px;
            cursor: pointer;
            width:450px;
            height:18px;
            padding: 4px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPH" runat="server">
    <div>
        <asp:Panel runat="server">
            <asp:Label runat="server" Text="Выполнить вход" />
            <br />
            <asp:Label runat="server" Text="E-mail: " />
            <asp:TextBox runat="server" ID="LoginBox" />
            <asp:RequiredFieldValidator ID="LoginBoxValidator" runat="server" ControlToValidate="LoginBox" ErrorMessage="Необходимо ввести адрес электронной почты" ValidationGroup="Login" />
            <br />
            <asp:Label runat="server" Text="Пароль: " />
            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
            <asp:RequiredFieldValidator ID="PasswordValidator" runat="server" ControlToValidate="Password" ErrorMessage="Необходимо ввести пароль" ValidationGroup="Login"/>
            <br />
            <asp:CustomValidator ID="LoginValidator" runat="server" Display="Dynamic" ErrorMessage="Error" ValidationGroup="Login"/>
            <asp:CheckBox runat="server" ID="RememberMe" Checked="True" Text="Запомнить"/>
            <asp:Button runat="server" ID="LoginButton" Text="Войти" OnClick="LoginButton_OnClick"/>
        </asp:Panel>
        <hr />
        <asp:Panel runat="server" ID="PasswordRecoveryPanel">
            <asp:Label runat="server" Text="Забыли пароль?" />
            <br />
            <asp:Label runat="server" Text="E-mail: " />
            <asp:TextBox runat="server" ID="EmailBox" />
            <asp:Button runat="server" ID="RestorePasswordButton" Text="Запросить пароль" OnClick="RestorePasswordButton_OnClick"/>
            <asp:RequiredFieldValidator ID="EmailBoxValidator" runat="server" ControlToValidate="EmailBox" ErrorMessage="<br />Пользователь с указанным адресом электронной почты не найден" ValidationGroup="Restore"/>
        </asp:Panel>
        <hr />
        <asp:Panel runat="server" ID="NewUserPanel">
            <asp:Label runat="server" Text="Зарегистрироваться" />
            <br />
            <asp:Label runat="server" Text="E-mail: " />
            <asp:TextBox runat="server" ID="NewEmailBox" />
            <asp:RequiredFieldValidator ID="NewEmailBoxValidator" runat="server" ControlToValidate="NewEmailBox" ErrorMessage="Необходимо ввести адрес электронной почты" ValidationGroup="Register"/>
            <br />
            <asp:Label runat="server" Text="Пароль: " />
            <asp:TextBox runat="server" ID="NewPasswordBox" TextMode="Password" />
            <asp:RequiredFieldValidator ID="NewPasswordBoxValidator" runat="server" ControlToValidate="NewPasswordBox" ErrorMessage="Необходимо ввести пароль" ValidationGroup="Register"/>
            <asp:CompareValidator ID="WrongPasswordValidator" runat="server" ControlToValidate="NewEmailBox" ControlToCompare="NewPasswordBox" ErrorMessage="Пароль не должен совпадать с адресом электронной почты" ValidationGroup="Register"/>
            <br />
            <asp:Label runat="server" Text="Подтвердите пароль: " />
            <asp:TextBox runat="server" ID="ConfirmPasswordBox" TextMode="Password" />
            <asp:CompareValidator ID="ConfirmPasswordBoxValidator" runat="server" ControlToValidate="ConfirmPasswordBox" ControlToCompare="NewPasswordBox" ErrorMessage="Пароли не совпадают" ValidationGroup="Register"/>
            <br />
            <asp:CustomValidator ID="NewUserValidator" runat="server" Display="Dynamic" ErrorMessage="Error" ValidationGroup="Register"/>
            <asp:Button runat="server" ID="CreateUser" Text="Войти" OnClick="CreateUser_OnClick"/>

            <asp:CreateUserWizard ID="SignUp" runat="server"
                RequireEmail="False" HeaderText="Зарегистрироваться"
                ConfirmPasswordCompareErrorMessage="Введённые пароли не совпадают"
                UserNameLabelText="E-mail:"
                OnCreatingUser="SignUp_OnCreatingUser">
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" />
<%--                    <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" />--%>
                </WizardSteps>
            </asp:CreateUserWizard>
        </asp:Panel>
        <hr />
        <asp:Panel runat="server">
            <asp:ChangePassword runat="server"></asp:ChangePassword>
        </asp:Panel>
    </div>
</asp:Content>