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
        public Task<IDataResult<Comment>> Get(int commentId);
        public Task<IDataResult<IList<Comment>>> GetAll();
        public Task<IDataResult<IList<Comment>>> GetAllByNonDeleted();
        public Task<IResult> Add(CommentAddDto commentAddDto);
        public Task<IResult> Update(CommentUpdateDto commentUpdateDto);
        public Task<IResult> Delete(int commentId);
        public Task<IResult> HardDelete(int commentId);
    }
}
