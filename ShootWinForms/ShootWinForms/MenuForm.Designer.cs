namespace ShootWinForms
{
    partial class MenuForm
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
            this.gameStart = new System.Windows.Forms.Button();
            this.hightscoreButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameStart
            // 
            this.gameStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameStart.Cursor = System.Windows.Forms.Cursors.Default;
            this.gameStart.Location = new System.Drawing.Point(323, 175);
            this.gameStart.Name = "gameStart";
            this.gameStart.Size = new System.Drawing.Size(150, 40);
            this.gameStart.TabIndex = 0;
            this.gameStart.Text = "Game Start";
            this.gameStart.UseVisualStyleBackColor = true;
            this.gameStart.Click += new System.EventHandler(this.gameStart_Click);
            // 
            // hightscoreButton
            // 
            this.hightscoreButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hightscoreButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.hightscoreButton.Location = new System.Drawing.Point(323, 221);
            this.hightscoreButton.Name = "hightscoreButton";
            this.hightscoreButton.Size = new System.Drawing.Size(150, 40);
            this.hightscoreButton.TabIndex = 1;
            this.hightscoreButton.Text = "Highscore";
            this.hightscoreButton.UseVisualStyleBackColor = true;
            this.hightscoreButton.Click += new System.EventHandler(this.hightscoreButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.exitButton.Location = new System.Drawing.Point(323, 267);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(150, 40);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.hightscoreButton);
            this.Controls.Add(this.gameStart);
            this.Name = "MenuForm";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button gameStart;
        private System.Windows.Forms.Button hightscoreButton;
        private System.Windows.Forms.Button exitButton;
    }
}