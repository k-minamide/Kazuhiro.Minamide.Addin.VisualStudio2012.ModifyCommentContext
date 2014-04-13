using EnvDTE;
using EnvDTE80;
using Extensibility;

using System.Windows.Forms;

namespace Kazuhiro.Minamide.Addin.VisualStudio2012.ModifyCommentContext
{
    public class AddinPartView : UserControl
    {
        public DTE2 ApplicationObject
        {
            get;
            set;
        }

        public AddIn AddInInstance
        {
            get;
            set;
        }
    }
}
