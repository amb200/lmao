using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1
{
    public class IssueDto
    {
        public int EventId { get; set; }
        public DateTime Timestamp { get; set; }
        public string TenantId { get; set; }
        public string MetricType { get; set; }
        public double MetricValue { get; set; }
        public string JsonField { get; set; }
    }
}
