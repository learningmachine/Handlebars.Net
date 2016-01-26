using System;
using System.Collections.Generic;
using System.IO;
using HandlebarsDotNet.Compiler.Resolvers;
using HandlebarsDotNet.Compiler.Translation.Expression.Accessors;

namespace HandlebarsDotNet
{
    public class HandlebarsConfiguration
    {
        public IDictionary<string, HandlebarsHelper> Helpers { get; private set; }

        public IDictionary<string, HandlebarsBlockHelper> BlockHelpers { get; private set; }

        public IDictionary<string, Action<TextWriter, object>> RegisteredTemplates { get; private set; }

        public IExpressionNameResolver ExpressionNameResolver { get; set; }

        public ICollection<IMemberAccessor> MemberAccessors { get; private set; }

        public void AddDefaultMemberAccessors() {
            MemberAccessors.Add(new EnumerableMemberAccessor());
            MemberAccessors.Add(new DynamicMetaObjectProviderMemberAccessor());
            MemberAccessors.Add(new GenericDictionaryMemberAccessor());
            MemberAccessors.Add(new DictionaryMemberAccessor());
            MemberAccessors.Add(new ObjectMemberMemberAccessor());
        }

        public ViewEngineFileSystem FileSystem { get; set; }

        public HandlebarsConfiguration()
        {
            this.Helpers = new Dictionary<string, HandlebarsHelper>(StringComparer.OrdinalIgnoreCase);
            this.BlockHelpers = new Dictionary<string, HandlebarsBlockHelper>(StringComparer.OrdinalIgnoreCase);
            this.RegisteredTemplates = new Dictionary<string, Action<TextWriter, object>>(StringComparer.OrdinalIgnoreCase);
            this.MemberAccessors = new List<IMemberAccessor>();
            this.AddDefaultMemberAccessors();
        }
    }
}

