using RelaySim.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace RelaySim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Add(new ComponentListItem(typeof(Switch), "Switch"));
            listBox1.Items.Add(new ComponentListItem(typeof(N), "N"));
            listBox1.Items.Add(new ComponentListItem(typeof(L), "L"));
            listBox1.Items.Add(new ComponentListItem(typeof(Lamp), "Lamp"));
            listBox1.Items.Add(new ComponentListItem(typeof(Wire), "Wire"));
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            DesignControl dc = ((DesignControl)elementHost1.Child);
            ContentControl cc = new ContentControl();
            cc.Content = Activator.CreateInstance(((ComponentListItem)listBox1.SelectedItem).Control);
            cc.Template = dc.FindResource("DesignerItemTemplate") as ControlTemplate;
            Canvas.SetTop(cc, 10);
            Canvas.SetLeft(cc, 50);
            dc.Canvas.Children.Add(cc);
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //this.listBox1.DoDragDrop(this.listBox1.SelectedItem, DragDropEffects.Copy); 
        }

        private void listBox1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void startSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesignControl dc = ((DesignControl)elementHost1.Child);
            foreach (System.Windows.UIElement uie in dc.Canvas.Children)
            {
                if (uie.GetType() == typeof(ContentControl))
                {
                    ContentControl cc = uie as ContentControl;
                    if (cc.Content.GetType() == typeof(L))
                    {
                        L l = cc.Content as L;
                        foreach(Connection c1 in l.Ports){
                            foreach (Connection c in c1.ConnectedTo)
                            {
                                Console.WriteLine(c.Component);
                            }
                        }
                    }
                }
            }
        }
    }
    public class ComponentListItem
    {
        public ComponentListItem(Type control, string name)
        {
            this.Control = control;
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public Type Control { get; set; }

        public string Name { get; set; }
    }
}
