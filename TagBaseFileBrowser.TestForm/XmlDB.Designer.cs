
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
            this.treeViewTags = new System.Windows.Forms.TreeView();
            this.listViewObjs = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(12, 14);
            this.textBoxPath.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(276, 25);
            this.textBoxPath.TabIndex = 0;
            // 
            // buttonReadXml
            // 
            this.buttonReadXml.Location = new System.Drawing.Point(292, 14);
            this.buttonReadXml.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonReadXml.Name = "buttonReadXml";
            this.buttonReadXml.Size = new System.Drawing.Size(63, 25);
            this.buttonReadXml.TabIndex = 1;
            this.buttonReadXml.Text = "Read";
            this.buttonReadXml.UseVisualStyleBackColor = true;
            this.buttonReadXml.Click += new System.EventHandler(this.buttonReadXml_Click);
            // 
            // treeViewTags
            // 
            this.treeViewTags.Location = new System.Drawing.Point(12, 41);
            this.treeViewTags.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.treeViewTags.Name = "treeViewTags";
            this.treeViewTags.Size = new System.Drawing.Size(343, 386);
            this.treeViewTags.TabIndex = 4;
            this.treeViewTags.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTags_AfterSelect);
            this.treeViewTags.DoubleClick += new System.EventHandler(this.treeViewTags_DoubleClick);
            // 
            // listViewObjs
            // 
            this.listViewObjs.FullRowSelect = true;
            this.listViewObjs.GridLines = true;
            this.listViewObjs.HideSelection = false;
            this.listViewObjs.Location = new System.Drawing.Point(385, 41);
            this.listViewObjs.Name = "listViewObjs";
            this.listViewObjs.Size = new System.Drawing.Size(494, 384);
            this.listViewObjs.TabIndex = 5;
            this.listViewObjs.UseCompatibleStateImageBehavior = false;
            this.listViewObjs.DoubleClick += new System.EventHandler(this.listViewObjs_DoubleClick);
            // 
            // XmlDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 437);
            this.Controls.Add(this.listViewObjs);
            this.Controls.Add(this.treeViewTags);
            this.Controls.Add(this.buttonReadXml);
            this.Controls.Add(this.textBoxPath);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "XmlDB";
            this.Text = "XML DB Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonReadXml;
        private System.Windows.Forms.TreeView treeViewTags;
        private System.Windows.Forms.ListView listViewObjs;
    }
}

