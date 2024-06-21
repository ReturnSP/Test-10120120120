using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_10120120120
{
    public partial class Form1 : Form
    {
        private List<Node> nodes;
        private List<Spring> springs;

        private float swingAngle;
        private float swingSpeed;
        public Form1()
        {
            InitializeComponent();
            InitializeSimulation();
        }

        private void InitializeSimulation()
        {
            nodes = new List<Node>();
            springs = new List<Spring>();

            // Create nodes
            for (int i = 0; i < 19; i++)
            {
                nodes.Add(new Node(50 + i * 20, 15, i == 18)); // Fix only the last node
            }

            // Create springs
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                springs.Add(new Spring(nodes[i], nodes[i + 1],230f, 20));
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            foreach (var spring in springs)
            {
                spring.ApplyForce();
            }

            foreach (var node in nodes)
            {
                node.Update(0.066f); // Update with deltaTime
            }

            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            foreach (var spring in springs)
            {
                g.DrawLine(Pens.Black, spring.Node1.Position, spring.Node2.Position);
            }

            foreach (var node in nodes)
            {
                g.FillEllipse(Brushes.Red, node.Position.X - 5, node.Position.Y - 5, 10, 10);
            }
        }
    }
}
