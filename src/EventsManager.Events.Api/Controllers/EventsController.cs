﻿using System.Net.Mime;
using EventManager.Core.Models.Filters;
using EventManager.Core.Models.Requests;
using EventManager.Core.Models.Responses;
using EventsManager.Events.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventsManager.Events.Api.Controllers;

[ApiController]
[Route("api/events")]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponse<EmptyResponse>))]
[ProducesResponseType(StatusCodes.Status424FailedDependency, Type = typeof(BaseResponse<EmptyResponse>))]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    /// <summary>
    ///     Get event by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:required}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse<EventResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponse<EmptyResponse>))]
    public async Task<IActionResult> GetEventById([FromRoute] string id)
    {
        var response = await _eventService.GetEventById(id);
        return StatusCode(response.Code, response);
    }

    /// <summary>
    ///     Get events by filter
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse<PaginatedResponse<EventResponse>>))]
    public async Task<IActionResult> GetEvents([FromQuery] EventsFilter filter)
    {
        var response = await _eventService.GetEvents(filter);
        return StatusCode(response.Code, response);
    }

    /// <summary>
    ///     Delete event
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:required}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse<EmptyResponse>))]
    public async Task<IActionResult> DeleteEventById([FromRoute] string id)
    {
        var response = await _eventService.DeleteEventById(id);
        return StatusCode(response.Code, response);
    }

    /// <summary>
    ///     Create event
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BaseResponse<EventResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse<EventResponse>))]
    public async Task<IActionResult> CreateEvent([FromBody] CreateEventRequest request)
    {
        var response = await _eventService.CreateEvent(request);
        return StatusCode(response.Code, response);
    }

    /// <summary>
    ///     Add participant to event
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPatch("{id:required}/participant")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse<EventResponse>))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(BaseResponse<EmptyResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponse<EmptyResponse>))]
    public async Task<IActionResult> AddParticipantToEvent([FromRoute] string id,
        [FromBody] EventParticipantRequest request)
    {
        var response = await _eventService.AddParticipant(id, request);
        return StatusCode(response.Code, response);
    }

    /// <summary>
    ///     Remove participant from an event
    /// </summary>
    /// <param name="id"></param>
    /// <param name="username"></param>
    /// <returns></returns>
    [HttpDelete("{id:required}/participant/{username:required}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse<EventResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponse<EmptyResponse>))]
    public async Task<IActionResult> DeleteParticipantFromEvent([FromRoute] string id, [FromRoute] string username)
    {
        var response = await _eventService.RemoveParticipant(id, username);
        return StatusCode(response.Code, response);
    }
}