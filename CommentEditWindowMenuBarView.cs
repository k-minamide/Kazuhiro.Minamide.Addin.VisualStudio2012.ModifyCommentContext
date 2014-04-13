using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnvDTE;
using EnvDTE80;
using Extensibility;

using Microsoft.VisualStudio.CommandBars;


namespace Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyComment
{
    public class CommentEditWindowMenuBarView : AddinPart
    {
        /// <summary>
        /// GUID
        /// </summary>
        public static readonly Guid GUID = new Guid("{61a09248-bbe0-4760-99c8-1f23370a4d50}");

        /// <summary>
        /// ツール名
        /// </summary>
        public const string ToolName = "ModifyCommentMenuBarViewWidnowView";

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
        public const string CommandName = "Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyComment.Connect.ModifyCommentMenuBarViewWidnowView";

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

                //コマンドを [ツール] メニューに配置します。
                //メイン メニュー項目のすべてを保持するトップレベル コマンド バーである、MenuBar コマンド バーを検索します:
                Microsoft.VisualStudio.CommandBars.CommandBar menuBar = ((Microsoft.VisualStudio.CommandBars.CommandBars)ApplicationObject.CommandBars)["MenuBar"];

                //MenuBar コマンド バーで [ツール] コマンド バーを検索します:
                CommandBarControl viewMenuBar = menuBar.Controls["View"];
                CommandBarPopup viewPopup = (CommandBarPopup)viewMenuBar;

                //アドインによって処理する複数のコマンドを追加する場合、この try ブロックおよび catch ブロックを重複できます。
                //  ただし、新しいコマンド名を含めるために QueryStatus メソッドおよび Exec メソッドの更新も実行してください。
                try
                {
                    //コマンド コレクションにコマンドを追加します:
                    object[] reflectionGUID = GUID.ToByteArray().Select(x => (object)x).ToArray();
                    Command command = commands.AddNamedCommand2(AddInInstance, ToolName, DisplayName, Caption, true, 59, ref reflectionGUID, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);

                    //コマンドのコントロールを [ツール] メニューに追加します:
                    if((command != null) && (viewPopup != null))
                    {
                        command.AddControl(viewPopup.CommandBar, viewPopup.Controls.Count + 1);
                    }
                }
                catch(System.ArgumentException)
                {
                    //同じ名前のコマンドが既に存在しているため、例外が発生した可能性があります。
                    //  その場合、コマンドを再作成する必要はありません。 例外を 
                    //  無視しても安全です。
                }
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
            if(CommandName.Equals(CmdName))
            {
                IEnumerator windows = this.ApplicationObject.Windows.GetEnumerator();
                windows.Reset();
                while(windows.MoveNext())
                {
                    if(windows != null && windows.Current != null && windows.Current is Window)
                    {
                        Window window = (Window)windows.Current;
                        if(window.Object is CommentEditWindowView)
                        {
                            window.Visible = !window.Visible;
                            break;
                        }
                    }
                }
            }
        }

        public override void QueryStatus(string CmdName, vsCommandStatusTextWanted NeededText, ref vsCommandStatus StatusOption, ref object CommandText)
        {
            if(NeededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone
                && CommandName.Equals(CmdName))
            {
                StatusOption = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                return;
            }
        }
    }
}
