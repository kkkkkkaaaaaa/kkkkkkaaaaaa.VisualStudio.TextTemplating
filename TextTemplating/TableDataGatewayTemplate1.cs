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
            
            #line 1 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n");
            
            #line 3 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
 foreach(var import in this.Context.Imports) { 
            
            #line default
            #line hidden
            this.Write("\tusing ");
            
            #line 4 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(import));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 5 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n    /// <summary>\r\n    /// ");
            
            #line 8 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.TableName));
            
            #line default
            #line hidden
            this.Write(" への TableDataGateway です。\r\n    /// </summary>\r\n\tinternal /* static */ class ");
            
            #line 10 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.TypeName));
            
            #line default
            #line hidden
            this.Write(" : ");
            
            #line 10 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Inherits));
            
            #line default
            #line hidden
            this.Write("\r\n\t{\r\n\t\tpublic static string TableName\r\n\t\t{\r\n\t\t\tget { return @\"");
            
            #line 14 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.TableName));
            
            #line default
            #line hidden
            this.Write("\"; }\r\n\t\t}\r\n\r\n\t\tpublic static EstelleDbDataReader Select(");
            
            #line 17 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.CurrentEntity.TypeName));
            
            #line default
            #line hidden
            this.Write(" criteria, DbConnection connection, DbTransaction transaction)\r\n\t\t{\r\n\t\t\tvar reade" +
                    "r = ");
            
            #line 19 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Inherits));
            
            #line default
            #line hidden
            this.Write(".Factory.CreateReader(connection, transaction);\r\n\t\r\n\t\t\tEstelleDbDataMapper.MapToP" +
                    "arameters(reader, criteria);\r\n\t\t\t\r\n\t\t\treader.CommandText = string.Format(@\"");
            this.Write("SELECT\r\n");
            
            #line 3 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewaySelectStatementTemplate.t4"

var i = 0;
foreach (var column in  this.Context.CurrentEntity.Columns) {
	if (i == 0) {
            
            #line default
            #line hidden
            this.Write("\t ");
            
            #line 7 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewaySelectStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.ColumnName));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 8 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewaySelectStatementTemplate.t4"
	} else { 
            
            #line default
            #line hidden
            this.Write("\t , ");
            
            #line 9 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewaySelectStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.ColumnName));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 10 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewaySelectStatementTemplate.t4"
	}
	i++;
} 
            
            #line default
            #line hidden
            this.Write("\r\nFROM\r\n\t");
            
            #line 15 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewaySelectStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.TableName));
            
            #line default
            #line hidden
            this.Write("\r\n\r\nWHERE 1 = 1\r\n");
            
            #line 18 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewaySelectStatementTemplate.t4"
 foreach (var column in  this.Context.CurrentEntity.Columns) { 
            
            #line default
            #line hidden
            this.Write("\t-- AND ");
            
            #line 19 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewaySelectStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.ColumnName));
            
            #line default
            #line hidden
            this.Write(" = @");
            
            #line 19 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewaySelectStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.ParameterName));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 20 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewaySelectStatementTemplate.t4"
 } 
            
            #line default
            #line hidden
            this.Write("\");\r\n\t\t\treader.ExecuteReader();\r\n\r\n\t\t\treturn reader;\r\n\t\t}\r\n\r\n\t\tpublic static int " +
                    "Insert(");
            
            #line 29 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.CurrentEntity.TypeName));
            
            #line default
            #line hidden
            this.Write(" criteria, DbConnection connection, DbTransaction transaction)\r\n\t\t{\r\n\t\t\tvar comma" +
                    "nd = ");
            
            #line 31 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Inherits));
            
            #line default
            #line hidden
            this.Write(".Factory.CreateCommand(connection, transaction);\r\n\r\n\t\t\tEstelleDbDataMapper.MapToP" +
                    "arameters(command, criteria);\r\n\t\t\t\r\n\t\t\tcommand.CommandText = string.Format(@\"");
            this.Write("INSERT INTO ");
            
            #line 2 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayInsertStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.TableName));
            
            #line default
            #line hidden
            this.Write(" (\r\n");
            
            #line 3 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayInsertStatementTemplate.t4"

var j = 0;
foreach (var column in this.Context.CurrentEntity.Columns) {
	if (j == 0) { 
            
            #line default
            #line hidden
            this.Write("\t ");
            
            #line 7 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayInsertStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.ColumnName));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 8 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayInsertStatementTemplate.t4"
	} else { 
            
            #line default
            #line hidden
            this.Write("\t , ");
            
            #line 9 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayInsertStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.ColumnName));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 10 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayInsertStatementTemplate.t4"
	}
	j++;
} 
            
            #line default
            #line hidden
            this.Write("\r\n) VALUES (\r\n");
            
            #line 15 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayInsertStatementTemplate.t4"

var k = 0;
foreach (var column in this.Context.CurrentEntity.Columns) {
	if (k == 0) { 
            
            #line default
            #line hidden
            this.Write("\t @");
            
            #line 19 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayInsertStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.ParameterName));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 20 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayInsertStatementTemplate.t4"
	} else { 
            
            #line default
            #line hidden
            this.Write("\t , @");
            
            #line 21 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayInsertStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.ParameterName));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 22 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayInsertStatementTemplate.t4"
	}
	k++;
} 
            
            #line default
            #line hidden
            this.Write(")\r\n");
            this.Write("\");\r\n\t\t\t\r\n\t\t\tvar affected = command.ExecuteNonQuery();\r\n\r\n\t\t\treturn affected;\r\n\t\t" +
                    "}\r\n\r\n\t\tpublic int Update(");
            
            #line 42 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.CurrentEntity.TypeName));
            
            #line default
            #line hidden
            this.Write(" criteria, DbConnection connection, DbTransaction transaction)\r\n\t\t{\r\n\t\t\tvar comma" +
                    "nd = ");
            
            #line 44 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Inherits));
            
            #line default
            #line hidden
            this.Write(".Factory.CreateCommand(connection, transaction);\r\n\r\n\t\t\tEstelleDbDataMapper.MapToP" +
                    "arameters(command, criteria);\r\n\t\t\t\r\n\t\t\tcommand.CommandText = string.Format(@\"");
            this.Write("UPDATE\r\n\t");
            
            #line 3 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayUpdateStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.TableName));
            
            #line default
            #line hidden
            this.Write("\r\n\r\nSET\r\n");
            
            #line 6 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayUpdateStatementTemplate.t4"

var l = 0;
foreach (var column in  this.Context.CurrentEntity.Columns) {
	if (0 < l) { 
            
            #line default
            #line hidden
            this.Write("\t");
            
            #line 10 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayUpdateStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.ColumnName));
            
            #line default
            #line hidden
            this.Write(" = @");
            
            #line 10 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayUpdateStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.ParameterName));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 11 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayUpdateStatementTemplate.t4"
	}
	l++;
} 
            
            #line default
            #line hidden
            this.Write("\r\nWHERE 1 <> 1 -- 実装時に 1 = 1 にする\r\n");
            
            #line 16 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayUpdateStatementTemplate.t4"
 foreach (var column in  this.Context.CurrentEntity.Columns) { 
            
            #line default
            #line hidden
            this.Write("\t-- AND ");
            
            #line 17 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayUpdateStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.ColumnName));
            
            #line default
            #line hidden
            this.Write(" = @");
            
            #line 17 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayUpdateStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.ParameterName));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 18 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayUpdateStatementTemplate.t4"
 } 
            
            #line default
            #line hidden
            this.Write("\");\r\n\t\t\t\r\n\t\t\tvar affected = command.ExecuteNonQuery();\r\n\r\n\t\t\treturn affected;\r\n\t\t" +
                    "}\r\n\r\n\t\t#region Internal members...\r\n\r\n\t\tinternal int Delete(");
            
            #line 57 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.CurrentEntity.TypeName));
            
            #line default
            #line hidden
            this.Write(" criteria, DbConnection connection, DbTransaction transaction)\r\n\t\t{\r\n\t\t\tvar comma" +
                    "nd = ");
            
            #line 59 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Inherits));
            
            #line default
            #line hidden
            this.Write(".Factory.CreateCommand(connection, transaction);\r\n\r\n\t\t\tEstelleDbDataMapper.MapToP" +
                    "arameters(command, criteria);\r\n\t\t\t\r\n\t\t\tcommand.CommandText = string.Format(@\"");
            this.Write("DELETE FROM\r\n\t");
            
            #line 3 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayDeleteStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.TableName));
            
            #line default
            #line hidden
            this.Write("\r\n    \r\nWHERE 1 <> 1 -- 実装時に 1 = 1\r\n");
            
            #line 6 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayDeleteStatementTemplate.t4"
 foreach (var column in  this.Context.CurrentEntity.Columns) { 
            
            #line default
            #line hidden
            this.Write("\t-- AND ");
            
            #line 7 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayDeleteStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.ColumnName));
            
            #line default
            #line hidden
            this.Write(" = @");
            
            #line 7 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayDeleteStatementTemplate.t4"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.ParameterName));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 8 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\t4\GatewayDeleteStatementTemplate.t4"
 } 
            
            #line default
            #line hidden
            this.Write("\");\r\n\t\t\t\r\n\t\t\tvar affected = command.ExecuteNonQuery();\r\n\r\n\t\t\treturn affected;\r\n\t\t" +
                    "}\r\n\r\n\t\tinternal static int Truncate(string table, DbConnection connection, DbTra" +
                    "nsaction transaction)\r\n\t\t{\r\n\t\t\tvar affected = ");
            
            #line 72 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.Inherits));
            
            #line default
            #line hidden
            this.Write(".TruncateTable(");
            
            #line 72 "C:\Projects\kkkkkkaaaaaa.VisualStudio.TextTemplating\TextTemplating\TableDataGatewayTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Context.TypeName));
            
            #line default
            #line hidden
            this.Write(".TableName, connection, transaction);\r\n\r\n\t\t\treturn affected;\r\n\t\t}\r\n\r\n\t\t#endregion" +
                    "\r\n\t}\r\n}\r\n");
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
