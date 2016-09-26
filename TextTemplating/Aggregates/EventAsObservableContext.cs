using System;
using System.Collections.Generic;
using System.Reflection;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates
{
    public class EventAsObservableContext  : ITextTemplatingAggregate
    {
        /// <summary>
        /// 
        /// </summary>
        public Namespace Namespace { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string[] Imports { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Type> Types { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type DeclaredType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TypeName TypeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<EventInfo> Events { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OutputPath { get; set; }
    }
}