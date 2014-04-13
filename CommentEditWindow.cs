using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using EnvDTE;
using EnvDTE80;
using Extensibility;

namespace Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyComment
{
    public partial class CommentEditWindow : AddinPart
    {
        /// <summary>
        /// GUID
        /// </summary>
        public static readonly Guid GUID = new Guid("{0dae80bb-411d-4a6d-9ee1-28b88fe03f24}");

        public const string ClassFullName = "Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyComment.CommentEditWindowView";

        /// <summary>
        /// ツール名
        /// </summary>
        public const string ToolName = "ModifyCommentWindowCommentEditWindow";

        /// <summary>
        /// 表示名
        /// </summary>
        public const string DisplayName = "修正コメント";

        /// <summary>
        /// 説明
        /// </summary>
        public const string Caption = "修正コメント画面を表示/非表示します";

        /// <summary>
        /// コマンド名
        /// </summary>
        public const string CommandName = "Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyComment.Connect.ModifyCommentWindowCommentEditWindow";

        private CommentEditWindowView window = null;

        public override void OnAddInsUpdate(ref Array custom)
        {
        }

        public override void OnBeginShutdown(ref Array custom)
        {
        }

        public override void OnConnection(object Application, ext_ConnectMode ConnectMode, object AddInInst, ref Array custom)
        {
            base.OnConnection(Application, ConnectMode, AddInInst, ref custom);

            if(ConnectMode == ext_ConnectMode.ext_cm_Startup)
            {
                Commands2 commands = (Commands2)this.ApplicationObject.Commands;

                object programmableObject = null;
                EnvDTE80.Windows2 window2 = null;

                System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();

                window2 = (EnvDTE80.Windows2)this.ApplicationObject.Windows;
                Window _windowToolWindow = window2.CreateToolWindow2(this.AddInInstance,
                                                          asm.Location,
                                                          ClassFullName,
                                                          DisplayName,
                                                          GUID.ToString(),
                                                          ref programmableObject);

                window = (CommentEditWindowView)programmableObject;
                window.ApplicationObject = this.ApplicationObject;
                window.AddInInstance = this.AddInInstance;
                _windowToolWindow.Visible = GlobalSettings.StartupVisibility;
            }
        }

        public override void OnDisconnection(ext_DisconnectMode RemoveMode, ref Array custom)
        {
        }

        public override void OnStartupComplete(ref Array custom)
        {
        }

        public override void Exec(string CmdName, vsCommandExecOption ExecuteOption, ref object VariantIn, ref object VariantOut, ref bool Handled)
        {
        }

        public override void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
        {
            if(neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
            {
                string language = string.Empty;
                string documentName = string.Empty;
                try
                {
                    Document activeDocument = this.ApplicationObject.ActiveDocument;
                    if(activeDocument != null)
                    {
                        if(!string.IsNullOrEmpty(activeDocument.Language))
                        {
                            language = activeDocument.Language.ToLower();
                        }

                        if(!string.IsNullOrEmpty(activeDocument.Name))
                        {
                            documentName = activeDocument.ActiveWindow.Caption;
                        }
                    }
                }
                catch
                {
                    language = string.Empty;
                }

                this.window.CommentEditEnable = ("csharp".Equals(language)
                                                       || "basic".Equals(language)
                                                       || "c/c++".Equals(language)
                                                       || "f#".Equals(language)
                                                       || "javascript".Equals(language))
                                                   && documentName != null
                                                   && !documentName.EndsWith("]");
            }
        }
    }
}
