using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL.WinForms;

namespace MidtermProject
{


    public partial class Form1 : Form
    {
        Color colorUserColor;

        Polygon p = new Polygon();

        int shape = 0;
        public Point pStart { get; set; }

        public Point pEnd { get; set; }

        public Point pTemp { get; set; }

        public Point pclick { get; set; }

        public Point prclick { get; set; }

        public Form1()
        {
            InitializeComponent();
            colorUserColor = Color.White;
        }

        private void openGLControl_OpenGLInitialized_1(object sender, EventArgs e)
        {
            // Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            // Set the clear color.
            gl.ClearColor(0, 0, 0, 0);
            // Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            // Load the identity.
            gl.LoadIdentity();
        }

        private void openGLControl_Resized(object sender, EventArgs e)
        {
            // Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            // Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            // Load the identity.
            gl.LoadIdentity();
            // Create a perspective transformation.
            gl.Viewport(0, 0, openGLControl.Width, openGLControl.Height);
            gl.Ortho2D(0, openGLControl.Width, 0, openGLControl.Height);
        }

        private void openGLControl_OpenGLDraw_1(object sender, RenderEventArgs args)
        {
            // Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            // Clear the color and depth buffer
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
          
            gl.Color(colorUserColor.R / 255.0, colorUserColor.G / 255.0, colorUserColor.B / 255.0);

            /* Vẽ vời chỗ này*/
            Shape t = new Shape();

            if (shape == 0) {
                gl.Begin(OpenGL.GL_POINTS);
                gl.Vertex(pStart.X, gl.RenderContextProvider.Height - pStart.Y);
                gl.End();
                gl.Flush();
            }
            if (shape == 1)
                t = new Line();
            if (shape == 2)
                t = new Triangle();
            if (shape == 3)
                t = new Circle();
            if (shape == 4)
                t = new Ellipse();
            if (shape == 5)
                t = new Rectangle();
            if (shape == 6)
                t = new Pentagon();
            if (shape == 7)
                t = new Hexagon();
            if (shape == 8)
            {
                if (prclick.IsEmpty == true && pclick.IsEmpty == false)
                {
                    Line pEdge = new Line();
                    DrawShape(gl, pEdge);
                    p.UpdatePoly(pclick);
                    p.DrawByLine(gl);
                }
                else
                    p.DrawPoly(gl);
            }

            if (shape != 0 && shape != 8)
            {
                if (cb_equilateral.Checked)
                    t.IsEquilateral = true;
                else
                    t.IsEquilateral = false;

                DrawShape(gl, t);
            }

        }
        
        private void DrawShape(OpenGL gl, Shape t)
        {
            if (pStart.IsEmpty == false && pEnd == pStart)
            {
                t.Update(pStart, pTemp);
                t.Draw(gl);
            }
            t.Update(pStart, pEnd);
            t.Draw(gl);
        }

        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            pStart = e.Location;
            pEnd = pStart;
        }

        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            pEnd = e.Location;
        }

        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            pTemp = e.Location;
        }

        private void openGLControl_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {

                case MouseButtons.Left:
                    pclick = e.Location;  // left click
                    break;

                case MouseButtons.Right:
                    prclick = e.Location;   // Right click
                    break;
            }
        }
        private void bt_line_MouseClick(object sender, MouseEventArgs e)
        {
            shape = 1;
        }

        private void bt_triangle_MouseClick(object sender, MouseEventArgs e)
        {
            shape = 2;
        }

        private void bt_circle_MouseClick(object sender, MouseEventArgs e)
        {
            shape = 3;
        }

        private void bt_ellipse_MouseClick(object sender, MouseEventArgs e)
        {
            shape = 4;
        }

        private void bt_rectangle_MouseClick(object sender, MouseEventArgs e)
        {
            shape = 5;
        }

        private void bt_pentagon_MouseClick(object sender, MouseEventArgs e)
        {
            shape = 6;
        }

        private void bt_hexagon_MouseClick(object sender, MouseEventArgs e)
        {
            shape = 7;
        }

        private void bt_polygon_MouseClick(object sender, MouseEventArgs e)
        {
            shape = 8;
        }
    }
}
