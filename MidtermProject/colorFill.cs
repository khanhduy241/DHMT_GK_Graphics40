using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;
using System.Windows.Forms;

namespace MidtermProject
{
    class Fill
    {
        public Point seed;
        public Color oldColor;
        public Color newColor;
        public virtual void FillColor(OpenGL gl) { }
        public virtual void ApplyFill(OpenGL gl, Point p) { }
        public void putPixel(OpenGL gl, Point p)
        {
            //Lấy từng thành phần màu
            Byte[] pixels = new Byte[4];
            pixels[0] = newColor.R;
            pixels[1] = newColor.G;
            pixels[2] = newColor.B;
            pixels[3] = newColor.A;
            // gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, color.A);
            //gl.PointSize(2.0f);//Size điểm
            //gl.Begin(OpenGL.GL_POINTS);
            //gl.Vertex(p.X, gl.RenderContextProvider.Height - p.Y);
            //gl.End();
            gl.RasterPos(p.X, gl.RenderContextProvider.Height - p.Y);
            gl.DrawPixels(1, 1, OpenGL.GL_RGBA, pixels);
            gl.Flush();
        }
        public void getPixel(OpenGL gl, Point p, out Byte[] color)
        {
            color = new Byte[4 * 1 * 1]; // Components * width * height (RGBA)
            gl.ReadPixels(p.X, gl.RenderContextProvider.Height - p.Y, 1, 1, OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE, color);
        }
    }

    class FloodFill : Fill
    {
        public override void ApplyFill(OpenGL gl, Point pFill)
        {

            
            seed = pFill;
            //Tô loang
            FillColor(gl);
        }
        public override void FillColor(OpenGL gl)
        {
            Byte[] pixel = new Byte[4];
            //Lấy điểm hạt giống
            getPixel(gl,seed, out pixel);
            oldColor = Color.FromArgb(pixel[3], pixel[0], pixel[1], pixel[2]);
            //Tránh lặp vô hạn khi màu cũ giống màu mới
            if (newColor == oldColor) return;

            //Mảng index để truy cập các lân cận 4
            int[] dx = new int[] { 0, 1, 0, -1 };
            int[] dy = new int[] { -1, 0, 1, 0 };

            //Tạo stack và push điểm khởi đầu vào stack
            Stack<Point> s = new Stack<Point>();
            s.Push(seed);

            //Lặp đến khi stack rỗng
            while (s.Count != 0)
            {
                //Lấy điểm từ stack
                Point p = s.Pop();
                //Tô màu cho điểm đó
                putPixel(gl, p);
                //Truy xuất lân cận 4 của điểm hiện hành
                for (int i = 0; i < 4; i++)
                {
                    //Lấy điểm lân cận
                    Point pNeighbor = new Point(p.X + dx[i], p.Y + dy[i]);

                    //Lấy giá trị pixel của điểm đó
                    Byte[] neighbor_color;
                    getPixel(gl, pNeighbor, out neighbor_color);

                    //Nếu điểm đó chưa tô thì thêm vào stack
                    if (neighbor_color[0] == oldColor.R && neighbor_color[1] == oldColor.G && neighbor_color[2] == oldColor.B
                       && neighbor_color[3] == oldColor.A)
                        s.Push(pNeighbor);
                }

            }
        }

    }
}
