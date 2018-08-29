namespace Algo
{
    partial class StackQueue
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
            this.txtElement = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSize = new System.Windows.Forms.Button();
            this.btnPeek = new System.Windows.Forms.Button();
            this.btnPop = new System.Windows.Forms.Button();
            this.stackListBox = new System.Windows.Forms.ListBox();
            this.btnPush = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtElement
            // 
            this.txtElement.Location = new System.Drawing.Point(129, 52);
            this.txtElement.Name = "txtElement";
            this.txtElement.Size = new System.Drawing.Size(75, 20);
            this.txtElement.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSize);
            this.groupBox1.Controls.Add(this.btnPeek);
            this.groupBox1.Controls.Add(this.btnPop);
            this.groupBox1.Controls.Add(this.txtElement);
            this.groupBox1.Controls.Add(this.stackListBox);
            this.groupBox1.Controls.Add(this.btnPush);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(747, 432);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnSize
            // 
            this.btnSize.Location = new System.Drawing.Point(129, 186);
            this.btnSize.Name = "btnSize";
            this.btnSize.Size = new System.Drawing.Size(75, 23);
            this.btnSize.TabIndex = 5;
            this.btnSize.Text = "Size";
            this.btnSize.UseVisualStyleBackColor = true;
            this.btnSize.Click += new System.EventHandler(this.btnSize_Click);
            // 
            // btnPeek
            // 
            this.btnPeek.Location = new System.Drawing.Point(129, 157);
            this.btnPeek.Name = "btnPeek";
            this.btnPeek.Size = new System.Drawing.Size(75, 23);
            this.btnPeek.TabIndex = 4;
            this.btnPeek.Text = "Peek";
            this.btnPeek.UseVisualStyleBackColor = true;
            this.btnPeek.Click += new System.EventHandler(this.btnPeek_Click);
            // 
            // btnPop
            // 
            this.btnPop.Location = new System.Drawing.Point(129, 128);
            this.btnPop.Name = "btnPop";
            this.btnPop.Size = new System.Drawing.Size(75, 23);
            this.btnPop.TabIndex = 3;
            this.btnPop.Text = "Pop";
            this.btnPop.UseVisualStyleBackColor = true;
            this.btnPop.Click += new System.EventHandler(this.btnPop_Click);
            // 
            // stackListBox
            // 
            this.stackListBox.FormattingEnabled = true;
            this.stackListBox.Location = new System.Drawing.Point(238, 52);
            this.stackListBox.Name = "stackListBox";
            this.stackListBox.Size = new System.Drawing.Size(120, 160);
            this.stackListBox.TabIndex = 2;
            // 
            // btnPush
            // 
            this.btnPush.Location = new System.Drawing.Point(129, 99);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(75, 23);
            this.btnPush.TabIndex = 1;
            this.btnPush.Text = "Push";
            this.btnPush.UseVisualStyleBackColor = true;
            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Provide input Value";
            // 
            // StackQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 456);
            this.Controls.Add(this.groupBox1);
            this.Name = "StackQueue";
            this.Text = "StackQueue";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtElement;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSize;
        private System.Windows.Forms.Button btnPeek;
        private System.Windows.Forms.Button btnPop;
        private System.Windows.Forms.ListBox stackListBox;
        private System.Windows.Forms.Button btnPush;
        private System.Windows.Forms.Label label1;
    }
}