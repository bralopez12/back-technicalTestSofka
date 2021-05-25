using back_technicalTest.Entities.Commons;

namespace back_technicalTest.Entites
{
    /// <summary>
    /// Greeter Request Dto
    /// </summary>
    public class GreeterRequest
    {
        /// <summary>
        /// Gets or sets the type of the idiom.
        /// </summary>
        /// <value>
        /// The type of the idiom.
        /// </value>
        public IdiomType IdiomType{ get; set; }
        /// <summary>
        /// Gets or sets the type of the responses.
        /// </summary>
        /// <value>
        /// The type of the responses.
        /// </value>
        public ResponseType ResponsesType{ get; set; }
    }
}
