using System;
using System.Collections;
using System.Collections.Generic;

namespace Resulz
{
    internal sealed class ErrorMessageList : IEnumerable<ErrorMessage>
    {
        #region Fields

        private readonly List<ErrorMessage> _InnerList = new();

        #endregion

        #region Methods

        public void Add(ErrorMessage error) => _InnerList.Add(error);

        public void AddRange(IEnumerable<ErrorMessage> errorLists) => _InnerList.AddRange(errorLists);

        public void AppendContextPrefix(string contextPrefix)
        {
            for (int i = 0; i < _InnerList.Count; i++)
            {
                ErrorMessage error = _InnerList[i];
                _InnerList[i] = error.AppendContextPrefix(contextPrefix);
            }
        }

        public void TranslateContext(string oldContext, string newContext)
        {
            for (int i = 0; i < _InnerList.Count; i++)
            {
                ErrorMessage error = _InnerList[i];
                if (error.Context.Equals(oldContext, StringComparison.CurrentCultureIgnoreCase))
                {
                    _InnerList[i] = error.TranslateContext(newContext);
                }
            }
        }

        public IEnumerator<ErrorMessage> GetEnumerator() => _InnerList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _InnerList.GetEnumerator();

        #endregion
    }
}
