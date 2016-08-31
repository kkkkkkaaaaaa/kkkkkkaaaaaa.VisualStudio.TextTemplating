using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    public class EventAsObservable : TextTemplatingDomainModel<EventAsObservableContext>
    {
        public EventAsObservable(EventAsObservableContext context) : base(context)
        {
            this.DoNothing();
        }

        public EventAsObservable TransformText()
        {
            Directory.CreateDirectory(this.Context.OutputPath);

            foreach (var type in this.Context.Types)
            {
                this.Context.SenderType = type;
                this.Context.TypeName = $@"{type.Name}Extensions";
                this.Context.Events = this.getEvents(type);
                this.Context.SenderName = @"sender";

                var template = new EventAsObservableTemplate(this.Context);
                var text = template.TransformText();

                var path = Path.Combine(this.Context.OutputPath, $@"{this.Context.TypeName}.cs");
                this.Flush(path, text, new UTF8Encoding(true, true));
            }

            return this;
        }

        private IEnumerable<EventInfo> getEvents(Type type)
        {
            var events = type.GetEvents(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            // var events = type.GetEvents(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);

            return events;
        }
    }
}