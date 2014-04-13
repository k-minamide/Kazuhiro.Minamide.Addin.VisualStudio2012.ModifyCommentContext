using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyComment
{
    public class Settings
    {
        private string commentFormat;
        public string CommentFormat
        {
            get
            {
                return string.IsNullOrEmpty(this.commentFormat) ? string.Empty : this.commentFormat;
            }
            set
            {
                this.ExecuteEvent(CommentFormatChanging);
                this.commentFormat = value;
                this.ExecuteEvent(CommentFormatChanged);
            }
        }
        public event EventHandler CommentFormatChanging;
        public event EventHandler CommentFormatChanged;

        private string author;
        public string Author
        {
            get
            {
                return string.IsNullOrEmpty(this.author) ? string.Empty : this.author;
            }
            set
            {
                this.ExecuteEvent(AuthorChanging);
                this.author = value;
                this.ExecuteEvent(AuthorChanged);
            }
        }
        public event EventHandler AuthorChanging;
        public event EventHandler AuthorChanged;

        private string dateTimeFormat;
        public string DateTimeFormat
        {
            get
            {
                return string.IsNullOrEmpty(this.dateTimeFormat) ? string.Empty : this.dateTimeFormat;
            }
            set
            {
                this.ExecuteEvent(DateTimeFormatChanging);
                this.dateTimeFormat = value;
                this.ExecuteEvent(DateTimeFormatChanged);
            }
        }
        public event EventHandler DateTimeFormatChanging;
        public event EventHandler DateTimeFormatChanged;

        private string comment;
        public string Comment
        {
            get
            {
                return string.IsNullOrEmpty(this.comment) ? string.Empty : this.comment;
            }
            set
            {
                this.ExecuteEvent(CommentChanging);
                this.comment = value;
                this.ExecuteEvent(CommentChanged);
            }
        }
        public event EventHandler CommentChanging;
        public event EventHandler CommentChanged;

        private string startText;
        public string StartText
        {
            get
            {
                return string.IsNullOrEmpty(this.startText) ? string.Empty : this.startText;
            }
            set
            {
                this.ExecuteEvent(StartTextChanging);
                this.startText = value;
                this.ExecuteEvent(StartTextChanged);
            }
        }
        public event EventHandler StartTextChanging;
        public event EventHandler StartTextChanged;

        private string endText;
        public string EndText
        {
            get
            {
                return string.IsNullOrEmpty(this.endText) ? string.Empty : this.endText;
            }
            set
            {
                this.ExecuteEvent(EndTextChanging);
                this.endText = value;
                this.ExecuteEvent(EndTextChanged);
            }
        }
        public event EventHandler EndTextChanging;
        public event EventHandler EndTextChanged;

        private string bugFixText;
        public string BugFixText
        {
            get
            {
                return string.IsNullOrEmpty(this.bugFixText) ? string.Empty : this.bugFixText;
            }
            set
            {
                this.ExecuteEvent(BugFixTextChanging);
                this.bugFixText = value;
                this.ExecuteEvent(BugFixTextChanged);
            }
        }
        public event EventHandler BugFixTextChanging;
        public event EventHandler BugFixTextChanged;

        private string addText;
        public string AddText
        {
            get
            {
                return string.IsNullOrEmpty(this.addText) ? string.Empty : this.addText;
            }
            set
            {
                this.ExecuteEvent(AddTextChanging);
                this.addText = value;
                this.ExecuteEvent(AddTextChanged);
            }
        }
        public event EventHandler AddTextChanging;
        public event EventHandler AddTextChanged;

        private string modifyText;
        public string ModifyText
        {
            get
            {
                return string.IsNullOrEmpty(this.modifyText) ? string.Empty : this.modifyText;
            }
            set
            {
                this.ExecuteEvent(ModifyTextChanging);
                this.modifyText = value;
                this.ExecuteEvent(ModifyTextChanged);
            }
        }
        public event EventHandler ModifyTextChanging;
        public event EventHandler ModifyTextChanged;

        private bool bugFixChecked;
        public bool BugFixChecked
        {
            get
            {
                return bugFixChecked;
            }
            set
            {
                this.ExecuteEvent(BugFixCheckedChanging);
                this.bugFixChecked = value;
                this.ExecuteEvent(BugFixCheckedChanged);
            }
        }
        public event EventHandler BugFixCheckedChanging;
        public event EventHandler BugFixCheckedChanged;

        private bool addChecked;
        public bool AddChecked
        {
            get
            {
                return addChecked;
            }
            set
            {
                this.ExecuteEvent(AddCheckedChanging);
                this.addChecked = value;
                this.ExecuteEvent(AddCheckedChanged);
            }
        }
        public event EventHandler AddCheckedChanging;
        public event EventHandler AddCheckedChanged;

        private bool modifyChecked;
        public bool ModifyChecked
        {
            get
            {
                return modifyChecked;
            }
            set
            {
                this.ExecuteEvent(ModifyCheckedCheckedChanging);
                this.modifyChecked = value;
                this.ExecuteEvent(ModifyCheckedCheckedChanged);
            }
        }
        public event EventHandler ModifyCheckedCheckedChanging;
        public event EventHandler ModifyCheckedCheckedChanged;

        private bool startupVisibility;
        public bool StartupVisibility
        {
            get
            {
                return this.startupVisibility;
            }
            set
            {
                this.ExecuteEvent(StartupVisibilityChanging);
                this.startupVisibility = value;
                this.ExecuteEvent(StartupVisibilityChanged);
            }
        }
        public event EventHandler StartupVisibilityChanging;
        public event EventHandler StartupVisibilityChanged;



        public override string ToString()
        {
            return this.ToString("csharp");
        }

        public string ToString(string language = "csharp")
        {
            return this.ToString(null, language);
        }

        /// <summary>
        /// 文字列変換します。
        /// </summary>
        /// <param name="isStart">開始コメントの場合true、終了コメントの場合false</param>
        /// <returns>置き換えをしたコメント</returns>
        public string ToString(bool? isStart, string language = "csharp")
        {
            return this.ToString(isStart, DateTime.Now, language);
        }

        /// <summary>
        /// 文字列変換します。
        /// </summary>
        /// <param name="isStart">開始コメントの場合true、終了コメントの場合false</param>
        /// <returns>置き換えをしたコメント</returns>
        public string ToString(bool? isStart, DateTime date, string language = "csharp")
        {
            string ret = string.Empty;
            switch(language)
            {
                case ("csharp"):
                case ("c/c++"):
                case ("f#"):
                case ("javascript"):
                    ret = "//";
                    break;
                case ("basic"):
                    ret = "'";
                    break;
            }

            ret += this.CommentFormat;

            string modifyText = (this.BugFixChecked ? this.BugFixText : string.Empty)
                                    + (this.AddChecked ? this.AddText : string.Empty)
                                    + (this.ModifyChecked ? this.ModifyText : string.Empty);

            ret = Regex.Replace(ret, @"\[@modify\]", modifyText, RegexOptions.IgnoreCase);
            ret = Regex.Replace(ret, @"\[@author\]", this.Author, RegexOptions.IgnoreCase);
            ret = Regex.Replace(ret, @"\[@datetime\]", date.ToString(this.DateTimeFormat), RegexOptions.IgnoreCase);
            ret = Regex.Replace(ret, @"\[@comment\]", this.Comment, RegexOptions.IgnoreCase);
            if(!isStart.HasValue)
            {
                ret = Regex.Replace(ret, @"\[@startend\]", this.StartText + this.EndText, RegexOptions.IgnoreCase);
            }
            if(isStart.Value)
            {
                ret = Regex.Replace(ret, @"\[@startend\]", this.StartText, RegexOptions.IgnoreCase);
            }
            else
            {
                ret = Regex.Replace(ret, @"\[@startend\]", this.EndText, RegexOptions.IgnoreCase);
            }

            return ret;
        }

        public static Settings LoadXml(string filePath)
        {
            Settings ret = new Settings();

            try
            {
                //XmlSerializerオブジェクトを作成
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Settings));

                //読み込むファイルを開く
                using(FileStream fs = new FileStream(filePath, System.IO.FileMode.Open))
                {
                    //XMLファイルから読み込み、逆シリアル化する
                    ret = (Settings)serializer.Deserialize(fs);
                }
            }
            catch
            {
            }

            return ret;
        }

        public bool SaveXml(string filePath)
        {
            bool ret = false;

            try
            {
                //XmlSerializerオブジェクトを作成
                //オブジェクトの型を指定する
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(this.GetType());

                //書き込むファイルを開く
                using(FileStream fs = new FileStream(filePath, System.IO.FileMode.Create))
                {
                    //シリアル化し、XMLファイルに保存する
                    serializer.Serialize(fs, this);
                    ret = true;
                }
            }
            catch
            {
            }

            return ret;
        }

        private void ExecuteEvent(EventHandler eventDelegate)
        {
            if(eventDelegate != null)
            {
                eventDelegate(this, new EventArgs());
            }
        }
    }
}
