﻿using System;
using System.Collections.Generic;
using System.Linq;
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

namespace RelaySim.Components
{
    /// <summary>
    /// Interaction logic for Switch.xaml
    /// </summary>
    public partial class Switch : ElectricComponent
    {
        public Switch()
        {
            InitializeComponent();
            IsOpen = false;
        }
        private void SwitchLine_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsOpen)
            {
                SwitchLine.X1 = 10;
                IsOpen = true;
            }
            else
            {
                SwitchLine.X1 = 50;
                IsOpen = false;
            }
        }

        public bool IsOpen { get; private set; }
    }
}
