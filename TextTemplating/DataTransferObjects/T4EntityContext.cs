using System.Collections;
using System.Collections.Generic;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects
{
    public class T4EntityContext : T4Context
    {
        public IEnumerable<SqlColumnSchemaEntity> Columns { get; set; }
    }
}