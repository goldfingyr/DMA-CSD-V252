namespace GrabImage
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            TbKey = new TextBox();
            label2 = new Label();
            TbSearch = new TextBox();
            BtSearch = new Button();
            LWMovies = new ListView();
            title = new ColumnHeader();
            poster_path = new ColumnHeader();
            PbSelectedImage = new PictureBox();
            BtDownload = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)PbSelectedImage).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 70);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(41, 25);
            label1.TabIndex = 0;
            label1.Text = "KEY";
            // 
            // TbKey
            // 
            TbKey.Location = new Point(17, 100);
            TbKey.Margin = new Padding(4, 5, 4, 5);
            TbKey.Name = "TbKey";
            TbKey.Size = new Size(397, 31);
            TbKey.TabIndex = 1;
            TbKey.Text = "Copy Key Here";
            TbKey.TextChanged += TbKey_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 182);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(114, 25);
            label2.TabIndex = 2;
            label2.Text = "Search string";
            // 
            // TbSearch
            // 
            TbSearch.Location = new Point(17, 212);
            TbSearch.Margin = new Padding(4, 5, 4, 5);
            TbSearch.Name = "TbSearch";
            TbSearch.Size = new Size(397, 31);
            TbSearch.TabIndex = 3;
            TbSearch.Text = "What to search for";
            TbSearch.TextChanged += TbSearch_TextChanged;
            // 
            // BtSearch
            // 
            BtSearch.Location = new Point(20, 293);
            BtSearch.Margin = new Padding(4, 5, 4, 5);
            BtSearch.Name = "BtSearch";
            BtSearch.Size = new Size(107, 38);
            BtSearch.TabIndex = 5;
            BtSearch.Text = "Search";
            BtSearch.UseVisualStyleBackColor = true;
            BtSearch.Click += BtSearch_Click;
            // 
            // LWMovies
            // 
            LWMovies.Columns.AddRange(new ColumnHeader[] { title, poster_path });
            LWMovies.FullRowSelect = true;
            LWMovies.Location = new Point(23, 352);
            LWMovies.Margin = new Padding(4, 5, 4, 5);
            LWMovies.Name = "LWMovies";
            LWMovies.Size = new Size(391, 376);
            LWMovies.TabIndex = 6;
            LWMovies.UseCompatibleStateImageBehavior = false;
            LWMovies.View = View.Details;
            LWMovies.SelectedIndexChanged += LwSelected;
            // 
            // title
            // 
            title.Text = "Title";
            title.Width = 200;
            // 
            // poster_path
            // 
            poster_path.Text = "path";
            // 
            // PbSelectedImage
            // 
            PbSelectedImage.Location = new Point(504, 100);
            PbSelectedImage.Margin = new Padding(4, 5, 4, 5);
            PbSelectedImage.Name = "PbSelectedImage";
            PbSelectedImage.Size = new Size(303, 612);
            PbSelectedImage.SizeMode = PictureBoxSizeMode.Zoom;
            PbSelectedImage.TabIndex = 7;
            PbSelectedImage.TabStop = false;
            // 
            // BtDownload
            // 
            BtDownload.Location = new Point(549, 722);
            BtDownload.Margin = new Padding(4, 5, 4, 5);
            BtDownload.Name = "BtDownload";
            BtDownload.Size = new Size(107, 38);
            BtDownload.TabIndex = 8;
            BtDownload.Text = "Download";
            BtDownload.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(505, 58);
            label3.Name = "label3";
            label3.Size = new Size(63, 25);
            label3.TabIndex = 9;
            label3.Text = "Billede";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 780);
            Controls.Add(label3);
            Controls.Add(BtDownload);
            Controls.Add(PbSelectedImage);
            Controls.Add(LWMovies);
            Controls.Add(BtSearch);
            Controls.Add(TbSearch);
            Controls.Add(label2);
            Controls.Add(TbKey);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)PbSelectedImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TbKey;
        private Label label2;
        private TextBox TbSearch;
        private Button BtSearch;
        private ListView LWMovies;
        private ColumnHeader title;
        private ColumnHeader MovieID;
        private ColumnHeader poster_path;
        private PictureBox PbSelectedImage;
        private Button BtDownload;
        private Label label3;
    }
}
