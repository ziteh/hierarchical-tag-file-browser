
namespace TagBaseFileBrowser
{
    partial class MainForm
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
            this.buttonLoad = new System.Windows.Forms.Button();
            this.treeViewTags = new System.Windows.Forms.TreeView();
            this.listViewObjs = new System.Windows.Forms.ListView();
            this.textBoxObjInfo = new System.Windows.Forms.TextBox();
            this.buttonAddTag = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(13, 13);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(253, 25);
            this.textBoxPath.TabIndex = 0;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(273, 14);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // treeViewTags
            // 
            this.treeViewTags.Location = new System.Drawing.Point(13, 45);
            this.treeViewTags.Name = "treeViewTags";
            this.treeViewTags.Size = new System.Drawing.Size(222, 436);
            this.treeViewTags.TabIndex = 2;
            this.treeViewTags.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTags_AfterSelect);
            // 
            // listViewObjs
            // 
            this.listViewObjs.HideSelection = false;
            this.listViewObjs.Location = new System.Drawing.Point(241, 45);
            this.listViewObjs.Name = "listViewObjs";
            this.listViewObjs.Size = new System.Drawing.Size(508, 346);
            this.listViewObjs.TabIndex = 3;
            this.listViewObjs.UseCompatibleStateImageBehavior = false;
            this.listViewObjs.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewObjs_ItemSelectionChanged);
            this.listViewObjs.DoubleClick += new System.EventHandler(this.listViewObjs_DoubleClick);
            // 
            // textBoxObjInfo
            // 
            this.textBoxObjInfo.Location = new System.Drawing.Point(241, 397);
            this.textBoxObjInfo.Multiline = true;
            this.textBoxObjInfo.Name = "textBoxObjInfo";
            this.textBoxObjInfo.ReadOnly = true;
            this.textBoxObjInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxObjInfo.Size = new System.Drawing.Size(508, 84);
            this.textBoxObjInfo.TabIndex = 4;
            // 
            // buttonAddTag
            // 
            this.buttonAddTag.Location = new System.Drawing.Point(791, 45);
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.Size = new System.Drawing.Size(75, 23);
            this.buttonAddTag.TabIndex = 5;
            this.buttonAddTag.Text = "Add Tag";
            this.buttonAddTag.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 508);
            this.Controls.Add(this.buttonAddTag);
            this.Controls.Add(this.textBoxObjInfo);
            this.Controls.Add(this.listViewObjs);
            this.Controls.Add(this.treeViewTags);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.textBoxPath);
            this.Name = "MainForm";
            this.Text = "Hierarchical Tag File Browser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.TreeView treeViewTags;
        private System.Windows.Forms.ListView listViewObjs;
        private System.Windows.Forms.TextBox textBoxObjInfo;
        private System.Windows.Forms.Button buttonAddTag;
    }
}

