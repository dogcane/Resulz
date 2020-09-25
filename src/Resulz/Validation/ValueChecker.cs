using System;
using System.Collections.Generic;
using System.Text;

namespace Resulz.Validation
{
    public struct ValueChecker<T>
    {
        #region Properties

        public T Value { get; }

        public OperationResult Result { get; }

        public string Context { get; }

        #endregion

        #region Ctor

        public ValueChecker(T value, OperationResult result, string context) : this()
        {
            Value = value;
            Result = result;
            Context = context;
        }

        #endregion

        #region Methods

        public static ValueChecker<T> For(T value, OperationResult result, string context) => new ValueChecker<T>(value, result, context);

        #endregion

        #region Operators

        public static implicit operator OperationResult(ValueChecker<T> checker) => checker.Result;

        #endregion
    }
}
