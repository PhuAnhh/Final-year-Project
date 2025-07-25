﻿using Final_year_Project.Domain.Entities;
using Final_year_Project.Application.Models;
using Final_year_Project.Application.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Final_year_Project.Application.Services.Abstractions
{
    public interface IComputerService
    {
        Task<IEnumerable<ComputerDto>> GetAllAsync();
        Task<ComputerDto> GetByIdAsync(int id);
        Task<ComputerDto> CreateAsync(CreateComputerDto createComputerDto);
        Task<ComputerDto> UpdateAsync(int id, UpdateComputerDto updateComputerDto);
        Task<bool> DeleteAsync(int id, bool useSoftDelete);
        Task<bool> ChangeStatusAsync(int id, bool status);
    }
}
