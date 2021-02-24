using System;

namespace SalesStatistics.Models
{
    public class Error
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
