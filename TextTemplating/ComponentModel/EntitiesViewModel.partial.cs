using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.ComponentModel
{
    /// <summary>
    /// 
    /// </summary>
    public partial class EntitiesViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public void TransformText()
        {
            this.OutputPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), this.Namespace);

            var entities = new Entities(this);
            entities.CreateEntities();

            TextTemplatingProcess.StartExplorer(this.OutputPath);
        }

        #region Private members...
        
        #endregion

    }
}