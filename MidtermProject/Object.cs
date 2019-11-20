using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;

namespace MidtermProject
{
  
    class Shape
    {
        public bool IsEquilateral = false;

        public virtual void Update(Point p1, Point p2)
        { }

        public virtual void Draw(OpenGL gl)
        { }

    }

    class Line : Shape
    {
        private Point Vertex1;
        private Point Vertex2;

        public override void Update(Point p1, Point p2) // start point, end point
        {
            Vertex1 = p1;
            Vertex2 = p2;
        }

        public override void Draw(OpenGL gl) {
            gl.Begin(OpenGL.GL_LINES); // Chọn chế độ vẽ line

            gl.Vertex(Vertex1.X, gl.RenderContextProvider.Height - Vertex1.Y);
            gl.Vertex(Vertex2.X, gl.RenderContextProvider.Height - Vertex2.Y);
           
            gl.End();
            gl.Flush();
        }
    }

    class Triangle : Shape
    {
        private Point Vertex1, Vertex2, Vertex3;

        public override void Update(Point p1, Point p2) // start point, end point
        {
            if (this.IsEquilateral == true)
            {
                Vertex1.X = (p1.X + p2.X) / 2; // top vertex
                Vertex1.Y = p1.Y;

                double h = Math.Abs(p2.X - p1.X) * Math.Sqrt(3) / 2;
                Vertex2.X = p1.X;
                Vertex2.Y = p1.Y + (int)h;      // bottom vertex 

                Vertex3.X = p2.X;               // bottom vertex
                Vertex3.Y = p1.Y + (int)h;
            }
            else
            {
                Vertex1.X = (p1.X + p2.X) / 2; // top vertex
                Vertex1.Y = p1.Y;
                Vertex2.X = p1.X;            // bottom vertex 
                Vertex2.Y = p2.Y;
                Vertex3 = p2;                // bottom vertex
            }
        }

        public override void Draw(OpenGL gl)
        {
            gl.Begin(OpenGL.GL_LINE_LOOP); // Chọn chế độ vẽ tam giác

            gl.Vertex(Vertex1.X, gl.RenderContextProvider.Height - Vertex1.Y);
            gl.Vertex(Vertex2.X, gl.RenderContextProvider.Height - Vertex2.Y);
            gl.Vertex(Vertex3.X, gl.RenderContextProvider.Height - Vertex3.Y);

            gl.End();
            gl.Flush();
        }
    }

    class Rectangle : Shape
    {
        private Point Vertex1, Vertex2, Vertex3, Vertex4;

        public override void Update(Point p1, Point p2) // start point, end point
        {
            if (this.IsEquilateral == true)
            {
                Vertex1 = p1;
                Vertex2.X = p2.X; Vertex2.Y = p1.Y;
                Vertex3.X = p2.X; Vertex3.Y = p1.Y + (Math.Abs(p2.X - p1.X));
                Vertex4.X = p1.X; Vertex4.Y = Vertex3.Y;
            }
            else
            {
                Vertex1 = p1;
                Vertex2.X = p2.X; Vertex2.Y = p1.Y;
                Vertex3 = p2;
                Vertex4.X = p1.X; Vertex4.Y = p2.Y;
            }
        }

        public override void Draw(OpenGL gl)
        {
            gl.Begin(OpenGL.GL_LINE_LOOP); 

            gl.Vertex(Vertex1.X, gl.RenderContextProvider.Height - Vertex1.Y);
            gl.Vertex(Vertex2.X, gl.RenderContextProvider.Height - Vertex2.Y);
            gl.Vertex(Vertex3.X, gl.RenderContextProvider.Height - Vertex3.Y);
            gl.Vertex(Vertex4.X, gl.RenderContextProvider.Height - Vertex4.Y);

            gl.End();
            gl.Flush();
        }
    }

    class Circle : Shape
    {
        private double r;
        private double centerX, centerY;

        public override void Update(Point p1, Point p2) // start point, end point
        {
            if (Math.Abs(p1.X - p2.X) <= Math.Abs(p1.Y - p2.Y))
                r = (p2.X - p1.X) / 2;
            else
                r = (p2.Y - p1.Y) / 2;
           
            centerX = (p2.X + p1.X) / 2;
            centerY = (p2.Y + p1.Y) / 2;
        }

