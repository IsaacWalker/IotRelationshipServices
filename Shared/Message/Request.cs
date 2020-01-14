/***************************************************
    Request.cs

    Isaac Walker
****************************************************/

namespace Web.Iot.Shared.Message
{
    /// <summary>
    /// Abstract Message Request
    /// </summary>
    public abstract class Request
    {
        /// <summary>
        /// An empty request with no parameters
        /// </summary>
        public static readonly Request Empty = new EmptyRequest();


        /// <summary>
        /// An empty Request
        /// </summary>
        private class EmptyRequest : Request 
        {
            
        }
    }
}
