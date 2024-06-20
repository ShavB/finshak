using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository(ApplicationDBContext applicationDBContext) : ICommentRepository
    {
        private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;
        public async Task<List<Comment>> GetAllAsync()
        {
            return await _applicationDBContext.Comments.ToListAsync();
        }

        public async Task<Comment?> GetById(int id)
        {
            return await _applicationDBContext.Comments.FindAsync(id);
        }
    }
}