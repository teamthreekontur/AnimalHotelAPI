using System;
using System.Net;

namespace AnimalHotelApi.Errors
{
    public static class ServiceErrorResponses
    {
        //public static ServiceErrorResponse PlaceNotFound(string noteId)
        //{
        //    if (noteId == null)
        //    {
        //        throw new ArgumentNullException(nameof(noteId));
        //    }
        //    return new ServiceErrorResponse()
        //    {
        //        StatusCode = HttpStatusCode.NotFound,
        //        Error = new ServiceError()
        //        {
        //            Code = ServiceErrorCodes.NotFound,
        //            Message = $"A note with \"{noteId}\" not found.",
        //            Target = "note"
        //        }
        //    };
        //}
        //public static ServiceErrorResponse BodyIsMissing(string target)
        //{
        //    return new ServiceErrorResponse()
        //    {
        //        StatusCode = HttpStatusCode.BadRequest,
        //        Error = new ServiceError()
        //        {
        //            Code = ServiceErrorCodes.BadRequest,
        //            Message = "Request body is empty.",
        //            Target = target
        //        }
        //    };
        //}
    }
}
