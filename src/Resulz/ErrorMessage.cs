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
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        #endregion

        #region Methods

        public static ErrorMessage Create(string description) => Create(string.Empty, description);

        public static ErrorMessage Create(string context, string description) => new(context, description);

        internal ErrorMessage AppendContextPrefix(string contextPrefix)
        {
            ArgumentNullException.ThrowIfNull(contextPrefix, nameof(contextPrefix));
            Context = contextPrefix + Context;
            return this;
        }

        internal ErrorMessage TranslateContext(string newContext)
        {
            Context = newContext ?? throw new ArgumentNullException(nameof(newContext));
            return this;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (obj is ErrorMessage message)            
                return Equals(message);
            
            throw new ArgumentException("The object is not of ErrorMessage", nameof(obj));
        }

        public bool Equals(ErrorMessage other) => (string.Equals(Context,other.Context) && string.Equals(Description,other.Description));

        public override int GetHashCode() => HashCode.Combine(Context, Description);

        public override string ToString() => $"{Context} : {Description}";

        public static bool operator ==(ErrorMessage left, ErrorMessage right) => left.Equals(right);

        public static bool operator !=(ErrorMessage left, ErrorMessage right) => !(left == right);

        #endregion
    }
}
