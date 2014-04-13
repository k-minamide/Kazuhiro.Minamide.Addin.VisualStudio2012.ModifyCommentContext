using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;

namespace Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyComment
{
	/// <summary>アドインを実装するためのオブジェクトです。</summary>
	/// <seealso class='IDTExtensibility2' />
    public class Connect : IDTExtensibility2, IDTCommandTarget
	{
        private DTE2 ApplicationObject;
        private List<AddinPart> addinParts;

		/// <summary>アドイン オブジェクトのコンストラクターを実装します。初期化コードをこのメソッド内に配置してください。</summary>
		public Connect()
		{
            this.AddAddinPart(new CommentEditWindowMenuBarView());
            this.AddAddinPart(new CommentEditWindow());
            this.AddAddinPart(new ModifyCommentContext());
		}

        private void AddAddinPart(AddinPart addinPart)
        {
            if(this.addinParts == null)
            {
                this.addinParts = new List<AddinPart>();
            }

            this.addinParts.Add(addinPart);
        }

		/// <summary>IDTExtensibility2 インターフェイスの OnConnection メソッドを実装します。アドインが読み込まれる際に通知を受けます。</summary>
		/// <param term='application'>ホスト アプリケーションのルート オブジェクトです。</param>
		/// <param term='connectMode'>アドインの読み込み状態を説明します。</param>
		/// <param term='addInInst'>このアドインを表すオブジェクトです。</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
		{
            this.ApplicationObject = (DTE2)application;

            foreach(AddinPart addinPart in this.addinParts)
            {
                if(addinPart != null)
                {
                    addinPart.OnConnection(application, connectMode, addInInst, ref custom);
                }
            }
		}

		/// <summary>IDTExtensibility2 インターフェイスの OnDisconnection メソッドを実装します。アドインがアンロードされる際に通知を受けます。</summary>
		/// <param term='disconnectMode'>アドインのアンロード状態を説明します。</param>
		/// <param term='custom'>ホスト アプリケーション固有のパラメーターの配列です。</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
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
                        GlobalSettings.StartupVisibility = window.Visible;
                        break;
                    }
                }
            }
            GlobalSettings.SaveXml();

            foreach(AddinPart addinPart in this.addinParts)
            {
                if(addinPart != null)
                {
                    addinPart.OnDisconnection(disconnectMode, ref custom);
                }
            }
        }

		/// <summary>IDTExtensibility2 インターフェイスの OnAddInsUpdate メソッドを実装します。アドインのコレクションが変更されたときに通知を受けます。</summary>
		/// <param term='custom'>ホスト アプリケーション固有のパラメーターの配列です。</param>
		/// <seealso class='IDTExtensibility2' />		
		public void OnAddInsUpdate(ref Array custom)
		{
            foreach(AddinPart addinPart in this.addinParts)
            {
                if(addinPart != null)
                {
                    addinPart.OnAddInsUpdate(ref custom);
                }
            }
		}

		/// <summary>IDTExtensibility2 インターフェイスの OnStartupComplete メソッドを実装します。ホスト アプリケーションが読み込みを終了したときに通知を受けます。</summary>
		/// <param term='custom'>ホスト アプリケーション固有のパラメーターの配列です。</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref Array custom)
		{
            foreach(AddinPart addinPart in this.addinParts)
            {
                if(addinPart != null)
                {
                    addinPart.OnStartupComplete(ref custom);
                }
            }
		}

		/// <summary>IDTExtensibility2 インターフェイスの OnBeginShutdown メソッドを実装します。ホスト アプリケーションがアンロードされる際に通知を受けます。</summary>
		/// <param term='custom'>ホスト アプリケーション固有のパラメーターの配列です。</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref Array custom)
		{
            foreach(AddinPart addinPart in this.addinParts)
            {
                if(addinPart != null)
                {
                    addinPart.OnBeginShutdown(ref custom);
                }
            }
		}

        /// <summary>IDTCommandTarget インターフェイスの QueryStatus メソッドを実装します。これは、コマンドの可用性が更新されたときに呼び出されます。</summary>
        /// <param term='commandName'>状態を決定するためのコマンド名です。</param>
        /// <param term='neededText'>コマンドに必要なテキストです。</param>
        /// <param term='status'>ユーザー インターフェイス内のコマンドの状態です。</param>
        /// <param term='commandText'>neededText パラメーターから要求されたテキストです。</param>
        /// <seealso class='Exec' />
        public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
        {
            foreach(AddinPart addinPart in this.addinParts)
            {
                if(addinPart != null)
                {
                    addinPart.QueryStatus(commandName, neededText, ref status, ref commandText);
                }
            }
        }

        /// <summary>IDTCommandTarget インターフェイスの Exec メソッドを実装します。これは、コマンドが実行されるときに呼び出されます。</summary>
        /// <param term='commandName'>実行するコマンド名です。</param>
        /// <param term='executeOption'>コマンドの実行方法を説明します。</param>
        /// <param term='varIn'>呼び出し元からコマンド ハンドラーへ渡されたパラメーターです。</param>
        /// <param term='varOut'>コマンド ハンドラーから呼び出し元へ渡されたパラメーターです。</param>
        /// <param term='handled'>コマンドが処理されたかどうかを呼び出し元に通知します。</param>
        /// <seealso class='Exec' />
        public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
        {
            handled = false;

            foreach(AddinPart addinPart in this.addinParts)
            {
                if(addinPart != null)
                {
                    addinPart.Exec(commandName, executeOption, ref varIn, ref varOut, ref handled);
                }
            }

            handled = true;
            return;
        }
	}
}