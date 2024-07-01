using Hotel.View;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new GuestPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new RoomPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new MainPage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new EmployeePage());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new ReservationPage());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new PaymentPage());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new ServicePage());
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new GuestServicePage());
        }
    }
}