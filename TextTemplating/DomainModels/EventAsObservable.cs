using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    /// <summary>
    /// Extensions。
    /// </summary>
    public class EventAsObservable : TextTemplatingDomainModel<EventAsObservableContext>
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        public EventAsObservable(EventAsObservableContext context) : base(context)
        {
            this.DoNothing();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public EventAsObservable TransformText()
        {
            Directory.CreateDirectory(this.Context.OutputPath);
            
            var types = new {};
            foreach (var type in this.Context.Types)
            {
                this.Context.SenderType = type;
                this.Context.TypeName = string.Format(@"{0}Extensions", type.Name);
                this.Context.Events = this.getEvents(type);
                this.Context.SenderName = @"sender";
                
                var template = new EventAsObservableTemplate(this.Context);
                var text = template.TransformText();

                var path = Path.Combine(this.Context.OutputPath, string.Format(@"{0}.cs", this.Context.TypeName));
                this.Flush(path, text, new UTF8Encoding(true, true));
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
            var events = type.GetEvents(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            return events;
        }

        #endregion
    }
}