/***************************************************
    Response.cs

    Isaac Walker
****************************************************/

namespace Web.Iot.Shared.Message
{
    /// <summary>
    /// An abstract message response
    /// </summary>
    public abstract class Response
    {
        /// <summary>
        /// Was the Response Successful
        /// </summary>
        public bool Success { get; private set; }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Success"></param>
        public Response(bool Success)
        {
            this.Success = Success;
        }
    }
}
