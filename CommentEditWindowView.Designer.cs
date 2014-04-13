namespace Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyCommentContext
{
    partial class CommentEditWindowView
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.radBugFix = new System.Windows.Forms.RadioButton();
            this.radAdd = new System.Windows.Forms.RadioButton();
            this.radModify = new System.Windows.Forms.RadioButton();
            this.splName = new System.Windows.Forms.SplitContainer();
            this.lblName = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splName)).BeginInit();
            this.splName.Panel1.SuspendLayout();
            this.splName.Panel2.SuspendLayout();
            this.splName.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyCommentContext.Properties.Resources.AddComment;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyCommentContext.Properties.Resources.UnComment;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(32, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(3, 5);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(29, 12);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "日付";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(50, 0);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(74, 19);
            this.txtName.TabIndex = 3;
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate.CustomFormat = "yyyy/MM/dd";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(38, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(104, 19);
            this.dtpDate.TabIndex = 4;
            this.dtpDate.Value = new System.DateTime(2014, 4, 13, 0, 0, 0, 0);
            // 
            // radBugFix
            // 
            this.radBugFix.AutoSize = true;
            this.radBugFix.Enabled = false;
            this.radBugFix.Location = new System.Drawing.Point(61, 6);
            this.radBugFix.Name = "radBugFix";
            this.radBugFix.Size = new System.Drawing.Size(71, 16);
            this.radBugFix.TabIndex = 5;
            this.radBugFix.Text = "障害修正";
            this.radBugFix.UseVisualStyleBackColor = true;
            // 
            // radAdd
            // 
            this.radAdd.AutoSize = true;
            this.radAdd.Enabled = false;
            this.radAdd.Location = new System.Drawing.Point(138, 6);
            this.radAdd.Name = "radAdd";
            this.radAdd.Size = new System.Drawing.Size(71, 16);
            this.radAdd.TabIndex = 5;
            this.radAdd.Text = "機能追加";
            this.radAdd.UseVisualStyleBackColor = true;
            // 
            // radModify
            // 
            this.radModify.AutoSize = true;
            this.radModify.Checked = true;
            this.radModify.Location = new System.Drawing.Point(215, 6);
            this.radModify.Name = "radModify";
            this.radModify.Size = new System.Drawing.Size(71, 16);
            this.radModify.TabIndex = 5;
            this.radModify.TabStop = true;
            this.radModify.Text = "機能修正";
            this.radModify.UseVisualStyleBackColor = true;
            // 
            // splName
            // 
            this.splName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splName.Location = new System.Drawing.Point(292, 3);
            this.splName.Name = "splName";
            // 
            // splName.Panel1
            // 
            this.splName.Panel1.Controls.Add(this.dtpDate);
            this.splName.Panel1.Controls.Add(this.lblDate);
            // 
            // splName.Panel2
            // 
            this.splName.Panel2.Controls.Add(this.lblName);
            this.splName.Panel2.Controls.Add(this.txtName);
            this.splName.Size = new System.Drawing.Size(274, 19);
            this.splName.SplitterDistance = 145;
            this.splName.TabIndex = 6;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "修正者";
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(3, 31);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(38, 12);
            this.lblComment.TabIndex = 7;
            this.lblComment.Text = "コメント";
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(47, 28);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(519, 19);
            this.txtComment.TabIndex = 8;
            this.txtComment.Leave += new System.EventHandler(this.txtComment_Leave);
            // 
            // CommentEditWindowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.splName);
            this.Controls.Add(this.radModify);
            this.Controls.Add(this.radAdd);
            this.Controls.Add(this.radBugFix);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Name = "CommentEditWindowView";
            this.Size = new System.Drawing.Size(569, 123);
            this.splName.Panel1.ResumeLayout(false);
            this.splName.Panel1.PerformLayout();
            this.splName.Panel2.ResumeLayout(false);
            this.splName.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splName)).EndInit();
            this.splName.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.RadioButton radBugFix;
        private System.Windows.Forms.RadioButton radAdd;
        private System.Windows.Forms.RadioButton radModify;
        private System.Windows.Forms.SplitContainer splName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
    }
}
