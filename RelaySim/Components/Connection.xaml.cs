using System;
using System.Collections.Generic;
using System.Linq;
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

namespace RelaySim.Components
{
    /// <summary>
    /// Interaction logic for Connection.xaml
    /// </summary>
    public partial class Connection : UserControl
    {
        public Connection()
        {
            InitializeComponent();
            IsGround = false;
            IsSource = false;
            ConnectedTo = new List<Connection>();
            Component = Utils.TryFindParent<ElectricComponent>(this);
        }
        public ElectricComponent Component { get; internal set; }
        public bool IsSource { get; internal set; }
        public bool IsGround { get; internal set; }
        public List<Connection> ConnectedTo { get; set; }
        private Point startPoint;
        private void Ellipse_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Clicked");
            startPoint = e.GetPosition(null);

        }

        private void Ell_PreviewMouseMove_1(object sender, MouseEventArgs e)
        {
            // Get the current mouse position
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                // Get the dragged ListViewItem
                Ellipse ellipse = sender as Ellipse;

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("connection", this);
                DragDrop.DoDragDrop(ellipse, dragData, DragDropEffects.Move);
            } 

        }

        private void Ell_DragEnter_1(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("connection") ||
    sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void Ell_Drop_1(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("connection"))
            {
                Connection connection = e.Data.GetData("connection") as Connection;
                if (connection != this && !this.ConnectedTo.Contains(connection) && !connection.ConnectedTo.Contains(this))
                {
                    connection.ConnectedTo.Add(this);
                    this.ConnectedTo.Add(connection);
                }
            }
        }

    }
}
