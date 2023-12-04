using System; 

namespace LabExchangeAPI.LogicLayer.Models
{
    public class LabApiErrorResponse
    {
        public DateTime ErrorDateTimeUtc { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
