using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyCommentContext
{
    public class Settings
    {
        private string modifyCommentFormat;
        public string ModifyCommentFormat
        {
            get
            {
                return string.IsNullOrEmpty(this.modifyCommentFormat) ? string.Empty : this.modifyCommentFormat;
            }
            set
            {
                this.modifyCommentFormat = value;
            }
        }

        private string author;
        public string Author
        {
            get
            {
                return string.IsNullOrEmpty(this.author) ? string.Empty : this.author;
            }
            set
            {
                this.author = value;
            }
        }

        private string dateTimeFormat;
        public string DateTimeFormat
        {
            get
            {
                return string.IsNullOrEmpty(this.dateTimeFormat) ? string.Empty : this.dateTimeFormat;
            }
            set
            {
                this.dateTimeFormat = value;
            }
        }

        private string defaultComment;
        public string DefaultComment
        {
            get
            {
                return string.IsNullOrEmpty(this.defaultComment) ? string.Empty : this.defaultComment;
            }
            set
            {
                this.defaultComment = value;
            }
        }

        private string startText;
        public string StartText
        {
            get
            {
                return string.IsNullOrEmpty(this.startText) ? string.Empty : this.startText;
            }
            set
            {
                this.startText = value;
            }
        }

        private string endText;
        public string EndText
        {
            get
            {
                return string.IsNullOrEmpty(this.endText) ? string.Empty : this.endText;
            }
            set
            {
                this.endText = value;
            }
        }

        private bool startupVisibility;
        public bool StartupVisibility
        {
            get
            {
                return this.startupVisibility;
            }
            set
            {
                this.startupVisibility = value;
            }
        }



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

            ret += this.ModifyCommentFormat;

            ret = Regex.Replace(ret, @"\[@author\]", this.Author, RegexOptions.IgnoreCase);
            ret = Regex.Replace(ret, @"\[@datetime\]", date.ToString(this.DateTimeFormat), RegexOptions.IgnoreCase);
            ret = Regex.Replace(ret, @"\[@comment\]", this.DefaultComment, RegexOptions.IgnoreCase);
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
    }
}
