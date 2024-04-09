namespace HelpHub.Application.Models.Collaboration;

public class CollaborationModel
{
    private string? CollaborationId { get; set; }

    private string? UserId { get; set; }

    private string? EventId { get; set; }

    public CollaborationModel(
        string? collaborationId,
        string? userId,
        string? eventId)
    {
        CollaborationId = collaborationId;
        UserId = userId;
        EventId = eventId;
    }

    public static CollaborationModelBuilder Builder()
    {
        return new CollaborationModelBuilder();
    }

    public string? GetCollaborationId()
    {
        return CollaborationId;
    }

    public string? GetUserId()
    {
        return UserId;
    }

    public string? GetEventId()
    {
        return EventId;
    }
}