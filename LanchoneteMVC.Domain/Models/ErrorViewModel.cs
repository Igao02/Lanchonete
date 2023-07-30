namespace LanchoneteMVC.Models
{
    namespace LanchoneteMVC.Domain.Models
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}