using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Comments;
using api.Models;

namespace api.Mappers
{
    public static class CommentMapper
    {
         public static CommentDto ToCommentDto(this Comment commentModel)
         {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Context = commentModel.Context,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId,
            };
         }
    }
}