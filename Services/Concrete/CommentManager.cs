using AutoMapper;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using Services.Abstract;
using Shared.Utilities.Results.Abstract;
using Shared.Utilities.Results.ComplexTypes;
using Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class CommentManager : ICommentService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> Add(CommentAddDto commentAddDto)
        {
            var comment = _mapper.Map<Comment>(commentAddDto);
            await _unitOfWork.CommentRepository.AddAsync(comment);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, message: $"Yorum başarıyla eklenmiştir.");
        }

        public async Task<IResult> Delete(int commentId)
        {
            var result = await _unitOfWork.CommentRepository.AnyAsync(b => b.ID == commentId);
            if (result)
            {
                var comment = await _unitOfWork.CommentRepository.GetAsync(b => b.ID == commentId);
                comment.IsDeleted = true;
                await _unitOfWork.CommentRepository.UpdateAsync(comment);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Yorum başarıyla silinmiştir.");
            }
            return new Result(ResultStatus.Success, $"Silmek istediğiniz yorum bulunamamaktadır.");
        }

        public async Task<IDataResult<CommentDto>> Get(int commentId)
        {
            var comment = await _unitOfWork.CommentRepository.GetAsync(b => b.ID == commentId);
            if (comment is not null)
            {
                return new DataResult<CommentDto>(new CommentDto { Comment = comment, ResultStatus = ResultStatus.Success }, ResultStatus.Success);
            }
            return new DataResult<CommentDto>(new CommentDto { Comment = comment, ResultStatus = ResultStatus.Error, Message = "İlgili yorum bulunamadı" },
                ResultStatus.Error);
        }

        public async Task<IDataResult<CommentListDto>> GetAll()
        {
            var comments = await _unitOfWork.CommentRepository.GetAllAsync();
            if (comments.Count > 0)
            {
                return new DataResult<CommentListDto>(new CommentListDto { Comments = comments, ResultStatus = ResultStatus.Success }, ResultStatus.Success);
            }
            return new DataResult<CommentListDto>(new CommentListDto
            {
                Comments = comments,
                ResultStatus = ResultStatus.Error,
                Message = "Yorum bulunamadı"
            }, ResultStatus.Error);
        }

        public async Task<IDataResult<CommentListDto>> GetAllByNonDeleted()
        {
            var comments = await _unitOfWork.CommentRepository.GetAllAsync(c=>c.IsDeleted == false, c=>c.User);
            if (comments.Count > 0)
            {
                return new DataResult<CommentListDto>(new CommentListDto { Comments = comments, ResultStatus = ResultStatus.Success }, ResultStatus.Success);
            }
            return new DataResult<CommentListDto>(new CommentListDto
            {
                Comments = comments,
                ResultStatus = ResultStatus.Error,
                Message = "Silinmemiş yorum bulunamadı"
            }, ResultStatus.Error);
        }

        public async Task<IResult> HardDelete(int commentId)
        {
            var result = await _unitOfWork.CommentRepository.AnyAsync(b => b.ID == commentId);
            if (result)
            {
                var comment = await _unitOfWork.CommentRepository.GetAsync(b => b.ID == commentId);
                await _unitOfWork.CommentRepository.RemoveAsync(comment);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Yorum başarıyla veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Success, $"Silmek istediğiniz yorum bilgisi bulunamamaktadır.");
        }

        public async Task<IResult> Update(CommentUpdateDto commentUpdateDto)
        {
            var result = await _unitOfWork.CommentRepository.AnyAsync(b => b.ID == commentUpdateDto.ID);
            if (result)
            {
                var comment = _mapper.Map<Comment>(commentUpdateDto);
                await _unitOfWork.CommentRepository.UpdateAsync(comment);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, message: $"Yorum başarıyla güncellenmiştir.");
            }
            return new Result(ResultStatus.Success, message: $"Güncellemek istediğiniz yorum bulunamamaktadır.");
        }
    }
}
