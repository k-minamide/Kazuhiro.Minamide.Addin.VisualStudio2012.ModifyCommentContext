﻿using System;
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

namespace Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyCommentContext
{
    public partial class CommentEditWindowView : AddinPartView
    {
        private bool commentEditEnable;
        public bool CommentEditEnable
        {
            get
            {
                return this.commentEditEnable;
            }

            set
            {
                this.commentEditEnable = value;

                this.btnAdd.Enabled = this.commentEditEnable;
                this.btnDelete.Enabled = false;
            }
        }

        public CommentEditWindowView()
        {
            InitializeComponent();

            this.dtpDate.Value = DateTime.Now;
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            if(this.ApplicationObject != null
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
                    text.Insert(indentText + GlobalSettings.ToString(true, dtpDate.Value, language));

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
                    text.Insert(indentText + GlobalSettings.ToString(false, dtpDate.Value, language));

                    // 最初の行の先頭文字に移動
                    text.GotoLine(startLine, false);
                    text.StartOfLine(vsStartOfLineOptions.vsStartOfLineOptionsFirstText, false);
                }
            }

            return;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            GlobalSettings.Author = this.txtName.Text;
        }

        private void txtComment_Leave(object sender, EventArgs e)
        {
            GlobalSettings.DefaultComment = this.txtComment.Text;
        }
    }
}
