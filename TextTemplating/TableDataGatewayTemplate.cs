﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン: 14.0.0.0
//  
//     このファイルへの変更は、正しくない動作の原因になる可能性があり、
//     コードが再生成されると失われます。
// </auto-generated>
// ------------------------------------------------------------------------------
namespace kkkkkkaaaaaa.VisualStudio.TextTemplating
{
    using System.Linq;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class TableDataGatewayTemplate : TableDataGatewayTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("namespace ");
            
            #line 2 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n");
            
            #line 4 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
 foreach(var import in this.Context.Imports) { 
            
            #line default
            #line hidden
            this.Write("\tusing ");
            
            #line 5 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(import));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 6 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("    /// <summary>\r\n    /// ");
            
            #line 8 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.TableName));
            
            #line default
            #line hidden
            this.Write(" への TableDataGateway です。\r\n    /// </summary>\r\n\tinternal static class ");
            
            #line 10 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.TypeName));
            
            #line default
            #line hidden
            this.Write(" : ");
            
            #line 10 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Inherits));
            
            #line default
            #line hidden
            this.Write("\r\n\t{\r\n\r\n\t\tpublic string TableName\r\n\t\t{\r\n\t\t\tget { return @\"");
            
            #line 15 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.TableName));
            
            #line default
            #line hidden
            this.Write("\"; }\r\n\t\t}\r\n\r\n\t\tpublic static KandaDbDataReader Select(");
            
            #line 18 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Entity.TypeName));
            
            #line default
            #line hidden
            this.Write(" criteria, DbConnection connection, DbTransaction transaction)\r\n\t\t{\r\n\t\t\tvar reade" +
                    "r = ");
            
            #line 20 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Inherits));
            
            #line default
            #line hidden
            this.Write(".CreateDataReader(connection, transaction);\r\n\t\r\n\t\t\tKandaDbDataMapper.MapToParamet" +
                    "ers(reader.Parameters, criteria);\r\n\r\n\t\t\treader.CommandText = string.Format(@\"SEL" +
                    "ECT\r\n\t*\r\nFROM\r\n\t");
            
            #line 27 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.TableName));
            
            #line default
            #line hidden
            this.Write("\r\nWHERE 1 = 1\r\n\tAND ");
            
            #line 29 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Columns.First().ColumnName));
            
            #line default
            #line hidden
            this.Write(" = {0}\r\nORDER BY\r\n\t");
            
            #line 31 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Columns.First().ColumnName));
            
            #line default
            #line hidden
            this.Write(" ASC\", criteria.");
            
            #line 31 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Columns.First().ColumnName));
            
            #line default
            #line hidden
            this.Write(");\r\n\r\n\t\t\treader.ExecuteReader();\r\n\r\n\t\t\treturn reader;\r\n\t\t}\r\n\r\n\t\tpublic static int" +
                    " Insert(");
            
            #line 38 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Entity.TypeName));
            
            #line default
            #line hidden
            this.Write(" criteria, DbConnection connection, DbTransaction transaction)\r\n\t\t{\r\n\t\t\tvar comma" +
                    "nd = ");
            
            #line 40 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Inherits));
            
            #line default
            #line hidden
            this.Write(".CreateCommand(connection, transaction);\r\n\r\n\t\t\tKandaDbDataMapper.MapToParameters(" +
                    "command.Parameters, criteria);\r\n\t\t\t\r\n\t\t\tcommand.CommandText = string.Format(@\"IN" +
                    "SERT INTO ");
            
            #line 44 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.TableName));
            
            #line default
            #line hidden
            this.Write(" (\r\n) values (\r\n, criteria.");
            
            #line 46 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Columns.First().ColumnName));
            
            #line default
            #line hidden
            this.Write(");\r\n\t\t\t\r\n\t\t\tvar affected = command.ExecuteNonQuery();\r\n\r\n\t\t\treturn affected;\r\n\t\t}" +
                    "\r\n\r\n\t\tpublic int Update(");
            
            #line 53 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Entity.TypeName));
            
            #line default
            #line hidden
            this.Write(" criteria, DbConnection connection, DbTransaction transaction)\r\n\t\t{\r\n\t\t\tvar comma" +
                    "nd = ");
            
            #line 55 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Inherits));
            
            #line default
            #line hidden
            this.Write(".CreateCommand(connection, transaction);\r\n\r\n\t\t\tKandaDbDataMapper.MapToParameters(" +
                    "command.Parameters, criteria);\r\n\t\t\t\r\n\t\t\tcommand.CommandText = string.Format(@\"UP" +
                    "DATE SET \r\nWHERE 1 = 1\r\n, criteria.");
            
            #line 61 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Columns.First().ColumnName));
            
            #line default
            #line hidden
            this.Write(");\r\n\t\t\t\r\n\t\t\tvar affected = command.ExecuteNonQuery();\r\n\r\n\t\t\treturn affected;\r\n\t\t}" +
                    "\r\n\r\n\t\t#region Internal members...\r\n\r\n\t\tinternal int Delete(");
            
            #line 70 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Entity.TypeName));
            
            #line default
            #line hidden
            this.Write(" criteria, DbConnection connection, DbTransaction transaction)\r\n\t\t{\r\n\t\t\tvar comma" +
                    "nd = ");
            
            #line 72 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Inherits));
            
            #line default
            #line hidden
            this.Write(".CreateCommand(connection, transaction);\r\n\r\n\t\t\tKandaDbDataMapper.MapToParameters(" +
                    "command.Parameters, criteria);\r\n\t\t\t\r\n\t\t\tcommand.CommandText = string.Format(@\"DE" +
                    "LETE\r\nWHERE 1 = 1\"\r\n, criteria.");
            
            #line 78 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Columns.First().ColumnName));
            
            #line default
            #line hidden
            this.Write(");\r\n\t\t\t\r\n\t\t\tvar affected = command.ExecuteNonQuery();\r\n\r\n\t\t\treturn affected;\r\n\t\t}" +
                    "\r\n\r\n\t\tinternal static int Truncate()\r\n\t\t{\r\n\t\t\treturn ");
            
            #line 87 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Inherits));
            
            #line default
            #line hidden
            this.Write(".Truncate(");
            
            #line 87 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.TableName));
            
            #line default
            #line hidden
            this.Write(");\r\n\t\t}\r\n\r\n\t\t#endregion\r\n\t}\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public class TableDataGatewayTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
