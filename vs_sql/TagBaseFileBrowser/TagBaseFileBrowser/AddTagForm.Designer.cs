namespace TagBaseFileBrowser
{
    partial class AddTagForm
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
            this.comboBoxParentTag = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.comboBoxChildTag = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxParentTag
            // 
            this.comboBoxParentTag.FormattingEnabled = true;
            this.comboBoxParentTag.Location = new System.Drawing.Point(27, 28);
            this.comboBoxParentTag.Margin = new System.Windows.Forms.Padding(1);
            this.comboBoxParentTag.Name = "comboBoxParentTag";
            this.comboBoxParentTag.Size = new System.Drawing.Size(95, 20);
            this.comboBoxParentTag.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(144, 199);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(1);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(85, 24);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // comboBoxChildTag
            // 
            this.comboBoxChildTag.FormattingEnabled = true;
            this.comboBoxChildTag.Location = new System.Drawing.Point(144, 28);
            this.comboBoxChildTag.Name = "comboBoxChildTag";
            this.comboBoxChildTag.Size = new System.Drawing.Size(121, 20);
            this.comboBoxChildTag.TabIndex = 4;
            // 
            // AddTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 268);
            this.Controls.Add(this.comboBoxChildTag);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.comboBoxParentTag);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "AddTagForm";
            this.Text = "AddTagForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxParentTag;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ComboBox comboBoxChildTag;
    }
}