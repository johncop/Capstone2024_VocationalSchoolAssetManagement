namespace ASM.Core.Entities.Enum
{
    public enum RequestStatusCollection
    {
        Pending,
        Overdue,
        InProgress,
        Cancelled,
        Expired,
        Approved,
        Completed,
        Failed
    }

    public enum RequestDetailStatusCollection
    {
        Pending,
        Borrowed,
        Returned,
        Failed,
        Rejected
    }
}
