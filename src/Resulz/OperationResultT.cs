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

        private readonly ErrorMessageList _Errors = new();

        #endregion

        #region Properties

        /// <summary>
        /// The success or not of the operation
        /// </summary> 
        public bool Success => !Errors.Any();

        /// <summary>
        /// Valore restituito dall'operazione
        /// </summary>
        public T? Value { get; } = default;

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

        public OperationResult(T value) => Value = value;

        public OperationResult(IEnumerable<ErrorMessage> errors)
        {
            ArgumentNullException.ThrowIfNull(errors, nameof(errors));
            _Errors.AddRange(errors);
        }

        #endregion

        #region Methods

        public static OperationResult<T> MakeSuccess(T value) => new(value);

        public static OperationResult<T> MakeFailure(ErrorMessage error) => new(new[] { error });

        public static OperationResult<T> MakeFailure(IEnumerable<ErrorMessage> errors) => new(errors);

        public OperationResult<T> AppendError(string context, string description) => AppendError(ErrorMessage.Create(context, description));

        public OperationResult<T> AppendError(ErrorMessage error)
        {
            _Errors.Add(error);
            return this;
        }

        public OperationResult<T> AppendErrors(IEnumerable<ErrorMessage> errors)
        {
            ArgumentNullException.ThrowIfNull(errors, nameof(errors));
            _Errors.AddRange(errors);
            return this;
        }

        public OperationResult<T> AppendContextPrefix(string contextPrefix)
        {
            ArgumentNullException.ThrowIfNull(contextPrefix, nameof(contextPrefix));
            _Errors.AppendContextPrefix(contextPrefix);
            return this;
        }

        public OperationResult<T> TranslateContext(string oldContext, string newContext)
        {
            ArgumentNullException.ThrowIfNull(oldContext, nameof(oldContext));
            ArgumentNullException.ThrowIfNull(newContext, nameof(newContext));
            _Errors.TranslateContext(oldContext, newContext);
            return this;
        }

        public OperationResult<T> SetAdditionalInfo(params string[] additionalInfo)
        {
            ArgumentNullException.ThrowIfNull(additionalInfo, nameof(additionalInfo));
            if (additionalInfo.Length == 1)
            {
                AdditionalInfo = additionalInfo[0];
            }
            else if (additionalInfo.Length > 1)
            {
                StringBuilder builder = new();
                foreach (string item in additionalInfo)
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

        public static implicit operator OperationResult<T>(T value) => MakeSuccess(value);

        public static implicit operator OperationResult<T>(OperationResult result)
        {
            ArgumentNullException.ThrowIfNull(result, nameof(result));
            if (result.Success)
                throw new ArgumentException("The result must be a failure", nameof(result));            
            return MakeFailure(result.Errors).SetAdditionalInfo(result.AdditionalInfo);
        }

        public static implicit operator OperationResult(OperationResult<T> result)
        {
            ArgumentNullException.ThrowIfNull(result, nameof(result));
            return (result.Success?
                OperationResult.MakeSuccess() :
                OperationResult.MakeFailure(result.Errors)).SetAdditionalInfo(result.AdditionalInfo);
        }

        #endregion
    }
}
