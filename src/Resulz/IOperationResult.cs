using System.Collections.Generic;

namespace Resulz
{
    /// <summary>
    /// Represents a generic result of an operation
    /// </summary>
    public interface IOperationResult
    {
        /// <summary>
        /// The success or not of the operation
        /// </summary> 
        bool Success { get; }

        /// <summary>
        /// Errors occurred during the execution of the operations
        /// </summary>
        IEnumerable<ErrorMessage> Errors { get; }
    }
}