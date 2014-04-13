namespace Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyComment
{
    partial class GeneralOption
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCommentFormat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtDateTimeFormat = new System.Windows.Forms.TextBox();
            this.txtStartText = new System.Windows.Forms.TextBox();
            this.txtEndText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBugFix = new System.Windows.Forms.TextBox();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.txtModify = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "コメント形式";
            // 
            // txtCommentFormat
            // 
            this.txtCommentFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommentFormat.Location = new System.Drawing.Point(88, 3);
            this.txtCommentFormat.Name = "txtCommentFormat";
            this.txtCommentFormat.Size = new System.Drawing.Size(359, 19);
            this.txtCommentFormat.TabIndex = 1;
            this.txtCommentFormat.TextChanged += new System.EventHandler(this.txtCommentFormat_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "作成者";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "日付フォーマット";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "開始文字";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "終了文字";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthor.Location = new System.Drawing.Point(88, 28);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(359, 19);
            this.txtAuthor.TabIndex = 1;
            this.txtAuthor.TextChanged += new System.EventHandler(this.txtAuthor_TextChanged);
            // 
            // txtDateTimeFormat
            // 
            this.txtDateTimeFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateTimeFormat.Location = new System.Drawing.Point(88, 53);
            this.txtDateTimeFormat.Name = "txtDateTimeFormat";
            this.txtDateTimeFormat.Size = new System.Drawing.Size(359, 19);
            this.txtDateTimeFormat.TabIndex = 1;
            this.txtDateTimeFormat.TextChanged += new System.EventHandler(this.txtDateTimeFormat_TextChanged);
            // 
            // txtStartText
            // 
            this.txtStartText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartText.Location = new System.Drawing.Point(88, 78);
            this.txtStartText.Name = "txtStartText";
            this.txtStartText.Size = new System.Drawing.Size(359, 19);
            this.txtStartText.TabIndex = 1;
            this.txtStartText.TextChanged += new System.EventHandler(this.txtStartText_TextChanged);
            // 
            // txtEndText
            // 
            this.txtEndText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndText.Location = new System.Drawing.Point(88, 103);
            this.txtEndText.Name = "txtEndText";
            this.txtEndText.Size = new System.Drawing.Size(359, 19);
            this.txtEndText.TabIndex = 1;
            this.txtEndText.TextChanged += new System.EventHandler(this.txtEndText_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "障害修正文字";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "機能追加文字";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "機能修正文字";
            // 
            // txtBugFix
            // 
            this.txtBugFix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBugFix.Location = new System.Drawing.Point(88, 128);
            this.txtBugFix.Name = "txtBugFix";
            this.txtBugFix.Size = new System.Drawing.Size(359, 19);
            this.txtBugFix.TabIndex = 1;
            this.txtBugFix.TextChanged += new System.EventHandler(this.txtBugFix_TextChanged);
            // 
            // txtAdd
            // 
            this.txtAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdd.Location = new System.Drawing.Point(88, 153);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(359, 19);
            this.txtAdd.TabIndex = 1;
            this.txtAdd.TextChanged += new System.EventHandler(this.txtAdd_TextChanged);
            // 
            // txtModify
            // 
            this.txtModify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModify.Location = new System.Drawing.Point(88, 178);
            this.txtModify.Name = "txtModify";
            this.txtModify.Size = new System.Drawing.Size(359, 19);
            this.txtModify.TabIndex = 1;
            this.txtModify.TextChanged += new System.EventHandler(this.txtModify_TextChanged);
            // 
            // GeneralOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtModify);
            this.Controls.Add(this.txtEndText);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.txtStartText);
            this.Controls.Add(this.txtBugFix);
            this.Controls.Add(this.txtDateTimeFormat);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtCommentFormat);
            this.Controls.Add(this.label1);
            this.Name = "GeneralOption";
            this.Size = new System.Drawing.Size(450, 201);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCommentFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtDateTimeFormat;
        private System.Windows.Forms.TextBox txtStartText;
        private System.Windows.Forms.TextBox txtEndText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBugFix;
        private System.Windows.Forms.TextBox txtAdd;
        private System.Windows.Forms.TextBox txtModify;
    }
}
