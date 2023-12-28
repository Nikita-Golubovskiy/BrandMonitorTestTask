using System;

// ReSharper disable UnusedMember.Global

namespace PresentationLayer.BrandMonitorTestTask.Cqrs.Exceptions;

/// <summary>
/// CQRS exception class.
/// </summary>
public sealed class CqrsException : Exception
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public CqrsException()
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public CqrsException(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="inner">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public CqrsException(string message, Exception inner) : base(message, inner)
    {
    }
}