using Resulz.Utils;
using System;

namespace Resulz
{
    public struct ErrorMessage : IEquatable<ErrorMessage>
    {
        #region Properties

        public string Context { get; private set; }

        public string Description { get; private set; }

        #endregion

        #region Ctor

        private ErrorMessage(string context, string description)
            : this()
        {
            Context = context;
            Description = description;
        }

        #endregion

        #region Methods

        public static ErrorMessage Create(string description) => Create(string.Empty, description);

        public static ErrorMessage Create(string context, string description) => new ErrorMessage(context, description);

        internal ErrorMessage AppendContextPrefix(string contextPrefix)
        {
            Context = contextPrefix + Context;
            return this;
        }

        internal ErrorMessage TranslateContext(string newContext)
        {
            Context = newContext;
            return this;
        }

        public override bool Equals(object obj)
        {
            if (obj is ErrorMessage message)
            {
                return Equals(message);
            }
            throw new ArgumentException();
        }

        public bool Equals(ErrorMessage other) => (Context == other.Context && Description == other.Description);

        public override int GetHashCode() => HashCode.Combine(Context, Description);

        public override string ToString() => $"{Context} : {Description}";

        #endregion
    }
}
