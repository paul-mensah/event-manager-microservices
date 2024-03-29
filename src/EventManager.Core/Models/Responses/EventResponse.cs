﻿using EventManager.Core.Domain.Events;

namespace EventManager.Core.Models.Responses;

public class EventResponse
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string PhotoUrl { get; set; }
    public EventLocation Location { get; set; }
    public List<EventParticipant> Participants { get; set; } = new();
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
}