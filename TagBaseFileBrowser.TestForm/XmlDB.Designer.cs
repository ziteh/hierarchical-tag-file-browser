
namespace TagBaseFileBrowser.TestForm
{
    partial class XmlDB
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonTagDB = new System.Windows.Forms.RadioButton();
            this.radioButtonObjDB = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(12, 33);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(547, 38);
            this.textBoxPath.TabIndex = 0;
            // 
            // buttonReadXml
            // 
            this.buttonReadXml.Location = new System.Drawing.Point(12, 90);
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
            this.labelContent.Location = new System.Drawing.Point(12, 196);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(33, 32);
            this.labelContent.TabIndex = 2;
            this.labelContent.Text = "--";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonObjDB);
            this.groupBox1.Controls.Add(this.radioButtonTagDB);
            this.groupBox1.Location = new System.Drawing.Point(735, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 218);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type";
            // 
            // radioButtonTagDB
            // 
            this.radioButtonTagDB.AutoSize = true;
            this.radioButtonTagDB.Checked = true;
            this.radioButtonTagDB.Location = new System.Drawing.Point(19, 62);
            this.radioButtonTagDB.Name = "radioButtonTagDB";
            this.radioButtonTagDB.Size = new System.Drawing.Size(147, 36);
            this.radioButtonTagDB.TabIndex = 0;
            this.radioButtonTagDB.TabStop = true;
            this.radioButtonTagDB.Text = "Tag DB";
            this.radioButtonTagDB.UseVisualStyleBackColor = true;
            // 
            // radioButtonObjDB
            // 
            this.radioButtonObjDB.AutoSize = true;
            this.radioButtonObjDB.Location = new System.Drawing.Point(19, 104);
            this.radioButtonObjDB.Name = "radioButtonObjDB";
            this.radioButtonObjDB.Size = new System.Drawing.Size(143, 36);
            this.radioButtonObjDB.TabIndex = 0;
            this.radioButtonObjDB.Text = "Obj DB";
            this.radioButtonObjDB.UseVisualStyleBackColor = true;
            // 
            // XmlTagDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 904);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelContent);
            this.Controls.Add(this.buttonReadXml);
            this.Controls.Add(this.textBoxPath);
            this.Name = "XmlTagDB";
            this.Text = "XML DB Test";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonReadXml;
        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonObjDB;
        private System.Windows.Forms.RadioButton radioButtonTagDB;
    }
}

