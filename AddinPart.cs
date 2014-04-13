using EnvDTE;
using EnvDTE80;
using Extensibility;

namespace Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyComment
{
    public abstract class AddinPart : IDTExtensibility2, IDTCommandTarget
    {
        protected DTE2 ApplicationObject
        {
            get;
            set;
        }

        protected AddIn AddInInstance
        {
            get;
            set;
        }

        public abstract void OnAddInsUpdate(ref System.Array custom);

        public abstract void OnBeginShutdown(ref System.Array custom);

        public virtual void OnConnection(object Application, ext_ConnectMode ConnectMode, object AddInInst, ref System.Array custom)
        {
            this.ApplicationObject = (DTE2)Application;
            this.AddInInstance = (AddIn)AddInInst;
        }

        public abstract void OnDisconnection(ext_DisconnectMode RemoveMode, ref System.Array custom);

        public abstract void OnStartupComplete(ref System.Array custom);

        public abstract void Exec(string CmdName, vsCommandExecOption ExecuteOption, ref object VariantIn, ref object VariantOut, ref bool Handled);

        public abstract void QueryStatus(string CmdName, vsCommandStatusTextWanted NeededText, ref vsCommandStatus StatusOption, ref object CommandText);
    }
}
