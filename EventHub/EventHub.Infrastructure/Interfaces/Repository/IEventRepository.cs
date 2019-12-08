﻿using EventHub.Domain.DTOs.Event;
using EventHub.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Interfaces.Repository
{
    public interface IEventRepository
    {
        Task<int?> CreateEvent(Event entity);
        Task<bool> UpdateEvent(int id, Event entity);
        Task<bool> InactiveEvent(int id);
        Task<CompleteEventDto> GetById(int id);
        Task<IEnumerable<CompleteEventDto>> GetByUserId(int id);
        Task<IEnumerable<CompleteEventDto>> GetAllActiveEvents();
        Task<IEnumerable<EventDto>> GetEventsButUser(int id);
    }
}
