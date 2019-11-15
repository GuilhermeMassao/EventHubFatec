﻿using EventHub.Domain;
using EventHub.Infraestructure.Interfaces.Repository;

namespace EventHub.Infrastructure.Interfaces.Repository
{
    public interface IPublicPlaceRepository : IRepository<PublicPlace>
    {
    }
}