using Entity.Concrete;
using Entity.Concrete.DTOs;
using Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ICommentService
    {
        public Task<IDataResult<CommentDto>> Get(int commentId);
        public Task<IDataResult<CommentListDto>> GetAll();
        public Task<IDataResult<CommentListDto>> GetAllByNonDeleted();
        public Task<IResult> Add(CommentAddDto commentAddDto);
        public Task<IResult> AddNotDto(Comment comment);
        public Task<IResult> Update(CommentUpdateDto commentUpdateDto);
        public Task<IResult> UpdateNotDto(Comment comment);
        public Task<IResult> Delete(int commentId);
        public Task<IResult> HardDelete(int commentId);
    }
}
