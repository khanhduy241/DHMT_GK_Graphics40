﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;
using System.Windows.Forms;

namespace MidtermProject
{
    // Lop hinh hoc
    class Shape
    {
        public List<Point> ctrlPoint = null;
        public int ctrlPcount;
        // neu hinh la hinh deu thi IsEquilateral = true va nguoc lai
        public bool IsEquilateral = false;
        public Color color;
        public Point pSeed;
        public bool fill = false;
        public float lineWidth = 1.0f;
        public Fill fi;
        // dem so dinh
        public virtual int pointCount() { return 0; }

        // cap nhat toa do dinh tiep theo cua da giac
        public virtual void Update(Point p1)
        { }

        // cap nhat toa do dinh tu diem dau va diem cuoi
        public virtual void Update(Point p1, Point p2)
        { }

        // lay control point                                                                                     
        public virtual void getCtrlP()
        { }

        // ve control point
        public virtual void ctrlPDraw(OpenGL gl)
        {
            if (ctrlPoint != null)
            {
                for (int i = 0; i < ctrlPcount; i++)
                {
                    Shape t = new Rectangle();
                    t.color = Color.Blue;
                    t.lineWidth = 3;
                    Point p1 = new Point(ctrlPoint[i].X - 2, ctrlPoint[i].Y - 2);
                    Point p2 = new Point(ctrlPoint[i].X + 2, ctrlPoint[i].Y + 2);
                    t.Update(p1, p2);
                    t.Draw(gl);
                }
            }

            gl.End();
            gl.Flush();
        }

        // ve hinh
        public virtual void Draw(OpenGL gl)
        { }

        // ve hinh theo tung doan doi voi da giac
        public virtual void DrawByLine(OpenGL gl)
        { }

        //public virtual void FillColor(OpenGL gl, int type)
        //{
        //    if (type == 1)
        //    {
        //        Fill f = new FloodFill();
        //        f.newColor = color;
        //        f.ApplyFill(gl, pSeed);
        //    }
        //}



    }

    class Line : Shape
    {
        private Point Vertex1;
        private Point Vertex2;

        public override int pointCount() { return 2; }

        public override void Update(Point p1, Point p2) // start point, end point
        {
            Vertex1 = p1;
            Vertex2 = p2;
        }

        public override void getCtrlP()
        {
            ctrlPoint = new List<Point>();
            ctrlPoint.Add(Vertex1);
            ctrlPoint.Add(Vertex2);
            ctrlPcount = 2;

        }

