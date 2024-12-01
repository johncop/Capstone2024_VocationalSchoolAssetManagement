namespace ASM.Core.Entities.Enum
{
    public enum RequestStatusCollection
    {
        Pending,
        Rejected,
        Overdue,
        InProgress,
        Cancelled,
        Expired
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