        public override void Draw(OpenGL gl)
        {
            gl.Begin(OpenGL.GL_LINE_LOOP);

            for (int i = 0; i < 360; i++)
            {
                double angle = Math.PI / 180 * i;
                double x = centerX + Math.Abs(r) * Math.Cos(angle);
                double y = centerY + Math.Abs(r) * Math.Sin(angle);
                gl.Vertex(x, gl.RenderContextProvider.Height - y);
            }
            gl.End();
            gl.Flush();
        }
    }

    class Ellipse : Shape
    {
        private double rx, ry, centerX, centerY;

        public override void Update(Point p1, Point p2) // start point, end point
        {
            rx = Math.Abs(p2.X - p1.X) / 2;
            ry = Math.Abs(p2.Y - p1.Y) / 2;
            centerX = (p1.X + p2.X) / 2;
            centerY = (p1.Y + p2.Y) / 2;

        }

        public override void Draw(OpenGL gl)
        {
            gl.Begin(OpenGL.GL_LINE_LOOP);

            for (int i = 0; i < 360; i ++)
            {
                double angle = Math.PI / 180 * i;
                double x = centerX + Math.Abs(rx) * Math.Cos(angle);
                double y = centerY + Math.Abs(ry) * Math.Sin(angle);
                gl.Vertex(x, gl.RenderContextProvider.Height - y);
            }
            gl.End();
            gl.Flush();
        }
    }

    class Pentagon : Shape
    {
        private Point Vertex1, Vertex2, Vertex3, Vertex4, Vertex5;

        public override void Update(Point p1, Point p2) // start point, end point
        {
            double dx, dy;
            if (IsEquilateral == true)
            {
                double r;
                if (Math.Abs(p1.X - p2.X) <= Math.Abs(p1.Y - p2.Y))
                    r = (p2.X - p1.X) / 2;
                else
                    r = (p2.Y - p1.Y) / 2;

                double cX, cY;
                cX = (p2.X + p1.X) / 2;
                cY = (p2.Y + p1.Y) / 2;
                double angle = Math.PI / 180 * -90;
                Vertex1.X = (int)(cX + Math.Abs(r) * Math.Cos(angle));
                Vertex1.Y = (int)(cY + Math.Abs(r) * Math.Sin(angle)); // dinh thu 1

                angle = Math.PI / 180 * -18;
                Vertex2.X = (int)(cX + Math.Abs(r) * Math.Cos(angle));
                Vertex2.Y = (int)(cY + Math.Abs(r) * Math.Sin(angle)); // dinh thu 2

                angle = Math.PI / 180 * 54;
                Vertex3.X = (int)(cX + Math.Abs(r) * Math.Cos(angle));
                Vertex3.Y = (int)(cY + Math.Abs(r) * Math.Sin(angle)); // dinh thu 3

                angle = Math.PI / 180 * 126;
                Vertex4.X = (int)(cX + Math.Abs(r) * Math.Cos(angle));
                Vertex4.Y = (int)(cY + Math.Abs(r) * Math.Sin(angle)); // dinh thu 4

                angle = Math.PI / 180 * 198;
                Vertex5.X = (int)(cX + Math.Abs(r) * Math.Cos(angle));
                Vertex5.Y = (int)(cY + Math.Abs(r) * Math.Sin(angle)); // dinh thu 5
            }
            else
            {
                dx = 19 * (p2.X - p1.X) / 98;
                dy = 5 * (p2.Y - p1.Y) / 13;

                Vertex1.X = (p1.X + p2.X) / 2;
                Vertex1.Y = p1.Y;

                Vertex2.X = p2.X;
                Vertex2.Y = p1.Y + (int)dy;

                Vertex3.X = p2.X - (int)dx;
                Vertex3.Y = p2.Y;

                Vertex4.X = p1.X + (int)dx;
                Vertex4.Y = p2.Y;

                Vertex5.X = p1.X;
                Vertex5.Y = p1.Y + (int)dy;
            }
        }

        public override void Draw(OpenGL gl)
        {
            gl.Begin(OpenGL.GL_LINE_LOOP);

            gl.Vertex(Vertex1.X, gl.RenderContextProvider.Height - Vertex1.Y);
            gl.Vertex(Vertex2.X, gl.RenderContextProvider.Height - Vertex2.Y);
            gl.Vertex(Vertex3.X, gl.RenderContextProvider.Height - Vertex3.Y);
            gl.Vertex(Vertex4.X, gl.RenderContextProvider.Height - Vertex4.Y);
            gl.Vertex(Vertex5.X, gl.RenderContextProvider.Height - Vertex5.Y);

            gl.End();
            gl.Flush();
        }
    }

