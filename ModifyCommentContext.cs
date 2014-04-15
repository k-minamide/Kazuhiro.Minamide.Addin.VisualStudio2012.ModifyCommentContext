using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using EnvDTE;
using EnvDTE80;

using Extensibility;

using Microsoft.VisualStudio.CommandBars;


namespace Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyComment
{
    public class ModifyCommentContext : AddinPart
    {
        /// <summary>
        /// GUID
        /// </summary>
        public static readonly Guid GUID = new Guid("{6d1aaab5-5a9f-476b-827a-51dee77cffab}");

        /// <summary>
        /// ツール名
        /// </summary>
        public const string ToolName = "ModifyCommentContext";

        /// <summary>
        /// 表示名
        /// </summary>
        public const string DisplayName = "修正コメント挿入";

        /// <summary>
        /// 説明
        /// </summary>
        public const string Caption = "修正コメント画面を挿入します";

        /// <summary>
        /// コマンド名
        /// </summary>
        public const string CommandName = "Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyComment.Connect.ModifyCommentContext";

        public override void OnConnection(object Application, Extensibility.ext_ConnectMode ConnectMode, object AddInInst, ref Array custom)
        {
            base.OnConnection(Application, ConnectMode, AddInInst, ref custom);

            if(ConnectMode == ext_ConnectMode.ext_cm_Startup)
            {
                Commands2 commands = (Commands2)this.ApplicationObject.Commands;

                //コマンドを [ツール] メニューに配置します。
                //メイン メニュー項目のすべてを保持するトップレベル コマンド バーである、MenuBar コマンド バーを検索します:
                CommandBar contextMenuBar = ((CommandBars)ApplicationObject.CommandBars)["Code Window"];

                //アドインによって処理する複数のコマンドを追加する場合、この try ブロックおよび catch ブロックを重複できます。
                //  ただし、新しいコマンド名を含めるために QueryStatus メソッドおよび Exec メソッドの更新も実行してください。
                try
                {
                    //コマンド コレクションにコマンドを追加します:
                    object[] reflectionGUID = GUID.ToByteArray().Select(x => (object)x).ToArray();
                    Command command = commands.AddNamedCommand2(AddInInstance, ToolName, DisplayName, Caption, true, 59, ref reflectionGUID, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);

                    //コマンドのコントロールを [ツール] メニューに追加します:
                    if((command != null) && (contextMenuBar != null))
                    {
                        command.AddControl(contextMenuBar);
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

        public override void OnAddInsUpdate(ref Array custom)
        {
        }

        public override void OnBeginShutdown(ref Array custom)
        {
        }

        public override void OnDisconnection(Extensibility.ext_DisconnectMode RemoveMode, ref Array custom)
        {
        }

        public override void OnStartupComplete(ref Array custom)
        {
        }

        public override void Exec(string CmdName, EnvDTE.vsCommandExecOption ExecuteOption, ref object VariantIn, ref object VariantOut, ref bool Handled)
        {
            if(CommandName.Equals(CmdName)
                && this.ApplicationObject != null
                && this.ApplicationObject.ActiveDocument != null)
            {
                // applicationObjからアクティブドキュメント(ソースエディタ)を取得
                Document doc = this.ApplicationObject.ActiveDocument;

                if(doc.Selection != null)
                {
                    // 選択中のテキストを取得する
                    // ※基本的にこのTextSelectionを利用してソースコードの編集を行う
                    TextSelection text = (TextSelection)doc.Selection;

                    // 言語の取得
                    string language = string.Empty;
                    try
                    {
                        language = doc.Language.ToLower();
                    }
                    catch
                    {
                        language = string.Empty;
                    }

                    // 選択行の最初と最後の行番号を取得
                    int startLine = text.TopLine;
                    int endLine = text.BottomLine;
                    // 最後が改行文字のみの場合は、最後の行を背選択していないものとする
                    if(Regex.IsMatch(text.Text, "(\\r\\n|\\r|\\n)$"))
                    {
                        endLine--;
                    }

                    // 元の行番号を保存
                    int baseStartLine = startLine;
                    int baseEndLine = endLine;

                    // スペースのみの行を差し引く
                    for(int line = startLine ; line < endLine ; line++)
                    {
                        text.GotoLine(line, true);
                        if(Regex.IsMatch(text.Text, "^\\s*$"))
                        {
                            startLine++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    for(int line = endLine ; line > startLine ; line--)
                    {
                        text.GotoLine(line, true);
                        if(Regex.IsMatch(text.Text, "^\\s*$"))
                        {
                            endLine--;
                        }
                        else
                        {
                            break;
                        }
                    }

                    // すべてスペースのみの場合は、選択行の最初と最後にコメントを追加する
                    if(startLine == endLine)
                    {
                        text.GotoLine(startLine, true);
                        if(Regex.IsMatch(text.Text, "^\\s*$"))
                        {
                            startLine = baseStartLine;
                            endLine = baseEndLine;
                        }
                    }

                    // 選択中テキストの先頭行に移動
                    text.GotoLine(startLine, true);

                    // 改行時にインデントが変更されてしまうので最初行を保存
                    string startLineText = text.Text;

                    // 行の先頭に移動
                    text.StartOfLine(vsStartOfLineOptions.vsStartOfLineOptionsFirstColumn, false);
                    // 新規行を作成
                    text.NewLine(1);
                    // 行追加されたので、最終行が変更
                    endLine++;

                    // インデント量の取得
                    string indentText = new string(' ', text.TopPoint.VirtualCharOffset - 1);

                    // 最初の行のインデントが変更されたのを元に戻す
                    text.GotoLine(startLine + 1, true);
                    text.Text = string.Empty;
                    text.Insert(startLineText);

                    // 修正開始コメントを挿入
                    // 先頭行に移動
                    text.GotoLine(startLine, false);
                    // 行の先頭に移動
                    text.StartOfLine(vsStartOfLineOptions.vsStartOfLineOptionsFirstColumn, false);
                    // 修正コメント(開始)を追加する
                    text.Insert(indentText + GlobalSettings.ToString(true, language));

                    // 選択中テキストの末行に移動
                    text.GotoLine(endLine, false);
                    // 行の末尾に移動
                    text.EndOfLine(false);
                    // 行を新規に作成する
                    text.NewLine(1);
                    // 行追加されたので、最終行が変更
                    endLine++;

                    // 修正終了コメントを挿入
                    // 最後の行に移動
                    text.GotoLine(endLine, false);
                    // 行の先頭に移動
                    text.StartOfLine(vsStartOfLineOptions.vsStartOfLineOptionsFirstColumn, false);
                    // 修正コメント(終了)を追加する
                    text.Insert(indentText + GlobalSettings.ToString(false, language));

                    // 最初の行のから最後の行目で選択
                    text.GotoLine(startLine + 1, false);
                    text.StartOfLine(vsStartOfLineOptions.vsStartOfLineOptionsFirstColumn, false);
                    text.MoveToLineAndOffset(endLine, 1, true);
                    text.CharLeft(true);
                }
            }
        }

        public override void QueryStatus(string CmdName, EnvDTE.vsCommandStatusTextWanted NeededText, ref EnvDTE.vsCommandStatus StatusOption, ref object CommandText)
        {
            if(NeededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone
                && CommandName.Equals(CmdName))
            {
                StatusOption = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
            }
        }
    }
}
