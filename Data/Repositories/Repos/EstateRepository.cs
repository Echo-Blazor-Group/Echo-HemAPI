﻿using AutoMapper;
using Echo_HemAPI.Data.Context;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Models.DTOs;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using System.Linq.Expressions;

namespace Echo_HemAPI.Data.Repositories.Repos
{

    //Author Gustaf
    public class EstateRepository : IEstateRepository
    {

        private readonly ApplicationDbContext _context;


        public EstateRepository(ApplicationDbContext context)
        {
            _context = context;
 
        }
        public async Task<Estate> AddAsync(Estate entity, Realtor realtor, Category category, County county)
        {
            await _context.Estates.AddAsync(entity);
            return entity;
        }
        public async Task<IEnumerable<Estate>?> GetAllAsync()
        {
            //calling the estate objects and includes the relational data, like counties and categories
            //aswell as realtors which also tags along the realtorfirm object, and lastly pictures
            var estate = await _context.Estates
                .Include(c => c.Category)
                .Include(c => c.County)
                .Include(r => r.Realtor.RealtorFirm) 
                .Include(p => p.Pictures) 
                .ToListAsync();
            if (estate is null)
            {
                return null;
            }
            else
            {
                return estate;
            }
        }
        public async Task<Estate?> GetByIdAsync(int id)
        {
            var estate = await _context.Estates
                .Include(c => c.Category)
                .Include(c => c.County)
                .Include(r => r.Realtor.RealtorFirm)
                .Include(r => r.Pictures)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (estate is null)
            {
                return null;
            }
            else
            {
                return estate;
            }
        }
    public async Task<IQueryable<Estate?>?> FindAsync(Expression<Func<Estate, bool>> predicate)
        {
            var entity = await _context.Estates.Where(predicate).ToListAsync();

            if (entity.Count == 0)
            {
                return null;
            }
            else
            {
                return (IQueryable<Estate>)entity;
            }
        }

        //Not actually ever used because we don't actually want to remove the data of estate objects.
        public async Task<Estate> RemoveAsync(Estate entity)
        {
            _context.Estates.Remove(entity);
            return entity;
        }
        public async Task<Estate> UpdateAsync(Estate entity)
        {
            _context.Estates.Update(entity);
            return entity;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
