using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Comments;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetById(int id);
        Task<Comment> CreateComment(Comment comment);
        Task<Comment> UpdateComment(int id, Comment commentModel);
        Task<Comment> DeleteComment(int id);
    }
}