﻿using Nest;

namespace EventManager.Core.Domain.Events;

public class EventParticipant
{
    [Keyword] public string Username { get; set; }

    [Keyword] public string Email { get; set; }

    public string Name { get; set; }
    public string PhotoUrl { get; set; }
}