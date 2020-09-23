using System;
using System.Collections.Generic;
using System.Linq;

namespace Resulz
{
    /// <summary>
    /// Represents the basic generic result of an operation, with a generic returning value
    /// </summary>
    [Serializable]
    public class OperationResult<T> : IOperationResult
    {
        #region Properties

        /// <summary>
        /// The success or not of the operation
        /// </summary> 
        public bool Success => !Errors.Any();

        /// <summary>
        /// Valore restituito dall'operazione
        /// </summary>
        public T Value { get; } = default(T);

        /// <summary>
        /// Errors occurred during the execution of the operations
        /// </summary>
        public ErrorMessageList Errors { get; } = new ErrorMessageList();

        #endregion

        #region Ctor

        public OperationResult(T value)
        {
            Value = value;
        }

        public OperationResult(IEnumerable<ErrorMessage> errors)
        {
            Errors.AddRange(errors);
        }

        #endregion

        #region Methods

        public static OperationResult<T> MakeSuccess(T value) => new OperationResult<T>(value);

        public static OperationResult<T> MakeFailure(params ErrorMessage[] errors) => new OperationResult<T>(errors);

        public static OperationResult<T> MakeFailure(IEnumerable<ErrorMessage> errors) => new OperationResult<T>(errors);

        public OperationResult<T> AppendError(string context, string description) => AppendError(ErrorMessage.Create(context, description));

        public OperationResult<T> AppendError(ErrorMessage error) => AppendErrors(new[] { error });

        public OperationResult<T> AppendErrors(IEnumerable<ErrorMessage> errors)
        {
            Errors.AddRange(errors);
            return this;
        }

        public OperationResult<T> AppendContextPrefix(string contextPrefix)
        {
            Errors.AppendContextPrefix(contextPrefix);
            return this;
        }

        public OperationResult<T> TranslateContext(string oldContext, string newContext)
        {
            Errors.TranslateContext(oldContext, newContext);
            return this;
        }

        #endregion

        #region Operators

        public static implicit operator OperationResult<T>(T value) => OperationResult<T>.MakeSuccess(value);

        public static implicit operator OperationResult<T>(OperationResult result)
        {
            if (result.Success)
                throw new ArgumentException();
            else
                return OperationResult<T>.MakeFailure(result.Errors);
        }

        public static implicit operator OperationResult(OperationResult<T> result) =>
            result.Success ?
                OperationResult.MakeSuccess() :
                OperationResult.MakeFailure(result.Errors);

        #endregion
    }
}
