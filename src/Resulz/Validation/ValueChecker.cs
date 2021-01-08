using System;
using System.Collections.Generic;
using System.Text;

namespace Resulz.Validation
{
    public class ValueChecker<T>
    {
        #region Properties

        public T Value { get; private set; }

        public OperationResult Result { get; private set; }

        public string Context { get; private set; }

        public bool ContinueOnError { get; private set; }

        #endregion

        #region Ctor

        public ValueChecker(T value, OperationResult result, string context)
        {
            Value = value;
            Result = result;
            Context = context;
            ContinueOnError = true;
        }

        #endregion

        #region Methods

        //public static ValueChecker<T> For(T value, OperationResult result, string context) => new ValueChecker<T>(value, result, context);

        public ValueChecker<T> StopOnError()
        {
            ContinueOnError = false;
            return this;
        }

        public bool CanContinue()
        {
            return ContinueOnError || Result.Success;
        }

        #endregion

        #region Operators

        public static implicit operator OperationResult(ValueChecker<T> checker) => checker.Result;

        #endregion
    }
}
