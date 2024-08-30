using Hotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Hotel.View;
using System.Windows.Controls;

namespace Hotel.ModelView
{
    public class LoginViewModel : BaseClass
    {
        private string? username;
        public string? Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        // Command for logging in
        public ICommand LoginCommand { get; }
        public ICommand CancelCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Login(object parameter)
        {
            var passwordBox = parameter as System.Windows.Controls.PasswordBox;
            if (passwordBox == null)
                return;

            string password = passwordBox.Password;

            using (var context = new HotelContext())
            {
                var user = context.Users.FirstOrDefault(u => u.UserName == Username && u.Password == password);

                if (user != null)
                {
                    // Авторизация успешна, открываем основное окно
                    OpenMainWindow();

                    // Закрываем окно логина
                    CloseLoginWindow();
                }
                else
                {
                    // Неверные данные
                    MessageBox.Show("Неверный логин или пароль.");
                }
            }
        }

        private void OpenMainWindow()
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void CloseLoginWindow()
        {
            var loginWindow = Application.Current.Windows.OfType<LoginWindow>().SingleOrDefault();
            if (loginWindow != null)
            {
                loginWindow.Close();
            }
        }

        private void Cancel(object parameter)
        {
            // Закрыть приложение
            Application.Current.Shutdown();
        }
    }
}
