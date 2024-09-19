using Microsoft.AspNetCore.Mvc;

namespace SchoolMate.Dto.ApiReponse
{
    public class APIResponse
    {
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the HTTP status code of the response.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the data returned in the response.
        /// </summary>
        public object DataResponse { get; set; }

        /// <summary>
        /// Creates a success response with status code 200.
        /// </summary>
        /// <param name="data">Optional data to include in the response.</param>
        /// <param name="message">Optional message to include in the response.</param>
        /// <returns>An IActionResult representing the success response.</returns>
        public static IActionResult Success(object data = null, string message = "")
        {
            var response = new APIResponse
            {
                Message = message,
                StatusCode = 200,
                DataResponse = data
            };
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        /// <summary>
        /// Creates a request error response with status code 400.
        /// </summary>
        /// <param name="data">Optional data to include in the response.</param>
        /// <param name="message">Optional message to include in the response.</param>
        /// <returns>An IActionResult representing the request error response.</returns>
        public static IActionResult RequestError(object data = null, string message = "")
        {
            var response = new APIResponse
            {
                Message = message,
                StatusCode = 400,
                DataResponse = data
            };
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        /// <summary>
        /// Creates an error response with status code 500.
        /// </summary>
        /// <param name="data">Optional data to include in the response.</param>
        /// <param name="message">Optional message to include in the response.</param>
        /// <returns>An IActionResult representing the error response.</returns>
        public static IActionResult Error(object data = null, string message = "")
        {
            var response = new APIResponse
            {
                Message = message,
                StatusCode = 500,
                DataResponse = data
            };
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        /// <summary>
        /// Creates a custom response with a specified status code.
        /// </summary>
        /// <param name="data">Optional data to include in the response.</param>
        /// <param name="message">Optional message to include in the response.</param>
        /// <param name="statusCode">The HTTP status code to use in the response.</param>
        /// <returns>An IActionResult representing the custom response.</returns>
        public static IActionResult Custom(int statusCode = 200, object data = null, string message = "")
        {
            var response = new APIResponse
            {
                Message = message,
                StatusCode = statusCode,
                DataResponse = data
            };
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
