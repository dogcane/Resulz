using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resulz
{
    /// <summary>
    /// Represents the basic generic result of an operation, with a generic returning value
    /// </summary>
    [Serializable]
    public sealed class OperationResult<T> : IOperationResult
    {
        #region Fields

        private ErrorMessageList _Errors = new ErrorMessageList();

        #endregion

        #region Properties

        /// <summary>
        /// The success or not of the operation
        /// </summary> 
        public bool Success => !Errors.Any();

        /// <summary>
        /// Valore restituito dall'operazione
        /// </summary>
        public T Value { get; } = default;

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

        public OperationResult(T value)
        {
            Value = value;
        }

        public OperationResult(IEnumerable<ErrorMessage> errors)
        {
            if (errors == null) throw new ArgumentNullException(nameof(errors));
            _Errors.AddRange(errors);
        }

        #endregion

        #region Methods

        public static OperationResult<T> MakeSuccess(T value) => new OperationResult<T>(value);

        public static OperationResult<T> MakeFailure(ErrorMessage error) => new OperationResult<T>(new[] { error });

        public static OperationResult<T> MakeFailure(IEnumerable<ErrorMessage> errors) => new OperationResult<T>(errors);

        public OperationResult<T> AppendError(string context, string description) => AppendError(ErrorMessage.Create(context, description));

        public OperationResult<T> AppendError(ErrorMessage error)
        {
            _Errors.Add(error);
            return this;
        }

        public OperationResult<T> AppendErrors(IEnumerable<ErrorMessage> errors)
        {
            if (errors == null) throw new ArgumentNullException(nameof(errors));
            _Errors.AddRange(errors);
            return this;
        }

        public OperationResult<T> AppendContextPrefix(string contextPrefix)
        {
            if (contextPrefix == null) throw new ArgumentNullException(nameof(contextPrefix));
            _Errors.AppendContextPrefix(contextPrefix);
            return this;
        }

        public OperationResult<T> TranslateContext(string oldContext, string newContext)
        {
            if (oldContext == null) throw new ArgumentNullException(nameof(oldContext));
            if (newContext == null) throw new ArgumentNullException(nameof(newContext));
            _Errors.TranslateContext(oldContext, newContext);
            return this;
        }

        public OperationResult<T> SetAdditionalInfo(params string[] additionalInfo)
        {
            if (additionalInfo == null) throw new ArgumentNullException(nameof(additionalInfo));
            if (additionalInfo.Length == 1)
            {
                AdditionalInfo = additionalInfo[0];
            }
            else if (additionalInfo.Length > 1)
            {
                StringBuilder builder = new StringBuilder();
                foreach (string item in additionalInfo)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append("|");
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

        public static implicit operator OperationResult<T>(T value) => MakeSuccess(value);

        public static implicit operator OperationResult<T>(OperationResult result)
        {
            if (result == null)
                return null;
            if (result.Success)
                throw new ArgumentException();
            
            return MakeFailure(result.Errors).SetAdditionalInfo(result.AdditionalInfo);
        }

        public static implicit operator OperationResult(OperationResult<T> result) {
            if (result == null) return null;

            return (result.Success?
                OperationResult.MakeSuccess() :
                OperationResult.MakeFailure(result.Errors)).SetAdditionalInfo(result.AdditionalInfo);
        }

        #endregion
    }
}
