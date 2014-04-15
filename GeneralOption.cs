using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyComment
{
    public partial class GeneralOption : UserControl
    {
        public GeneralOption()
        {
            InitializeComponent();

            this.txtCommentFormat.Text = GlobalSettings.CommentFormat;
            this.txtAuthor.Text = GlobalSettings.Author;
            this.txtDateTimeFormat.Text = GlobalSettings.DateTimeFormat;
            this.txtStartText.Text = GlobalSettings.StartText;
            this.txtEndText.Text = GlobalSettings.EndText;
            this.txtBugFix.Text = GlobalSettings.BugFixText;
            this.txtAdd.Text = GlobalSettings.AddText;
            this.txtModify.Text = GlobalSettings.ModifyText;

            GlobalSettings.CommentFormatChanged += GlobalSettings_CommentFormatChanged;
            GlobalSettings.AuthorChanged += GlobalSettings_AuthorChanged;
            GlobalSettings.DateTimeFormatChanged += GlobalSettings_DateTimeFormatChanged;
            GlobalSettings.StartTextChanged += GlobalSettings_StartTextChanged;
            GlobalSettings.EndTextChanged += GlobalSettings_EndTextChanged;
            GlobalSettings.BugFixTextChanged += GlobalSettings_BugFixTextChanged;
            GlobalSettings.AddTextChanged += GlobalSettings_AddTextChanged;
            GlobalSettings.ModifyTextChanged += GlobalSettings_ModifyTextChanged;
        }

        private void txtCommentFormat_TextChanged(object sender, EventArgs e)
        {
            GlobalSettings.CommentFormat = this.txtCommentFormat.Text;
        }

        void GlobalSettings_CommentFormatChanged(object sender, EventArgs e)
        {
            this.txtCommentFormat.Text = GlobalSettings.CommentFormat;
        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {
            GlobalSettings.Author = txtAuthor.Text;
        }

        void GlobalSettings_AuthorChanged(object sender, EventArgs e)
        {
            this.txtAuthor.Text = GlobalSettings.Author;
        }

        private void txtDateTimeFormat_TextChanged(object sender, EventArgs e)
        {
            GlobalSettings.DateTimeFormat = this.txtDateTimeFormat.Text;
        }

        void GlobalSettings_DateTimeFormatChanged(object sender, EventArgs e)
        {
            this.txtDateTimeFormat.Text = GlobalSettings.DateTimeFormat;
        }
        
        private void txtStartText_TextChanged(object sender, EventArgs e)
        {
            GlobalSettings.StartText = this.txtStartText.Text;
        }

        void GlobalSettings_StartTextChanged(object sender, EventArgs e)
        {
            this.txtStartText.Text = GlobalSettings.StartText;
        }

        private void txtEndText_TextChanged(object sender, EventArgs e)
        {
            GlobalSettings.EndText = this.txtEndText.Text;
        }

        void GlobalSettings_EndTextChanged(object sender, EventArgs e)
        {
            this.txtEndText.Text = GlobalSettings.EndText;
        }

        private void txtBugFix_TextChanged(object sender, EventArgs e)
        {
            GlobalSettings.BugFixText = this.txtBugFix.Text;
        }

        void GlobalSettings_BugFixTextChanged(object sender, EventArgs e)
        {
            this.txtBugFix.Text = GlobalSettings.BugFixText;
        }

        private void txtAdd_TextChanged(object sender, EventArgs e)
        {
            GlobalSettings.AddText = this.txtAdd.Text;
        }

        void GlobalSettings_AddTextChanged(object sender, EventArgs e)
        {
            this.txtAdd.Text = GlobalSettings.AddText;
        }

        private void txtModify_TextChanged(object sender, EventArgs e)
        {
            GlobalSettings.ModifyText = this.txtModify.Text;
        }

        void GlobalSettings_ModifyTextChanged(object sender, EventArgs e)
        {
            this.txtModify.Text = GlobalSettings.ModifyText;
        }
    }
}
