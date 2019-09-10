/***************************************************
    IProcessor.cs

    Isaac Walker
****************************************************/

using System.Threading.Tasks;

namespace Shared.Message
{
    /// <summary>
    /// Message Processor interface
    /// </summary>
    /// <typeparam name="TReq"></typeparam>
    /// <typeparam name="TRes"></typeparam>
    public interface IProcessor <TReq, TRes>
        where TReq : Request
        where TRes : Response
    {
        /// <summary>
        /// Runs the processor
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        Task<TRes> Run(TReq Request);
    }
}
