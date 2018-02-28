﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;

using PhotoHub.DAL.Interfaces;
using PhotoHub.DAL.Data;
using PhotoHub.DAL.Entities;

namespace PhotoHub.DAL.Repositories
{
    public class LikesRepository : IRepository<Like>
    {
        private readonly ApplicationDbContext _context;

        public LikesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Like> GetAll(int page, int pageSize)
        {
            return _context.Likes.Include(l => l.Owner).Skip(page * pageSize).Take(pageSize);
        }
        public async Task<IEnumerable<Like>> GetAllAsync(int page, int pageSize)
        {
            return await _context.Likes.Include(l => l.Owner).Skip(page * pageSize).Take(pageSize).ToListAsync();
        }

        public Like Get(int id)
        {
            return _context.Likes.Include(l => l.Owner).Where(l => l.Id == id).FirstOrDefault();
        }
        public async Task<Like> GetAsync(int id)
        {
            return await _context.Likes.Include(l => l.Owner).Where(l => l.Id == id).FirstOrDefaultAsync();
        }

        public IEnumerable<Like> Find(Func<Like, bool> predicate)
        {
            return _context.Likes.Include(l => l.Owner).Where(predicate);
        }

        public void Create(Like item)
        {
            _context.Likes.Add(item);
        }
        public async Task CreateAsync(Like item)
        {
            await _context.Likes.AddAsync(item);
        }

        public void Update(Like item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Like like = _context.Likes.Find(id);
            if (like != null)
                _context.Likes.Remove(like);
        }
        public async Task DeleteAsync(int id)
        {
            Like like = await _context.Likes.FindAsync(id);
            if (like != null)
                _context.Likes.Remove(like);
        }
    }
}