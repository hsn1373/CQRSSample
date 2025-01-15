﻿using Application.Repositories;
using Domain;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PropertyRepo : IPropertyRepo
    {
        private readonly ApplicationDbContext _context;

        public PropertyRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddNewAsync(Property property)
        {
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Property property)
        {
            throw new NotImplementedException();
        }

        public Task<List<Property>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Property> GetByIdAsync(int id)
        {
            return await _context.Properties
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Property property)
        {
            _context.Properties.Update(property);
            await _context.SaveChangesAsync();
        }
    }
}
