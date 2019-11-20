namespace MidtermProject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openGLControl = new SharpGL.OpenGLControl();
            this.bt_line = new System.Windows.Forms.Button();
            this.bt_triangle = new System.Windows.Forms.Button();
            this.bt_circle = new System.Windows.Forms.Button();
            this.bt_ellipse = new System.Windows.Forms.Button();
            this.bt_rectangle = new System.Windows.Forms.Button();
            this.bt_pentagon = new System.Windows.Forms.Button();
            this.bt_hexagon = new System.Windows.Forms.Button();
            this.cb_equilateral = new System.Windows.Forms.CheckBox();
            this.bt_polygon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.BackColor = System.Drawing.SystemColors.Control;
            this.openGLControl.DrawFPS = false;
            this.openGLControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openGLControl.Location = new System.Drawing.Point(72, 50);
            this.openGLControl.Margin = new System.Windows.Forms.Padding(5);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(979, 476);
            this.openGLControl.TabIndex = 1;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized_1);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw_1);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseClick);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseUp);
            // 
            // bt_line
            // 
            this.bt_line.Location = new System.Drawing.Point(12, 12);
            this.bt_line.Name = "bt_line";
            this.bt_line.Size = new System.Drawing.Size(75, 30);
            this.bt_line.TabIndex = 2;
            this.bt_line.Text = "Line";
            this.bt_line.UseVisualStyleBackColor = true;
            this.bt_line.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_line_MouseClick);
            // 
            // bt_triangle
            // 
            this.bt_triangle.Location = new System.Drawing.Point(94, 11);
            this.bt_triangle.Name = "bt_triangle";
            this.bt_triangle.Size = new System.Drawing.Size(75, 31);
            this.bt_triangle.TabIndex = 3;
            this.bt_triangle.Text = "Tri";
            this.bt_triangle.UseVisualStyleBackColor = true;
            this.bt_triangle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_triangle_MouseClick);
            // 
            // bt_circle
            // 
            this.bt_circle.Location = new System.Drawing.Point(176, 12);
            this.bt_circle.Name = "bt_circle";
            this.bt_circle.Size = new System.Drawing.Size(75, 30);
            this.bt_circle.TabIndex = 4;
            this.bt_circle.Text = "Circle";
            this.bt_circle.UseVisualStyleBackColor = true;
            this.bt_circle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_circle_MouseClick);
            // 
            // bt_ellipse
            // 
            this.bt_ellipse.Location = new System.Drawing.Point(258, 11);
            this.bt_ellipse.Name = "bt_ellipse";
            this.bt_ellipse.Size = new System.Drawing.Size(75, 31);
            this.bt_ellipse.TabIndex = 5;
            this.bt_ellipse.Text = "Ellipse";
            this.bt_ellipse.UseVisualStyleBackColor = true;
            this.bt_ellipse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_ellipse_MouseClick);
            // 
            // bt_rectangle
            // 
            this.bt_rectangle.Location = new System.Drawing.Point(340, 11);
            this.bt_rectangle.Name = "bt_rectangle";
            this.bt_rectangle.Size = new System.Drawing.Size(75, 31);
            this.bt_rectangle.TabIndex = 6;
            this.bt_rectangle.Text = "Rec";
            this.bt_rectangle.UseVisualStyleBackColor = true;
            this.bt_rectangle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_rectangle_MouseClick);
            // 
            // bt_pentagon
            // 
            this.bt_pentagon.Location = new System.Drawing.Point(422, 11);
            this.bt_pentagon.Name = "bt_pentagon";
            this.bt_pentagon.Size = new System.Drawing.Size(75, 31);
            this.bt_pentagon.TabIndex = 7;
            this.bt_pentagon.Text = "Pen";
            this.bt_pentagon.UseVisualStyleBackColor = true;
            this.bt_pentagon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_pentagon_MouseClick);
            // 
            // bt_hexagon
            // 
            this.bt_hexagon.Location = new System.Drawing.Point(504, 11);
            this.bt_hexagon.Name = "bt_hexagon";
            this.bt_hexagon.Size = new System.Drawing.Size(75, 31);
            this.bt_hexagon.TabIndex = 8;
            this.bt_hexagon.Text = "Hex";
            this.bt_hexagon.UseVisualStyleBackColor = true;
            this.bt_hexagon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_hexagon_MouseClick);
            // 
            // cb_equilateral
            // 
            this.cb_equilateral.AutoSize = true;
            this.cb_equilateral.Location = new System.Drawing.Point(807, 12);
            this.cb_equilateral.Name = "cb_equilateral";
            this.cb_equilateral.Size = new System.Drawing.Size(97, 21);
            this.cb_equilateral.TabIndex = 9;
            this.cb_equilateral.Text = "Equilateral";
            this.cb_equilateral.UseVisualStyleBackColor = true;
            // 
            // bt_polygon
            // 
            this.bt_polygon.Location = new System.Drawing.Point(586, 11);
            this.bt_polygon.Name = "bt_polygon";
            this.bt_polygon.Size = new System.Drawing.Size(75, 31);
            this.bt_polygon.TabIndex = 10;
            this.bt_polygon.Text = "Poly";
            this.bt_polygon.UseVisualStyleBackColor = true;
            this.bt_polygon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_polygon_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.bt_polygon);
            this.Controls.Add(this.cb_equilateral);
            this.Controls.Add(this.bt_hexagon);
            this.Controls.Add(this.bt_pentagon);
            this.Controls.Add(this.bt_rectangle);
            this.Controls.Add(this.bt_ellipse);
            this.Controls.Add(this.bt_circle);
            this.Controls.Add(this.bt_triangle);
            this.Controls.Add(this.bt_line);
            this.Controls.Add(this.openGLControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.Button bt_line;
        private System.Windows.Forms.Button bt_triangle;
        private System.Windows.Forms.Button bt_circle;
        private System.Windows.Forms.Button bt_ellipse;
        private System.Windows.Forms.Button bt_rectangle;
        private System.Windows.Forms.Button bt_pentagon;
        private System.Windows.Forms.Button bt_hexagon;
        private System.Windows.Forms.CheckBox cb_equilateral;
        private System.Windows.Forms.Button bt_polygon;
    }
}

