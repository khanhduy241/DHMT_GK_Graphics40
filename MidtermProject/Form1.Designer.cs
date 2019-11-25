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
            this.bt_Color = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.bt_FloodFill = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.BackColor = System.Drawing.SystemColors.Control;
            this.openGLControl.DrawFPS = false;
            this.openGLControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openGLControl.Location = new System.Drawing.Point(41, 64);
            this.openGLControl.Margin = new System.Windows.Forms.Padding(4);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(734, 387);
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
            this.bt_line.Location = new System.Drawing.Point(9, 10);
            this.bt_line.Margin = new System.Windows.Forms.Padding(2);
            this.bt_line.Name = "bt_line";
            this.bt_line.Size = new System.Drawing.Size(56, 24);
            this.bt_line.TabIndex = 2;
            this.bt_line.Text = "Line";
            this.bt_line.UseVisualStyleBackColor = true;
            this.bt_line.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_line_MouseClick);
            // 
            // bt_triangle
            // 
            this.bt_triangle.Location = new System.Drawing.Point(70, 9);
            this.bt_triangle.Margin = new System.Windows.Forms.Padding(2);
            this.bt_triangle.Name = "bt_triangle";
            this.bt_triangle.Size = new System.Drawing.Size(56, 25);
            this.bt_triangle.TabIndex = 3;
            this.bt_triangle.Text = "Tri";
            this.bt_triangle.UseVisualStyleBackColor = true;
            this.bt_triangle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_triangle_MouseClick);
            // 
            // bt_circle
            // 
            this.bt_circle.Location = new System.Drawing.Point(132, 10);
            this.bt_circle.Margin = new System.Windows.Forms.Padding(2);
            this.bt_circle.Name = "bt_circle";
            this.bt_circle.Size = new System.Drawing.Size(56, 24);
            this.bt_circle.TabIndex = 4;
            this.bt_circle.Text = "Circle";
            this.bt_circle.UseVisualStyleBackColor = true;
            this.bt_circle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_circle_MouseClick);
            // 
            // bt_ellipse
            // 
            this.bt_ellipse.Location = new System.Drawing.Point(194, 9);
            this.bt_ellipse.Margin = new System.Windows.Forms.Padding(2);
            this.bt_ellipse.Name = "bt_ellipse";
            this.bt_ellipse.Size = new System.Drawing.Size(56, 25);
            this.bt_ellipse.TabIndex = 5;
            this.bt_ellipse.Text = "Ellipse";
            this.bt_ellipse.UseVisualStyleBackColor = true;
            this.bt_ellipse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_ellipse_MouseClick);
            // 
            // bt_rectangle
            // 
            this.bt_rectangle.Location = new System.Drawing.Point(255, 9);
            this.bt_rectangle.Margin = new System.Windows.Forms.Padding(2);
            this.bt_rectangle.Name = "bt_rectangle";
            this.bt_rectangle.Size = new System.Drawing.Size(56, 25);
            this.bt_rectangle.TabIndex = 6;
            this.bt_rectangle.Text = "Rec";
            this.bt_rectangle.UseVisualStyleBackColor = true;
            this.bt_rectangle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_rectangle_MouseClick);
            // 
            // bt_pentagon
            // 
            this.bt_pentagon.Location = new System.Drawing.Point(316, 9);
            this.bt_pentagon.Margin = new System.Windows.Forms.Padding(2);
            this.bt_pentagon.Name = "bt_pentagon";
            this.bt_pentagon.Size = new System.Drawing.Size(56, 25);
            this.bt_pentagon.TabIndex = 7;
            this.bt_pentagon.Text = "Pen";
            this.bt_pentagon.UseVisualStyleBackColor = true;
            this.bt_pentagon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_pentagon_MouseClick);
            // 
            // bt_hexagon
            // 
            this.bt_hexagon.Location = new System.Drawing.Point(378, 9);
            this.bt_hexagon.Margin = new System.Windows.Forms.Padding(2);
            this.bt_hexagon.Name = "bt_hexagon";
            this.bt_hexagon.Size = new System.Drawing.Size(56, 25);
            this.bt_hexagon.TabIndex = 8;
            this.bt_hexagon.Text = "Hex";
            this.bt_hexagon.UseVisualStyleBackColor = true;
            this.bt_hexagon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_hexagon_MouseClick);
            // 
            // cb_equilateral
            // 
            this.cb_equilateral.AutoSize = true;
            this.cb_equilateral.Location = new System.Drawing.Point(605, 10);
            this.cb_equilateral.Margin = new System.Windows.Forms.Padding(2);
            this.cb_equilateral.Name = "cb_equilateral";
            this.cb_equilateral.Size = new System.Drawing.Size(75, 17);
            this.cb_equilateral.TabIndex = 9;
            this.cb_equilateral.Text = "Equilateral";
            this.cb_equilateral.UseVisualStyleBackColor = true;
            // 
            // bt_polygon
            // 
            this.bt_polygon.Location = new System.Drawing.Point(440, 9);
            this.bt_polygon.Margin = new System.Windows.Forms.Padding(2);
            this.bt_polygon.Name = "bt_polygon";
            this.bt_polygon.Size = new System.Drawing.Size(56, 25);
            this.bt_polygon.TabIndex = 10;
            this.bt_polygon.Text = "Poly";
            this.bt_polygon.UseVisualStyleBackColor = true;
            this.bt_polygon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_polygon_MouseClick);
            // 
            // bt_Color
            // 
            this.bt_Color.Location = new System.Drawing.Point(713, 6);
            this.bt_Color.Name = "bt_Color";
            this.bt_Color.Size = new System.Drawing.Size(75, 23);
            this.bt_Color.TabIndex = 11;
            this.bt_Color.Text = "Color";
            this.bt_Color.UseVisualStyleBackColor = true;
            this.bt_Color.Click += new System.EventHandler(this.bt_Color_MouseClick);
            // 
            // bt_FloodFill
            // 
            this.bt_FloodFill.Location = new System.Drawing.Point(513, 12);
            this.bt_FloodFill.Name = "bt_FloodFill";
            this.bt_FloodFill.Size = new System.Drawing.Size(75, 23);
            this.bt_FloodFill.TabIndex = 12;
            this.bt_FloodFill.Text = "Flood Fill";
            this.bt_FloodFill.UseVisualStyleBackColor = true;
            this.bt_FloodFill.Click += new System.EventHandler(this.bt_FloodFill_MouseClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(667, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.Text = "Line Width";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.bt_FloodFill);
            this.Controls.Add(this.bt_Color);
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
        private System.Windows.Forms.Button bt_Color;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button bt_FloodFill;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

