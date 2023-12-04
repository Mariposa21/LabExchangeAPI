namespace LabExchangeAPI.Helpers.ErrorHandling
{
    public class LabApiResponseException : Exception
    {
        public LabApiResponseException(int statusCode, string? errorMessage = null) =>
            (StatusCode, ErrorMessage) = (statusCode, errorMessage);

        public int StatusCode { get; }

        public string? ErrorMessage { get; }
    }
}
