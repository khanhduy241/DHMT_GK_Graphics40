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

        // danh sanh cac hinh da ve
        List<Shape> listShape = new List<Shape>();
        List<Fill> listFill = new List<Fill>();
        Shape t = new Shape();
        Fill f = new Fill();

        // draw = -1 : khong ve hinh
        // draw = 0 : hoan tat ve (mouse up)
        // draw = 1 : ve hinh (mouse down)
        int draw = -1;

        // pick = -1 : khong ve hinh
        // pick = 0 : hoan tat ve (right click)
        // pick = 1 : chon diem tiep theo cua da giac (left click)
        int pick = -1;
        int shape = 0;

        /*Kiểu tô
            1: Tô loang
            2: Tô scanline
         */
        int fillType = 0;
        int fill = 0;
        public Point pStart { get; set; } // diem dau (mouse down)

        public Point pEnd { get; set; } // diem cuoi (mouse up)

        public Point pTemp { get; set; } // diem hien thoi cua con tro chuot

        public Point pclick { get; set; } // diem left click

        public Point prclick { get; set; } // diem right click

        public Point pFill { get; set; }


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
          
           // gl.Color(colorUserColor.R / 255.0, colorUserColor.G / 255.0, colorUserColor.B / 255.0);
            gl.LineWidth(2.0f);

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
                if (pick == -1)
                {
                    t = new Polygon();
                }

            // kiem tra xem phai ve hinh deu hay khong
            if (cb_equilateral.Checked)
                t.IsEquilateral = true;
            else
                t.IsEquilateral = false;

            t.color = colorUserColor;
            DrawShape(gl, t);
            t.color = colorUserColor;
            //Tô loang



        }

        // ve tat ca hinh trong list
        private void drawAll(OpenGL gl)
        {
            foreach(Shape s in listShape)
            {
              
                s.Draw(gl);
               
            }

            if (fillType == 1 && !pFill.IsEmpty)
            {
                f = new FloodFill();
                f.newColor = colorUserColor;
                f.ApplyFill(gl, pFill);
            }
        }

        // ve hinh, input bien control, hinh can ve
        private void DrawShape(OpenGL gl, Shape t)
        {
            
            if (shape == 8)
            {
                if (pick == 1)
                {
                    t.Update(pclick);
                    t.DrawByLine(gl);
                }
                if (pick == 0)
                {
                    t.Draw(gl);
                    listShape.Add(t);              
                    pick = -1;
                }
            }
            else
            {
                if (draw == 1)
                {
                    t.Update(pStart, pTemp);
                    t.Draw(gl);
                }
                else if (draw == 0)
                {
                    t.Update(pStart, pEnd);
                    t.Draw(gl);
                    listShape.Add(t);
                   
                }
            }
            
            drawAll(gl);
           
        }

        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            pStart = e.Location;
            pEnd = pStart;
            draw = 1;
            if (fill == 1)
            {
                pFill = e.Location;
            }
        }

        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            draw = 0;
            pEnd = e.Location;
            
        }

        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw == 1)
            {
                pTemp = e.Location;
               
            }
                             
        }

        private void openGLControl_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {

                case MouseButtons.Left:
                    pclick = e.Location;  // left click
                    pick = 1;
                    break;

                case MouseButtons.Right:
                    prclick = e.Location;   // Right click
                    pick = 0;
                    break;
            }
        }
        private void bt_line_MouseClick(object sender, MouseEventArgs e)
        {
            shape = 1;
            draw = -1;
            fill = 0;
        }

        private void bt_triangle_MouseClick(object sender, MouseEventArgs e)
        {
            shape = 2;
            draw = -1;
            fill = 0;
        }

        private void bt_circle_MouseClick(object sender, MouseEventArgs e)
        {
            shape = 3;
            draw = -1;
            fill = 0;
        }

        private void bt_ellipse_MouseClick(object sender, MouseEventArgs e)
        {
            shape = 4;
            draw = -1;
            fill = 0;
        }

        private void bt_rectangle_MouseClick(object sender, MouseEventArgs e)
        {
            shape = 5;
            draw = -1;
            fill = 0;
        }

        private void bt_pentagon_MouseClick(object sender, MouseEventArgs e)
        {
            shape = 6;
            draw = -1;
            fill = 0;
        }

        private void bt_hexagon_MouseClick(object sender, MouseEventArgs e)
        {
            shape = 7;
            draw = -1;
            fill = 0;
        }

        private void bt_polygon_MouseClick(object sender, MouseEventArgs e)
        {
            shape = 8;
            pick = -1;
            fill = 0;
        }

        private void bt_Color_MouseClick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                colorUserColor = colorDialog1.Color;
        }

        private void bt_FloodFill_MouseClick(object sender, EventArgs e)
        {
            fill = 1;
            fillType = 1;
            draw = 0;
        }
    }
}
