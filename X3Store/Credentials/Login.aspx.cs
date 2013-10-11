using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X3Store.Web.Credentials
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {}

        protected void SignUp_OnCreatingUser(object sender, LoginCancelEventArgs e)
        {
            SignUp.Email = SignUp.UserName;
        }

        protected void LoginButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                var isUserValid = Membership.ValidateUser(LoginBox.Text, Password.Text);
                if (!isUserValid)
                {
                    LoginValidator.IsValid = false;

                    var user = Membership.GetUser(LoginBox.Text);
                    if (user == null)
                    {
                        LoginValidator.ErrorMessage = "Указанный пользователь не найден<br />";
                        return;
                    }

                    if (user.IsLockedOut)
                    {
                        LoginValidator.ErrorMessage = "Ваша учётная запись заблокирована<br />";
                        return;                        
                    }

                    LoginValidator.ErrorMessage = "Неправильный пароль<br />";
                    return;
                }
            
                FormsAuthentication.SetAuthCookie(LoginBox.Text, RememberMe.Checked);
                FormsAuthentication.RedirectFromLoginPage(LoginBox.Text, RememberMe.Checked);
            }
            catch (Exception exception)
            {
                LoginValidator.IsValid = false;
                LoginValidator.ErrorMessage = string.Format("Ошибка входа: {0}<br />", exception.Message);
            }
        }

        protected void RestorePasswordButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                var user = Membership.GetUser(EmailBox.Text);

                if (user == null)
                {
                    EmailBoxValidator.IsValid = false;
                    return;
                }

//                var newPassword = user.ResetPassword();
                //TODO: Send password by email
//                PasswordRecoveryPanel.Controls.Add(new LiteralControl("<br />Ваш новый пароль: " + newPassword));
                PasswordRecoveryPanel.Controls.Add(new LiteralControl("<br />Новый пароль был выслан на ваш адрес электронной почты"));
            }
            catch (Exception exception)
            {
                EmailBoxValidator.IsValid = false;
                EmailBoxValidator.ErrorMessage = string.Format("Ошибка восстановления пароля: {0}<br />", exception.Message);
            }
        }

        protected void CreateUser_OnClick(object sender, EventArgs e)
        {
            try
            {
                var userName = NewEmailBox.Text;
                var password = NewPasswordBox.Text;
                var passwordConfirm = ConfirmPasswordBox.Text;

                if (password != passwordConfirm)
                {
                    ConfirmPasswordBoxValidator.IsValid = false;
                    return;
                }

                if (password != userName)
                {
                    ConfirmPasswordBoxValidator.IsValid = false;
                    return;
                }

                var newUser = Membership.CreateUser(userName, password, userName);
                newUser.IsApproved = true;
                NewUserPanel.Controls.Add(new LiteralControl("<br />Пользователь создан"));                
            }
            catch (Exception exception)
            {
                NewUserValidator.IsValid = false;
                NewUserValidator.ErrorMessage = string.Format("Ошибка регистрации: {0}<br />", exception.Message);
            }
        }
    }
}