using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resulz
{
    /// <summary>
    /// Represents the basic generic result of an operation, with no returning value
    /// </summary>
    [Serializable]
    public sealed class OperationResult : IOperationResult
    {
        #region Fields

        private readonly ErrorMessageList _Errors = new ErrorMessageList();

        #endregion

        #region Properties

        /// <summary>
        /// The success or not of the operation
        /// </summary> 
        public bool Success => !Errors.Any();

        /// <summary>
        /// Errors occurred during the execution of the operations
        /// </summary>
        public IEnumerable<ErrorMessage> Errors => _Errors;

        /// <summary>
        /// Additional information about the result (custom status code, description, etc..)
        /// </summary>
        public string AdditionalInfo { get; private set; } = string.Empty;

        #endregion

        #region Ctor

        public OperationResult()
        {
        }

        public OperationResult(IEnumerable<ErrorMessage> errors)
        {
            ArgumentNullException.ThrowIfNull(errors, nameof(errors));
            _Errors.AddRange(errors);
        }

        #endregion

        #region Methods

        public static OperationResult MakeSuccess() => new();

        public static OperationResult MakeFailure(ErrorMessage error) => new(new[] { error });

        public static OperationResult MakeFailure(IEnumerable<ErrorMessage> errors) => new(errors);

        public OperationResult AppendError(string context, string description) => AppendError(ErrorMessage.Create(context, description));

        public OperationResult AppendError(ErrorMessage error)
        {
            _Errors.Add(error);
            return this;
        }

        public OperationResult AppendErrors(IEnumerable<ErrorMessage> errors)
        {
            ArgumentNullException.ThrowIfNull(errors, nameof(errors));            
            _Errors.AddRange(errors);
            return this;
        }

        public OperationResult AppendContextPrefix(string contextPrefix)
        {
            ArgumentNullException.ThrowIfNull(contextPrefix, nameof(contextPrefix));
            _Errors.AppendContextPrefix(contextPrefix);
            return this;
        }

        public OperationResult TranslateContext(string oldContext, string newContext)
        {
            ArgumentNullException.ThrowIfNull(oldContext, nameof(oldContext));
            ArgumentNullException.ThrowIfNull(newContext, nameof(newContext));
            _Errors.TranslateContext(oldContext, newContext);
            return this;
        }

        public OperationResult SetAdditionalInfo(params string[] additionalInfo)
        {
            ArgumentNullException.ThrowIfNull(additionalInfo, nameof(additionalInfo));
            if (additionalInfo.Length == 1)
            {
                AdditionalInfo = additionalInfo[0];
            }
            else if (additionalInfo.Length > 1)
            {
                StringBuilder builder = new();
                foreach(string item in additionalInfo)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append('|');
                    }
                    builder.Append(item);
                }
                AdditionalInfo = builder.ToString();
            }            
            return this;
        }

        public override string ToString() => $"Succes:{Success} - Error Count:{Errors.Count()}";

        #endregion

        #region Operators

        public static bool operator true(OperationResult o) => o.Success;

        public static bool operator false(OperationResult o) => !o.Success;

        public static OperationResult operator &(OperationResult o1, OperationResult o2) =>
            ((o1.Success && o2.Success) ?
                OperationResult.MakeSuccess() :
                OperationResult.MakeFailure(o1.Errors.Concat(o2.Errors))).SetAdditionalInfo(o1.AdditionalInfo,o2.AdditionalInfo);

        #endregion
    }
}
