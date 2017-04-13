using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Platform
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {

        private Character character;

        // game loop timer
        private DispatcherTimer timer;

        // canvas width and height
        private double CanvasWidth;
        private double CanvasHeight;

        // Which keys are pressed
        private bool LeftPressed;
        private bool RightPressed;
        private bool UpPressed;
        

        float positionX, positionY;     // Position of the character
        float velocityX, velocityY;     // Velocity of the character
        float gravity = 0.5f;           // How strong is gravity


        public GamePage()
        {
            this.InitializeComponent();


            // key listeners
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;
            

            // get canvas width and height
            CanvasWidth = MyCanvas.Width;
            CanvasHeight = MyCanvas.Height;

            // Add character
            character = new Character
            {
                LocationX = CanvasWidth -1280,
                LocationY = CanvasHeight -150
            };
            MyCanvas.Children.Add(character);

            // game loop 
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            timer.Start();



        }


        /// <summary>
        /// Game loop.
        /// </summary>
        private void Timer_Tick(object sender, object e)
        {
            // move 
            if (LeftPressed) { character.LocationX -= 10; }
            if (RightPressed) { character.LocationX += 10; }



            // update
            character.UpdateLocation();

        }

        void Update(float time)
        {
            positionX += velocityX * time;      // Apply horizontal velocity to X position
            positionY += velocityY * time;      // Apply vertical velocity to X position
            velocityY += gravity * time;        // Apply gravity to vertical velocity
        }

        void OnJumpKeyPressed()
        {
            velocityY = -12.0f;   // Give a vertical boost to the players velocity to start jump
        }

        void OnJumpKeyReleased()
        {
             if(velocityY < -6.0f)       // If character is still ascending in the jump
             velocityY = -6.0f;      // Limit the speed of ascent
        }


        /// <summary>
        /// Check if some keys are released.
        /// </summary>
        private void CoreWindow_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Left:
                    LeftPressed = false;
                    break;
                case VirtualKey.Right:
                    RightPressed = false;
                    break;
                case VirtualKey.Up:
                    UpPressed = false;
                    break;
                default:
                    break;
            }
         }


        /// <summary>
        /// Check if some keys are pressed.
        /// </summary>
        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Left:
                    LeftPressed = true;
                    break;
                case VirtualKey.Right:
                    RightPressed = true;
                    break;
                case VirtualKey.Up:
                    UpPressed = true;
                    break;
                default:
                    break;
            }
        }

    }   
    
}
