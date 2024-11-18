namespace ASM.Core.BindingModels.Notification
{
    public class UpdateNotificationBindingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
