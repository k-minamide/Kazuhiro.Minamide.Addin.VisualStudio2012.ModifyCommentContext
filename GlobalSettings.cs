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
    public static class GlobalSettings
    {
        public static readonly string SettingsXmlFilePath;

        public const string DefaultModifyCommentFormat = " MOD:[@author] [@comment] - [@datetime] - [@startend]";

        public const string DefaultAuthor = "Author";

        public const string DefaultDateTimeFormat = "yyyy/MM/dd";

        public const string DefaultDefaultComment = "修正コメントを入力してください。";

        public const string DefaultStartText = "Start";

        public const string DefaultEndText = "End";

        private static Settings setting;

        static GlobalSettings()
        {
            SettingsXmlFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyCommentContext.Settings.xml";

            setting = Settings.LoadXml(SettingsXmlFilePath);
            if(string.IsNullOrEmpty(setting.ModifyCommentFormat))
            {
                setting.ModifyCommentFormat = DefaultModifyCommentFormat;
            }
            if(string.IsNullOrEmpty(setting.Author))
            {
                setting.Author = DefaultAuthor;
            }
            if(string.IsNullOrEmpty(setting.DateTimeFormat))
            {
                setting.DateTimeFormat = DefaultDateTimeFormat;
            }
            if(string.IsNullOrEmpty(setting.DefaultComment))
            {
                setting.DefaultComment = DefaultDefaultComment;
            }
            if(string.IsNullOrEmpty(setting.StartText))
            {
                setting.StartText = DefaultStartText;
            }
            if(string.IsNullOrEmpty(setting.EndText))
            {
                setting.EndText = DefaultEndText;
            }
        }

        public static string ModifyCommentFormat
        {
            get
            {
                return setting.ModifyCommentFormat;
            }
            set
            {
                setting.ModifyCommentFormat = value;
            }
        }

        public static string Author
        {
            get
            {
                return setting.Author;
            }
            set
            {
                setting.Author = value;
            }
        }

        public static string DateTimeFormat
        {
            get
            {
                return setting.DateTimeFormat;
            }
            set
            {
                setting.DateTimeFormat = value;
            }
        }

        public static string DefaultComment
        {
            get
            {
                return setting.DefaultComment;
            }
            set
            {
                setting.DefaultComment = value;
            }
        }

        public static string StartText
        {
            get
            {
                return setting.StartText;
            }
            set
            {
                setting.StartText = value;
            }
        }

        public static string EndText
        {
            get
            {
                return setting.EndText;
            }
            set
            {
                setting.EndText = value;
            }
        }

        public static bool StartupVisibility
        {
            get
            {
                return setting.StartupVisibility;
            }
            set
            {
                setting.StartupVisibility = value;
            }
        }

        public static string ToString()
        {
            return setting.ToString();
        }

        public static string ToString(string language = "csharp")
        {
            return setting.ToString(language);
        }

        /// <summary>
        /// 文字列変換します。
        /// </summary>
        /// <param name="isStart">開始コメントの場合true、終了コメントの場合false</param>
        /// <returns>置き換えをしたコメント</returns>
        public static string ToString(bool isStart, string language = "csharp")
        {
            return setting.ToString(isStart, language);
        }

        /// <summary>
        /// 文字列変換します。
        /// </summary>
        /// <param name="isStart">開始コメントの場合true、終了コメントの場合false</param>
        /// <returns>置き換えをしたコメント</returns>
        public static string ToString(bool isStart, DateTime date, string language = "csharp")
        {
            return setting.ToString(isStart, date, language);
        }

        public static bool SaveXml()
        {
            return setting.SaveXml(SettingsXmlFilePath);
        }
    }
}
