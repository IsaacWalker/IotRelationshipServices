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
        /// An empty response wehere success is ensured
        /// </summary>
        public static Response Empty = new EmptyResponse(true);


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


        /// <summary>
        /// Empty Response
        /// </summary>
        private class EmptyResponse : Response
        { 
            public EmptyResponse(bool Success) : base(Success)
            {

            }
        }

    }
}
