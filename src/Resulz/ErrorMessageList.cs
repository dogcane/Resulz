using System;
using System.Collections.Generic;

namespace Resulz
{
    public class ErrorMessageList : List<ErrorMessage>
    {
        public void AppendContextPrefix(string contextPrefix)
        {
            for (int i = 0; i < this.Count; i++)
            {
                ErrorMessage error = this[i];
                this[i] = error.AppendContextPrefix(contextPrefix);
            }
        }

        public void TranslateContext(string oldContext, string newContext)
        {
            for (int i = 0; i < this.Count; i++)
            {
                ErrorMessage error = this[i];
                if (error.Context.Equals(oldContext, StringComparison.CurrentCultureIgnoreCase))
                {
                    this[i] = error.TranslateContext(newContext);
                }
            }
        }
    }
}
