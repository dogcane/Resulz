using System;
using System.Collections.Generic;
using System.Linq;

namespace Resulz
{
    /// <summary>
    /// Represents the basic generic result of an operation, with no returning value
    /// </summary>
    [Serializable]
    public class OperationResult : IOperationResult
    {
        #region Properties

        /// <summary>
        /// The success or not of the operation
        /// </summary> 
        public bool Success => !Errors.Any();

        /// <summary>
        /// Errors occurred during the execution of the operations
        /// </summary>
        public ErrorMessageList Errors { get; } = new ErrorMessageList();

        #endregion

        #region Ctor

        public OperationResult()
        {
        }

        public OperationResult(IEnumerable<ErrorMessage> errors)
        {
            Errors.AddRange(errors);
        }

        #endregion

        #region Methods

        public static OperationResult MakeSuccess() => new OperationResult();

        public static OperationResult MakeFailure(params ErrorMessage[] errors) => new OperationResult(errors);

        public static OperationResult MakeFailure(IEnumerable<ErrorMessage> errors) => new OperationResult(errors);

        public OperationResult AppendError(string context, string description) => AppendError(ErrorMessage.Create(context, description));

        public OperationResult AppendError(ErrorMessage error)
        {
            Errors.Add(error);
            return this;
        }

        public OperationResult AppendErrors(IEnumerable<ErrorMessage> errors)
        {
            Errors.AddRange(errors);
            return this;
        }

        public OperationResult AppendContextPrefix(string contextPrefix)
        {
            Errors.AppendContextPrefix(contextPrefix);
            return this;
        }

        public OperationResult TranslateContext(string oldContext, string newContext)
        {
            Errors.TranslateContext(oldContext, newContext);
            return this;
        }

        #endregion

        #region Operators

        public static bool operator true(OperationResult o) => o.Success;

        public static bool operator false(OperationResult o) => !o.Success;

        public static OperationResult operator &(OperationResult o1, OperationResult o2) =>
            (o1.Success && o2.Success) ?
                OperationResult.MakeSuccess() :
                OperationResult.MakeFailure(o1.Errors.Concat(o2.Errors));

        #endregion
    }
}