        public override void Draw(OpenGL gl) {

            gl.Color(color.R/255.0, color.G/255.0, color.B/255.0);
            gl.LineWidth(this.lineWidth);
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

        public override int pointCount() { return 3; }
        public override void Update(Point p1, Point p2) // start point, end point
        {
            if (this.IsEquilateral == true)
            {
                Vertex1.X = (p1.X + p2.X) / 2; // top vertex
                Vertex1.Y = p1.Y;

                double h = Math.Abs(p2.X - p1.X) * Math.Sqrt(3) / 2; // lay duong cao bang canh day nhan can 3 chia 2
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

        public override void getCtrlP()
        {
            ctrlPoint = new List<Point>();
            ctrlPoint.Add(new Point(Vertex2.X, Vertex1.Y));
            ctrlPoint.Add(Vertex1);
            ctrlPoint.Add(new Point(Vertex3.X, Vertex1.Y));
            ctrlPoint.Add(new Point(Vertex3.X, (Vertex1.Y + Vertex3.Y) / 2));
            ctrlPoint.Add(new Point(Vertex3.X, Vertex3.Y));
            ctrlPoint.Add(new Point(Vertex1.X, Vertex3.Y));
            ctrlPoint.Add(Vertex2);
            ctrlPoint.Add(new Point(Vertex2.X, (Vertex1.Y + Vertex3.Y) / 2));
            ctrlPcount = 8;

        }
        public override void Draw(OpenGL gl)
        {
           
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0);
            gl.LineWidth(this.lineWidth);
            gl.Begin(OpenGL.GL_LINE_LOOP); // Chọn chế độ vẽ tam giác

            gl.Vertex(Vertex1.X, gl.RenderContextProvider.Height - Vertex1.Y);
            gl.Vertex(Vertex2.X, gl.RenderContextProvider.Height - Vertex2.Y);
            gl.Vertex(Vertex3.X, gl.RenderContextProvider.Height - Vertex3.Y);

            gl.End();
            
            gl.Flush();
           
        }
        
        //public override void FillColor(OpenGL gl, Color color, int type)
        //{
        //    pCenter = new Point((Vertex1.X + Vertex2.X + Vertex3.X) / 3, (Vertex1.Y + Vertex2.Y + Vertex3.Y) / 3);
        //    if (type == 1)
        //    {              
        //        Fill f = new FloodFill();
        //        f.ApplyFill(gl, pCenter, color);
        //    }
        //}
    }

    class Rectangle : Shape
    {
        private Point Vertex1, Vertex2, Vertex3, Vertex4;

        public override int pointCount() { return 4; }
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

        public override void getCtrlP()
        {
            ctrlPoint = new List<Point>();
            ctrlPoint.Add(Vertex1);
            ctrlPoint.Add(new Point((Vertex1.X + Vertex2.X) / 2, Vertex1.Y));
            ctrlPoint.Add(Vertex2);
            ctrlPoint.Add(new Point(Vertex2.X, (Vertex2.Y + Vertex3.Y) / 2));
            ctrlPoint.Add(Vertex3);
            ctrlPoint.Add(new Point((Vertex3.X + Vertex4.X) / 2, Vertex3.Y));
            ctrlPoint.Add(Vertex4);
            ctrlPoint.Add(new Point(Vertex1.X, (Vertex1.Y + Vertex4.Y) / 2));
            ctrlPcount = 8;

        }

        public override void Draw(OpenGL gl)

        {
           
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0);
            gl.LineWidth(this.lineWidth);
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
            // neu khoang cach 2 diem theo phuong x be hon thi lay khoang cach do lam duong kinh, va nguoc lai
            if (Math.Abs(p1.X - p2.X) <= Math.Abs(p1.Y - p2.Y)) 
                r = (p2.X - p1.X) / 2;
            else
                r = (p2.Y - p1.Y) / 2;
           
            centerX = (p2.X + p1.X) / 2;
            centerY = (p2.Y + p1.Y) / 2;
        }

        public override void getCtrlP()
        {
            ctrlPoint = new List<Point>();
            ctrlPoint.Add(new Point((int)(centerX - r), (int)(centerY - r)));
            ctrlPoint.Add(new Point((int)(centerX), (int)(centerY - r)));
            ctrlPoint.Add(new Point((int)(centerX + r), (int)(centerY - r)));
            ctrlPoint.Add(new Point((int)(centerX + r), (int)(centerY)));
            ctrlPoint.Add(new Point((int)(centerX + r), (int)(centerY + r)));
            ctrlPoint.Add(new Point((int)(centerX), (int)(centerY + r)));
            ctrlPoint.Add(new Point((int)(centerX - r), (int)(centerY + r)));
            ctrlPoint.Add(new Point((int)(centerX - r), (int)(centerY)));
            ctrlPcount = 8;

        }
        public override void Draw(OpenGL gl)
        {
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0);
            gl.LineWidth(this.lineWidth);
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

        public override void getCtrlP()
        {
            ctrlPoint = new List<Point>();
            ctrlPoint.Add(new Point((int)(centerX - rx), (int)(centerY - ry)));
            ctrlPoint.Add(new Point((int)(centerX), (int)(centerY - ry)));
            ctrlPoint.Add(new Point((int)(centerX + rx), (int)(centerY - ry)));
            ctrlPoint.Add(new Point((int)(centerX + rx), (int)(centerY)));
            ctrlPoint.Add(new Point((int)(centerX + rx), (int)(centerY + ry)));
            ctrlPoint.Add(new Point((int)(centerX), (int)(centerY + ry)));
            ctrlPoint.Add(new Point((int)(centerX - rx), (int)(centerY + ry)));
            ctrlPoint.Add(new Point((int)(centerX - rx), (int)(centerY)));
            ctrlPcount = 8;

        }
        public override void Draw(OpenGL gl)
        {
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0);
            gl.LineWidth(this.lineWidth);
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

        public override int pointCount() { return 5; }
        public override void Update(Point p1, Point p2) // start point, end point
        {
            double dx, dy;
            if (IsEquilateral == true)
            {
                double r; // khoang cach tu tam toi dinh
                // neu khoang cach 2 diem theo phuong x be hon thi lay khoang cach do lam 2r, va nguoc lai
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
                dx = 19 * (p2.X - p1.X) / 98;  // ti le tu quy uoc
                dy = 5 * (p2.Y - p1.Y) / 13;   // ti le tu quy uoc

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

        public override void getCtrlP()
        {
            ctrlPoint = new List<Point>();
            ctrlPoint.Add(new Point(Vertex5.X,Vertex1.Y));
            ctrlPoint.Add(Vertex1);
            ctrlPoint.Add(new Point(Vertex2.X, Vertex1.Y));
            ctrlPoint.Add(new Point(Vertex2.X, (Vertex1.Y + Vertex3.Y) / 2));
            ctrlPoint.Add(new Point(Vertex2.X, Vertex3.Y));
            ctrlPoint.Add(new Point(Vertex1.X, Vertex3.Y));
            ctrlPoint.Add(new Point(Vertex5.X, Vertex4.Y));
            ctrlPoint.Add(new Point(Vertex5.X, (Vertex1.Y + Vertex4.Y) / 2));
            ctrlPcount = 8;

        }
        public override void Draw(OpenGL gl)
        {
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0);
            gl.LineWidth(this.lineWidth);
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

        public override int pointCount() { return 6; }
        public override void Update(Point p1, Point p2) // start point, end point
        {
            if (IsEquilateral == true)
            {
                double r;
                // neu khoang cach 2 diem theo phuong x be hon thi lay khoang cach do lam 2r, va nguoc lai
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

        public override void getCtrlP()
        {
            ctrlPoint = new List<Point>();
            ctrlPoint.Add(new Point(Vertex6.X, Vertex1.Y));
            ctrlPoint.Add(Vertex1);
            ctrlPoint.Add(new Point(Vertex2.X, Vertex1.Y));
            ctrlPoint.Add(new Point(Vertex2.X, (Vertex1.Y + Vertex4.Y) / 2));
            ctrlPoint.Add(new Point(Vertex2.X, Vertex4.Y));
            ctrlPoint.Add(Vertex4);
            ctrlPoint.Add(new Point(Vertex5.X, Vertex4.Y));
            ctrlPoint.Add(new Point(Vertex5.X, (Vertex1.Y + Vertex4.Y) / 2));
            ctrlPcount = 8;

        }
        public override void Draw(OpenGL gl)
        {
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0);
            gl.LineWidth(this.lineWidth);
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

    class Polygon : Shape
    {
        private List<Point> px = null;

        public override int pointCount() { return px.Count(); }
        public override void Update(Point p1) 
        {
            if (px == null)
            {
                px = new List<Point>();
                px.Add(p1);
            }
            else
            {
                if (px[px.Count - 1] != p1)
                {
                    px.Add(p1);
                }
            }
        }

        public override void DrawByLine(OpenGL gl)
        {
            if (px.Count() > 1)
                for (int i = 1; i < px.Count(); i++)
                {
                    Line l = new Line();
                    l.Update(px[i - 1], px[i]);
                    l.Draw(gl);
                }
        }

        public override void Draw(OpenGL gl)
        {
            if (px == null) return;

            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0);
            gl.LineWidth(this.lineWidth);
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

