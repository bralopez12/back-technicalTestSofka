using System;

namespace back_technicalTest.Core.Exceptions
{
    /// <summary>
    /// Not Exist Idiom control Exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class NotExistIdiomException : Exception
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="NotExistIdiomException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public NotExistIdiomException(string message):base(message)
        {
            
        }
    }
}
