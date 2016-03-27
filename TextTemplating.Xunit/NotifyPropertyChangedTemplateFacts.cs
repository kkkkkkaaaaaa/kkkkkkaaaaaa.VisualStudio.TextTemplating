using kkkkkkaaaaaa.VisualStudio.TextTemplating;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;
using Xunit;

namespace kkkkkkaaaaaa.VIsualStudio.TextTemplating.Xunit
{
    public class NotifyPropertyChangedTemplateFacts
    {
        [Fact()]
        public void Fact()
        {
            var entity  = new EntitiesContext()
            {
                Namespace = @"Namespace",
                Imports = new [] { @"Import", },
                TypeName = @"TypeName",
                TypeNameSuffix = @"Suffix",
                Inherits = @"BaseClass",
                Columns = new []
                {
                    new SqlColumnsSchemaEntity() { ColumnName = @"ColumnName", ColumnSize = 1, DataType = typeof(string), DataTypeName = @"string", NumericScale = 7 },
                }
            };

            var template = new NotifyPropertyChangedTemplate(entity);
            var text = template.TransformText();
        }
    }
}