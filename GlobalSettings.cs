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
    public static class GlobalSettings
    {
        public static readonly string SettingsXmlFilePath;

        public const string DefaultCommentFormat = " [@modify]:[@author] [@comment] - [@datetime] - [@startend]";

        public const string DefaultAuthor = "Author";

        public const string DefaultDateTimeFormat = "yyyy/MM/dd";

        public const string DefaultComment = "修正コメントを入力してください。";

        public const string DefaultStartText = "Start";

        public const string DefaultEndText = "End";

        public const string DefaultBugFixText = "BUBFIX";

        public const string DefaultAddText = "ADD";
 
        public const string DefaultModifyText = "MOD";

        private static Settings setting;

        static GlobalSettings()
        {
            SettingsXmlFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyComment.Settings.xml";

            setting = Settings.LoadXml(SettingsXmlFilePath);
            if(string.IsNullOrEmpty(setting.CommentFormat))
            {
                setting.CommentFormat = DefaultCommentFormat;
            }
            if(string.IsNullOrEmpty(setting.Author))
            {
                setting.Author = DefaultAuthor;
            }
            if(string.IsNullOrEmpty(setting.DateTimeFormat))
            {
                setting.DateTimeFormat = DefaultDateTimeFormat;
            }
            if(string.IsNullOrEmpty(setting.Comment))
            {
                setting.Comment = DefaultComment;
            }
            if(string.IsNullOrEmpty(setting.StartText))
            {
                setting.StartText = DefaultStartText;
            }
            if(string.IsNullOrEmpty(setting.EndText))
            {
                setting.EndText = DefaultEndText;
            }
            if(string.IsNullOrEmpty(setting.BugFixText))
            {
                setting.BugFixText = DefaultBugFixText;
            }
            if(string.IsNullOrEmpty(setting.AddText))
            {
                setting.AddText = DefaultAddText;
            }
            if(string.IsNullOrEmpty(setting.ModifyText))
            {
                setting.ModifyText = DefaultModifyText;
            }
        }

        public static string CommentFormat
        {
            get
            {
                return setting.CommentFormat;
            }
            set
            {
                ExecuteEvent(CommentFormatChanging);
                setting.CommentFormat = value;
                ExecuteEvent(CommentFormatChanged);
            }
        }
        public static event EventHandler CommentFormatChanging;
        public static event EventHandler CommentFormatChanged;

        public static string Author
        {
            get
            {
                return setting.Author;
            }
            set
            {
                ExecuteEvent(AuthorChanging);
                setting.Author = value;
                ExecuteEvent(AuthorChanged);
            }
        }
        public static event EventHandler AuthorChanging;
        public static event EventHandler AuthorChanged;

        public static string DateTimeFormat
        {
            get
            {
                return setting.DateTimeFormat;
            }
            set
            {
                ExecuteEvent(DateTimeFormatChanging);
                setting.DateTimeFormat = value;
                ExecuteEvent(DateTimeFormatChanged);
            }
        }
        public static event EventHandler DateTimeFormatChanging;
        public static event EventHandler DateTimeFormatChanged;

        public static string Comment
        {
            get
            {
                return setting.Comment;
            }
            set
            {
                ExecuteEvent(CommentChanging);
                setting.Comment = value;
                ExecuteEvent(CommentChanged);
            }
        }
        public static event EventHandler CommentChanging;
        public static event EventHandler CommentChanged;

        public static string StartText
        {
            get
            {
                return setting.StartText;
            }
            set
            {
                ExecuteEvent(StartTextChanging);
                setting.StartText = value;
                ExecuteEvent(StartTextChanged);
            }
        }
        public static event EventHandler StartTextChanging;
        public static event EventHandler StartTextChanged;

        public static string EndText
        {
            get
            {
                return setting.EndText;
            }
            set
            {
                ExecuteEvent(EndTextChanging);
                setting.EndText = value;
                ExecuteEvent(EndTextChanged);
            }
        }
        public static event EventHandler EndTextChanging;
        public static event EventHandler EndTextChanged;

        public static string BugFixText
        {
            get
            {
                return setting.BugFixText;
            }
            set
            {
                ExecuteEvent(BugFixTextChanging);
                setting.BugFixText = value;
                ExecuteEvent(BugFixTextChanged);
            }
        }
        public static event EventHandler BugFixTextChanging;
        public static event EventHandler BugFixTextChanged;

        public static string AddText
        {
            get
            {
                return setting.AddText;
            }
            set
            {
                ExecuteEvent(AddTextChanging);
                setting.AddText = value;
                ExecuteEvent(AddTextChanged);
            }
        }
        public static event EventHandler AddTextChanging;
        public static event EventHandler AddTextChanged;

        public static string ModifyText
        {
            get
            {
                return setting.ModifyText;
            }
            set
            {
                ExecuteEvent(ModifyTextChanging);
                setting.ModifyText = value;
                ExecuteEvent(ModifyTextChanged);
            }
        }
        public static event EventHandler ModifyTextChanging;
        public static event EventHandler ModifyTextChanged;

        public static bool BugFixChecked
        {
            get
            {
                return setting.BugFixChecked;
            }
            set
            {
                ExecuteEvent(BugFixCheckedChanging);
                setting.BugFixChecked = value;
                ExecuteEvent(BugFixCheckedChanged);
            }
        }
        public static event EventHandler BugFixCheckedChanging;
        public static event EventHandler BugFixCheckedChanged;

        public static bool AddChecked
        {
            get
            {
                return setting.AddChecked;
            }
            set
            {
                ExecuteEvent(AddCheckedChanging);
                setting.AddChecked = value;
                ExecuteEvent(AddCheckedChanged);
            }
        }
        public static event EventHandler AddCheckedChanging;
        public static event EventHandler AddCheckedChanged;

        public static bool ModifyChecked
        {
            get
            {
                return setting.ModifyChecked;
            }
            set
            {
                ExecuteEvent(ModifyCheckedCheckedChanging);
                setting.ModifyChecked = value;
                ExecuteEvent(ModifyCheckedCheckedChanged);
            }
        }
        public static event EventHandler ModifyCheckedCheckedChanging;
        public static event EventHandler ModifyCheckedCheckedChanged;

        public static bool StartupVisibility
        {
            get
            {
                return setting.StartupVisibility;
            }
            set
            {
                ExecuteEvent(StartupVisibilityChanging);
                setting.StartupVisibility = value;
                ExecuteEvent(StartupVisibilityChanged);
            }
        }
        public static event EventHandler StartupVisibilityChanging;
        public static event EventHandler StartupVisibilityChanged;

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
            return SaveXml(SettingsXmlFilePath);
        }

        public static bool SaveXml(string filePath)
        {
            return setting.SaveXml(filePath);
        }

        private static void ExecuteEvent(EventHandler eventDelegate)
        {
            if(eventDelegate != null)
            {
                eventDelegate(setting, new EventArgs());
            }
        }

    }
}
