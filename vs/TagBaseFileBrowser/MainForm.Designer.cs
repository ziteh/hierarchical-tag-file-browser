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
            this.buttonSelectObj = new System.Windows.Forms.Button();
            this.buttonClearTags = new System.Windows.Forms.Button();
            this.buttonWriteObj = new System.Windows.Forms.Button();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.buttonClearFile = new System.Windows.Forms.Button();
            this.textBoxSelectedTags = new System.Windows.Forms.TextBox();
            this.textBoxSelectedObjs = new System.Windows.Forms.TextBox();
            this.pictureBoxObjPreview = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxObjPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(176, 12);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(253, 25);
            this.textBoxPath.TabIndex = 0;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(435, 13);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // treeViewTags
            // 
            this.treeViewTags.Location = new System.Drawing.Point(6, 24);
            this.treeViewTags.Name = "treeViewTags";
            this.treeViewTags.Size = new System.Drawing.Size(278, 359);
            this.treeViewTags.TabIndex = 2;
            this.treeViewTags.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTags_AfterSelect);
            // 
            // listViewObjs
            // 
            this.listViewObjs.HideSelection = false;
            this.listViewObjs.Location = new System.Drawing.Point(6, 24);
            this.listViewObjs.Name = "listViewObjs";
            this.listViewObjs.Size = new System.Drawing.Size(510, 359);
            this.listViewObjs.TabIndex = 3;
            this.listViewObjs.UseCompatibleStateImageBehavior = false;
            this.listViewObjs.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewObjs_ItemSelectionChanged);
            this.listViewObjs.DoubleClick += new System.EventHandler(this.listViewObjs_DoubleClick);
            // 
            // textBoxObjInfo
            // 
            this.textBoxObjInfo.Location = new System.Drawing.Point(522, 418);
            this.textBoxObjInfo.Multiline = true;
            this.textBoxObjInfo.Name = "textBoxObjInfo";
            this.textBoxObjInfo.ReadOnly = true;
            this.textBoxObjInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxObjInfo.Size = new System.Drawing.Size(380, 122);
            this.textBoxObjInfo.TabIndex = 4;
            // 
            // buttonAddTag
            // 
            this.buttonAddTag.Location = new System.Drawing.Point(6, 389);
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.Size = new System.Drawing.Size(75, 23);
            this.buttonAddTag.TabIndex = 5;
            this.buttonAddTag.Text = "Add";
            this.buttonAddTag.UseVisualStyleBackColor = true;
            this.buttonAddTag.Click += new System.EventHandler(this.buttonAddTag_Click);
            // 
            // buttonSelectObj
            // 
            this.buttonSelectObj.Location = new System.Drawing.Point(6, 389);
            this.buttonSelectObj.Name = "buttonSelectObj";
            this.buttonSelectObj.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectObj.TabIndex = 6;
            this.buttonSelectObj.Text = "Add";
            this.buttonSelectObj.UseVisualStyleBackColor = true;
            this.buttonSelectObj.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // buttonClearTags
            // 
            this.buttonClearTags.Location = new System.Drawing.Point(209, 389);
            this.buttonClearTags.Name = "buttonClearTags";
            this.buttonClearTags.Size = new System.Drawing.Size(75, 23);
            this.buttonClearTags.TabIndex = 9;
            this.buttonClearTags.Text = "Clear";
            this.buttonClearTags.UseVisualStyleBackColor = true;
            this.buttonClearTags.Click += new System.EventHandler(this.buttonClearTags_Click);
            // 
            // buttonWriteObj
            // 
            this.buttonWriteObj.Location = new System.Drawing.Point(516, 13);
            this.buttonWriteObj.Name = "buttonWriteObj";
            this.buttonWriteObj.Size = new System.Drawing.Size(75, 23);
            this.buttonWriteObj.TabIndex = 10;
            this.buttonWriteObj.Text = "Write";
            this.buttonWriteObj.UseVisualStyleBackColor = true;
            this.buttonWriteObj.Click += new System.EventHandler(this.buttonWriteObj_Click);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(87, 389);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFile.TabIndex = 11;
            this.buttonOpenFile.Text = "Open New";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // buttonClearFile
            // 
            this.buttonClearFile.Location = new System.Drawing.Point(441, 389);
            this.buttonClearFile.Name = "buttonClearFile";
            this.buttonClearFile.Size = new System.Drawing.Size(75, 23);
            this.buttonClearFile.TabIndex = 13;
            this.buttonClearFile.Text = "Clear";
            this.buttonClearFile.UseVisualStyleBackColor = true;
            this.buttonClearFile.Click += new System.EventHandler(this.buttonClearFile_Click);
            // 
            // textBoxSelectedTags
            // 
            this.textBoxSelectedTags.Location = new System.Drawing.Point(6, 418);
            this.textBoxSelectedTags.Multiline = true;
            this.textBoxSelectedTags.Name = "textBoxSelectedTags";
            this.textBoxSelectedTags.ReadOnly = true;
            this.textBoxSelectedTags.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSelectedTags.Size = new System.Drawing.Size(278, 122);
            this.textBoxSelectedTags.TabIndex = 14;
            // 
            // textBoxSelectedObjs
            // 
            this.textBoxSelectedObjs.Location = new System.Drawing.Point(6, 418);
            this.textBoxSelectedObjs.Multiline = true;
            this.textBoxSelectedObjs.Name = "textBoxSelectedObjs";
            this.textBoxSelectedObjs.ReadOnly = true;
            this.textBoxSelectedObjs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSelectedObjs.Size = new System.Drawing.Size(510, 122);
            this.textBoxSelectedObjs.TabIndex = 14;
            // 
            // pictureBoxObjPreview
            // 
            this.pictureBoxObjPreview.Location = new System.Drawing.Point(522, 24);
            this.pictureBoxObjPreview.Name = "pictureBoxObjPreview";
            this.pictureBoxObjPreview.Size = new System.Drawing.Size(380, 388);
            this.pictureBoxObjPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxObjPreview.TabIndex = 15;
            this.pictureBoxObjPreview.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tag/Obj Database Path:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeViewTags);
            this.groupBox1.Controls.Add(this.textBoxSelectedTags);
            this.groupBox1.Controls.Add(this.buttonAddTag);
            this.groupBox1.Controls.Add(this.buttonClearTags);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 546);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tags";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewObjs);
            this.groupBox2.Controls.Add(this.textBoxSelectedObjs);
            this.groupBox2.Controls.Add(this.buttonSelectObj);
            this.groupBox2.Controls.Add(this.pictureBoxObjPreview);
            this.groupBox2.Controls.Add(this.buttonOpenFile);
            this.groupBox2.Controls.Add(this.buttonClearFile);
            this.groupBox2.Controls.Add(this.textBoxObjInfo);
            this.groupBox2.Location = new System.Drawing.Point(308, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(908, 546);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Objs";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 598);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonWriteObj);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.textBoxPath);
            this.Name = "MainForm";
            this.Text = "Hierarchical Tag File Browser";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxObjPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion Windows Form Designer generated code

        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.TreeView treeViewTags;
        private System.Windows.Forms.ListView listViewObjs;
        private System.Windows.Forms.TextBox textBoxObjInfo;
        private System.Windows.Forms.Button buttonAddTag;
        private System.Windows.Forms.Button buttonSelectObj;
        private System.Windows.Forms.Button buttonClearTags;
        private System.Windows.Forms.Button buttonWriteObj;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Button buttonClearFile;
        private System.Windows.Forms.TextBox textBoxSelectedTags;
        private System.Windows.Forms.TextBox textBoxSelectedObjs;
        private System.Windows.Forms.PictureBox pictureBoxObjPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}