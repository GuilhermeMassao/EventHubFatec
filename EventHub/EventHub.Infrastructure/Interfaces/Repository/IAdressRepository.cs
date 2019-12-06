﻿using EventHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Interfaces.Repository
{
    public interface IAdressRepository
    {
        Task<int?> CreateAdress(Adress entity);
        Task<bool> Delete(int id);
        Task<bool> InactivateAdress(int id);
    }
}
