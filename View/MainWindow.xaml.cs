using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace PublicTransportRoutes.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void CloseWindowButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void MinimizeWindowButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void MenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                var btn = sender as Button;

                Popup.PlacementTarget = btn;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;

                switch (btn.Name)
                {
                    case "btnHome":
                        Header.PopupText.Text = "Home";
                        break;

                    case "btnAdd":
                        Header.PopupText.Text = "Add";
                        break;

                    case "btnSearch":
                        Header.PopupText.Text = "Search";
                        break;

                    default:
                        break;
                }
            }
        }


        // Start: Button Close | Restore | Minimize 
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MenuItem_Loaded(object sender, RoutedEventArgs e)
        {

        }
        // End: Button Close | Restore | Minimize
    }
}
