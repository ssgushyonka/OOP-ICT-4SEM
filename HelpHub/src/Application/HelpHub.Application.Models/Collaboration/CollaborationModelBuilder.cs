namespace HelpHub.Application.Models.Collaboration;

public class CollaborationModelBuilder
{
    private string? _collaborationId;
    private string? _userId;
    private string? _eventId;

    public CollaborationModelBuilder CollaborationId(string? collaborationId)
    {
        _collaborationId = collaborationId;
        return this;
    }

    public CollaborationModelBuilder UserId(string? userId)
    {
        _userId = userId;
        return this;
    }

    public CollaborationModelBuilder EventId(string? eventId)
    {
        _eventId = eventId;
        return this;
    }

    public CollaborationModel Build()
    {
        return new CollaborationModel(_collaborationId, _userId, _eventId);
    }
}