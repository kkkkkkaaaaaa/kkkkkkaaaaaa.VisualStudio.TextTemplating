using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    /// <summary>
    /// AsObservableExtensions。
    /// </summary>
    public class EventAsObservableExtensions : TextTemplatingDomainModel<EventAsObservableContext>
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        public EventAsObservableExtensions(EventAsObservableContext context) : base(context)
        {
            this.DoNothing();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public EventAsObservableExtensions CreateEventAsObservableExtensions()
        {
            Directory.CreateDirectory(this.Context.OutputPath);
            
            var types = new {};
            foreach (var type in this.Context.Types)
            {
                this.Context.DeclaredType = type;
                this.Context.TypeName = this.Context.TypeName.GetTypeName(this.Context.DeclaredType.Name);
                this.Context.Events = this.getEvents(type);
                
                var template = new EventAsObservableExtensionsTemplate(this.Context);
                var text = template.TransformText();

                var file = Path.Combine(this.Context.OutputPath, string.Format(@"{0}.cs", this.Context.TypeName));
                this.Flush(file, text, new UTF8Encoding(true, true));
            }

            return this;
        }

        #region Private members...
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private IEnumerable<EventInfo> getEvents(Type type)
        {
            var events = type.GetEvents(BindingFlags.Public
                | BindingFlags.Instance
                | BindingFlags.Static
                | BindingFlags.DeclaredOnly);

            return events;
        }

        #endregion
    }
}