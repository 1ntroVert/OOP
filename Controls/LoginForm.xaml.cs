using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Controls
{
    /// <summary>
    /// Логика взаимодействия для LoginForm.xaml
    /// </summary>
    public partial class LoginForm : UserControl
    {
        public LoginForm()
        {
            InitializeComponent();
            LoginTextBox.TextChanged += LoginTextBox_TextChanged;
            PasswordBox.PasswordChanged += PasswordBox_PasswordChanged;
            OkButton.Click += OkButton_Click;
        }

        public string Login
        {
            get { return (string)GetValue(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }

        public SecureString Password
        {
            get { return PasswordBox.SecurePassword; }
        }

        public static readonly DependencyProperty LoginProperty = DependencyProperty.Register(
            "Login",
            typeof(string),
            typeof(LoginForm),
             new PropertyMetadata(string.Empty, LoginChanged));

        private static void LoginChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var loginForm = obj as LoginForm;
            loginForm.LoginTextBox.Text = loginForm.Login;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO : need action
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            validateData();
        }

        private void LoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateData();
        }

        private void validateData()
        {
            bool isDataValid = Login.Length >= 4 && Password.Length >= 8;
            if (isDataValid)
                OkButton.IsEnabled = true;
            else
                OkButton.IsEnabled = false;
        }
    }
}
