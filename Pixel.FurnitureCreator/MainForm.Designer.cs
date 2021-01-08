namespace Pixel.FurnitureCreator
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.addImage = new System.Windows.Forms.Button();
            this.imagesList = new System.Windows.Forms.ListBox();
            this.preview = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageNames = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rotation = new System.Windows.Forms.TextBox();
            this.state = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.layer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.depth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.itemPreview = new System.Windows.Forms.PictureBox();
            this.offX = new System.Windows.Forms.NumericUpDown();
            this.offY = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.furnoName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.furnoType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.states = new System.Windows.Forms.NumericUpDown();
            this.anim = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.animationsList = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.animationId = new System.Windows.Forms.NumericUpDown();
            this.frames = new System.Windows.Forms.ListBox();
            this.frame = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.layers = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.states)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layers)).BeginInit();
            this.SuspendLayout();
            // 
            // addImage
            // 
            this.addImage.Location = new System.Drawing.Point(12, 129);
            this.addImage.Name = "addImage";
            this.addImage.Size = new System.Drawing.Size(234, 23);
            this.addImage.TabIndex = 0;
            this.addImage.Text = "Add image to the list";
            this.addImage.UseVisualStyleBackColor = true;
            this.addImage.Click += new System.EventHandler(this.addImage_Click);
            // 
            // imagesList
            // 
            this.imagesList.FormattingEnabled = true;
            this.imagesList.Location = new System.Drawing.Point(12, 28);
            this.imagesList.Name = "imagesList";
            this.imagesList.Size = new System.Drawing.Size(234, 95);
            this.imagesList.TabIndex = 1;
            this.imagesList.SelectedIndexChanged += new System.EventHandler(this.imagesList_SelectedIndexChanged);
            // 
            // preview
            // 
            this.preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(66)))), ((int)(((byte)(124)))));
            this.preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.preview.Location = new System.Drawing.Point(252, 256);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(344, 244);
            this.preview.TabIndex = 3;
            this.preview.TabStop = false;
            this.preview.Click += new System.EventHandler(this.preview_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(886, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // imageNames
            // 
            this.imageNames.FormattingEnabled = true;
            this.imageNames.Location = new System.Drawing.Point(602, 28);
            this.imageNames.Name = "imageNames";
            this.imageNames.Size = new System.Drawing.Size(272, 108);
            this.imageNames.TabIndex = 11;
            this.imageNames.SelectedIndexChanged += new System.EventHandler(this.imageNames_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Selected item info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Rotation";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rotation
            // 
            this.rotation.Location = new System.Drawing.Point(15, 290);
            this.rotation.Name = "rotation";
            this.rotation.Size = new System.Drawing.Size(100, 20);
            this.rotation.TabIndex = 14;
            this.rotation.TextChanged += new System.EventHandler(this.rotation_TextChanged);
            // 
            // state
            // 
            this.state.Location = new System.Drawing.Point(15, 330);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(100, 20);
            this.state.TabIndex = 16;
            this.state.TextChanged += new System.EventHandler(this.state_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "State";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layer
            // 
            this.layer.Location = new System.Drawing.Point(15, 370);
            this.layer.Name = "layer";
            this.layer.Size = new System.Drawing.Size(100, 20);
            this.layer.TabIndex = 18;
            this.layer.TextChanged += new System.EventHandler(this.layer_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Layer";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // depth
            // 
            this.depth.Location = new System.Drawing.Point(121, 290);
            this.depth.Name = "depth";
            this.depth.Size = new System.Drawing.Size(100, 20);
            this.depth.TabIndex = 20;
            this.depth.TextChanged += new System.EventHandler(this.depth_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Depth (10 = user depth)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(118, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Offset Y";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(118, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Offset X";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // itemPreview
            // 
            this.itemPreview.BackColor = System.Drawing.Color.White;
            this.itemPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.itemPreview.Location = new System.Drawing.Point(252, 28);
            this.itemPreview.Name = "itemPreview";
            this.itemPreview.Size = new System.Drawing.Size(344, 222);
            this.itemPreview.TabIndex = 25;
            this.itemPreview.TabStop = false;
            // 
            // offX
            // 
            this.offX.Location = new System.Drawing.Point(122, 329);
            this.offX.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.offX.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.offX.Name = "offX";
            this.offX.Size = new System.Drawing.Size(99, 20);
            this.offX.TabIndex = 27;
            this.offX.ValueChanged += new System.EventHandler(this.offX_ValueChanged_2);
            // 
            // offY
            // 
            this.offY.Location = new System.Drawing.Point(122, 371);
            this.offY.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.offY.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.offY.Name = "offY";
            this.offY.Size = new System.Drawing.Size(99, 20);
            this.offY.TabIndex = 28;
            this.offY.ValueChanged += new System.EventHandler(this.offY_ValueChanged_1);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // furnoName
            // 
            this.furnoName.Location = new System.Drawing.Point(12, 188);
            this.furnoName.Name = "furnoName";
            this.furnoName.Size = new System.Drawing.Size(100, 20);
            this.furnoName.TabIndex = 32;
            this.furnoName.TextChanged += new System.EventHandler(this.furnoName_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Name";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Furniture info";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Type";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // furnoType
            // 
            this.furnoType.FormattingEnabled = true;
            this.furnoType.Items.AddRange(new object[] {
            "item_wall",
            "item_floor_static",
            "item_floor_animated"});
            this.furnoType.Location = new System.Drawing.Point(12, 227);
            this.furnoType.Name = "furnoType";
            this.furnoType.Size = new System.Drawing.Size(103, 21);
            this.furnoType.TabIndex = 34;
            this.furnoType.Text = "item_floor_static";
            this.furnoType.SelectedIndexChanged += new System.EventHandler(this.furnoType_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(118, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "States";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // states
            // 
            this.states.Location = new System.Drawing.Point(121, 189);
            this.states.Name = "states";
            this.states.Size = new System.Drawing.Size(99, 20);
            this.states.TabIndex = 36;
            this.states.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // anim
            // 
            this.anim.Interval = 42;
            this.anim.Tick += new System.EventHandler(this.anim_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(603, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(271, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "Copy selected name";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(603, 172);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "Animations";
            // 
            // animationsList
            // 
            this.animationsList.FormattingEnabled = true;
            this.animationsList.Location = new System.Drawing.Point(602, 188);
            this.animationsList.Name = "animationsList";
            this.animationsList.Size = new System.Drawing.Size(272, 108);
            this.animationsList.TabIndex = 39;
            this.animationsList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(707, 299);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 23);
            this.button2.TabIndex = 41;
            this.button2.Text = "Add animation with id";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // animationId
            // 
            this.animationId.Location = new System.Drawing.Point(602, 302);
            this.animationId.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.animationId.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.animationId.Name = "animationId";
            this.animationId.Size = new System.Drawing.Size(99, 20);
            this.animationId.TabIndex = 40;
            // 
            // frames
            // 
            this.frames.FormattingEnabled = true;
            this.frames.Location = new System.Drawing.Point(602, 329);
            this.frames.Name = "frames";
            this.frames.Size = new System.Drawing.Size(272, 108);
            this.frames.TabIndex = 42;
            // 
            // frame
            // 
            this.frame.Location = new System.Drawing.Point(602, 443);
            this.frame.Name = "frame";
            this.frame.Size = new System.Drawing.Size(221, 20);
            this.frame.TabIndex = 43;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(829, 441);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 23);
            this.button3.TabIndex = 44;
            this.button3.Text = "Add frames";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(602, 469);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(124, 23);
            this.button4.TabIndex = 45;
            this.button4.Text = "Play";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(732, 469);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(142, 23);
            this.button5.TabIndex = 46;
            this.button5.Text = "Stop";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // layers
            // 
            this.layers.Location = new System.Drawing.Point(124, 229);
            this.layers.Name = "layers";
            this.layers.Size = new System.Drawing.Size(99, 20);
            this.layers.TabIndex = 48;
            this.layers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.layers.ValueChanged += new System.EventHandler(this.layers_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(121, 212);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Layers";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 514);
            this.Controls.Add(this.layers);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.frame);
            this.Controls.Add(this.frames);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.animationId);
            this.Controls.Add(this.animationsList);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.states);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.furnoType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.furnoName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.offY);
            this.Controls.Add(this.offX);
            this.Controls.Add(this.itemPreview);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.depth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.layer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.state);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rotation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageNames);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.imagesList);
            this.Controls.Add(this.addImage);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Furniture Creator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.states)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addImage;
        private System.Windows.Forms.ListBox imagesList;
        private System.Windows.Forms.PictureBox preview;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ListBox imageNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rotation;
        private System.Windows.Forms.TextBox state;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox layer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox depth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox itemPreview;
        private System.Windows.Forms.NumericUpDown offX;
        private System.Windows.Forms.NumericUpDown offY;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox furnoName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox furnoType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown states;
        private System.Windows.Forms.Timer anim;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox animationsList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown animationId;
        private System.Windows.Forms.ListBox frames;
        private System.Windows.Forms.TextBox frame;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.NumericUpDown layers;
        private System.Windows.Forms.Label label13;
    }
}

