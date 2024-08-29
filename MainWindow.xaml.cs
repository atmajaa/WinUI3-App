using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics;
using System.Threading.Tasks;

using Microsoft.UI.Xaml.Media.Imaging;
using System.Runtime.InteropServices;
namespace PixelPawsAssignment
{
    public sealed partial class MainWindow : Window
    {
        private bool _isAccelerating = false;

        public MainWindow()
        {
            this.InitializeComponent();

            SetWindowSize(500, 870);
        }
        //function for the progress bar 
        private async void AccelerateButton_Pressed(object sender, RoutedEventArgs e)
        {
            if (_isAccelerating) return; // Prevents multiple presses

            _isAccelerating = true;

            // Increment the progress bar value slightly on each click
            if (accelerationBar.Value < accelerationBar.Maximum)
            {
                accelerationBar.Value += 5; // Adjust the increment value as needed
                await Task.Delay(20); 
            }

            _isAccelerating = false;
        }

        private void AccelerateButton_Released(object sender, PointerRoutedEventArgs e)
        {
            _isAccelerating = false; // Stops acceleration when button is released
        }
        //setting the height and width of screen as mentioned
        private void SetWindowSize(int width, int height)
        {
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd);
            var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);

            appWindow.Resize(new SizeInt32(width, height));
        }
    }
}