    class Hexagon : Shape
    {
        private int dx, dy;
        private Point Vertex1, Vertex2, Vertex3, Vertex4, Vertex5, Vertex6;

        public override void Update(Point p1, Point p2) // start point, end point
        {
            if (IsEquilateral == true)
            {
                double r;
                if (Math.Abs(p1.X - p2.X) <= Math.Abs(p1.Y - p2.Y))
                    r = (p2.X - p1.X) / 2;
                else
                    r = (p2.Y - p1.Y) / 2;

                double cX, cY;
                cX = (p2.X + p1.X) / 2;
                cY = (p2.Y + p1.Y) / 2;
                double angle = Math.PI / 180 * -90;
                Vertex1.X = (int)(cX + Math.Abs(r) * Math.Cos(angle));
                Vertex1.Y = (int)(cY + Math.Abs(r) * Math.Sin(angle)); // dinh thu 1

                angle = Math.PI / 180 * -30;
                Vertex2.X = (int)(cX + Math.Abs(r) * Math.Cos(angle));
                Vertex2.Y = (int)(cY + Math.Abs(r) * Math.Sin(angle)); // dinh thu 2

                angle = Math.PI / 180 * 30;
                Vertex3.X = (int)(cX + Math.Abs(r) * Math.Cos(angle));
                Vertex3.Y = (int)(cY + Math.Abs(r) * Math.Sin(angle)); // dinh thu 3

                angle = Math.PI / 180 * 90;
                Vertex4.X = (int)(cX + Math.Abs(r) * Math.Cos(angle));
                Vertex4.Y = (int)(cY + Math.Abs(r) * Math.Sin(angle)); // dinh thu 4

                angle = Math.PI / 180 * 150;
                Vertex5.X = (int)(cX + Math.Abs(r) * Math.Cos(angle));
                Vertex5.Y = (int)(cY + Math.Abs(r) * Math.Sin(angle)); // dinh thu 5

                angle = Math.PI / 180 * 210;
                Vertex6.X = (int)(cX + Math.Abs(r) * Math.Cos(angle));
                Vertex6.Y = (int)(cY + Math.Abs(r) * Math.Sin(angle)); // dinh thu 6
            }
            else
            {
                dx = (p2.X - p1.X) / 2;
                dy = (p2.Y - p1.Y) / 4;

                Vertex1.X = p1.X + dx;
                Vertex1.Y = p1.Y;

                Vertex2.X = p2.X;
                Vertex2.Y = p1.Y + dy;

                Vertex3.X = p2.X;
                Vertex3.Y = p2.Y - dy;

                Vertex4.X = p1.X + dx;
                Vertex4.Y = p2.Y;

                Vertex5.X = p1.X;
                Vertex5.Y = p2.Y - dy;

                Vertex6.X = p1.X;
                Vertex6.Y = p1.Y + dy;
            }
        }

        public override void Draw(OpenGL gl)
        {
            gl.Begin(OpenGL.GL_LINE_LOOP);

            gl.Vertex(Vertex1.X, gl.RenderContextProvider.Height - Vertex1.Y);
            gl.Vertex(Vertex2.X, gl.RenderContextProvider.Height - Vertex2.Y);
            gl.Vertex(Vertex3.X, gl.RenderContextProvider.Height - Vertex3.Y);
            gl.Vertex(Vertex4.X, gl.RenderContextProvider.Height - Vertex4.Y);
            gl.Vertex(Vertex5.X, gl.RenderContextProvider.Height - Vertex5.Y);
            gl.Vertex(Vertex6.X, gl.RenderContextProvider.Height - Vertex6.Y);

            gl.End();
            gl.Flush();
        }
    }

    class Polygon 
    {
        private List<Point> px = new List<Point>();
        public void UpdatePoly(Point p1) 
        {
            px.Add(p1);
        }

        public void DrawByLine(OpenGL gl)
        {
            if (px.Count() == 2) return;
            for (int i = 1; i < px.Count(); i++)
            {
                Line l = new Line();
                l.Update(px[i - 1], px[i]);
                l.Draw(gl);
            }
        }

        public void DrawPoly(OpenGL gl)
        {
            gl.Begin(OpenGL.GL_LINE_LOOP);

            for (int i = 0; i < px.Count(); i++)
            {
                gl.Vertex(px[i].X, gl.RenderContextProvider.Height - px[i].Y);
            }
            gl.End();
            gl.Flush();
        }
    }
}



