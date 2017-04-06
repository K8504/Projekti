using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Platform
{
    public sealed partial class Character : UserControl
    {


        // location
        public double LocationX { get; set; }
        public double LocationY { get; set; }

        // speed
        private readonly double MaxSpeed = 10.0;
        private readonly double Accelerate = 0.5;
        private double speed;

        public Character()
        {
            this.InitializeComponent();

        }



        /// <summary>
        /// Move character in different location.
        /// </summary>
        public void Move()
        {
            // more speed
            speed += Accelerate;
            if (speed > MaxSpeed) speed = MaxSpeed;
            SetValue(Canvas.LeftProperty, LocationX);
         
            
            // update location values (with speed)
            LocationX += 1 * speed;
        }
        /// <summary>
        /// Update character's position in Canvas.
        /// </summary>
        public void UpdateLocation()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }

    }
}
