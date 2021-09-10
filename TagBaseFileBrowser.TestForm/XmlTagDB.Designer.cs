
namespace TagBaseFileBrowser.TestForm
{
    partial class XmlTagDB
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
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonReadXml = new System.Windows.Forms.Button();
            this.labelContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(63, 86);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(547, 38);
            this.textBoxPath.TabIndex = 0;
            // 
            // buttonReadXml
            // 
            this.buttonReadXml.Location = new System.Drawing.Point(680, 73);
            this.buttonReadXml.Name = "buttonReadXml";
            this.buttonReadXml.Size = new System.Drawing.Size(166, 85);
            this.buttonReadXml.TabIndex = 1;
            this.buttonReadXml.Text = "Read";
            this.buttonReadXml.UseVisualStyleBackColor = true;
            this.buttonReadXml.Click += new System.EventHandler(this.buttonReadXml_Click);
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(71, 218);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(33, 32);
            this.labelContent.TabIndex = 2;
            this.labelContent.Text = "--";
            // 
            // XmlTagDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 904);
            this.Controls.Add(this.labelContent);
            this.Controls.Add(this.buttonReadXml);
            this.Controls.Add(this.textBoxPath);
            this.Name = "XmlTagDB";
            this.Text = "XML TagDB Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonReadXml;
        private System.Windows.Forms.Label labelContent;
    }
}

