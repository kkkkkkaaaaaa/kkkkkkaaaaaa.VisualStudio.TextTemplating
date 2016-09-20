using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Controls;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects
{
    public class EventAsObservableContext : TextTemplatingContext
    {
        public IEnumerable<Type> Types { get; set; }

        public Type SenderType { get; set; }

        public string SenderName { get; set; }

        public IEnumerable<EventInfo> Events { get; set; }
    }
}