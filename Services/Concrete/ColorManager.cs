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
    public class ColorManager : IColorService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColorManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> Add(ColorAddDto colorAddDto)
        {
            var color = _mapper.Map<Color>(colorAddDto);
            await _unitOfWork.ColorRepository.AddAsync(color);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, message: $"{color.Name} adlı renk başarıyla eklenmiştir.");
        }

        public async Task<IResult> Delete(int colorId)
        {
            var result = await _unitOfWork.ColorRepository.AnyAsync(b => b.ID == colorId);
            if (result)
            {
                var color = await _unitOfWork.ColorRepository.GetAsync(b => b.ID == colorId);
                color.IsDeleted = true;
                await _unitOfWork.ColorRepository.UpdateAsync(color);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{color.Name} renk başarıyla silinmiştir.");
            }
            return new Result(ResultStatus.Success, $"Silmek istediğiniz renk bilgisi bulunamamaktadır.");
        }

        public async Task<IDataResult<ColorDto>> Get(int colorId)
        {
            var color = await _unitOfWork.ColorRepository.GetAsync(b => b.ID == colorId);
            if (color is not null)
            {
                return new DataResult<ColorDto>(new ColorDto { Color = color, ResultStatus = ResultStatus.Success }, ResultStatus.Success);
            }
            return new DataResult<ColorDto>(new ColorDto { Color = color, ResultStatus = ResultStatus.Error, Message = "İlgili renk bulunamadı" },
                ResultStatus.Error);
        }

        public async Task<IDataResult<ColorListDto>> GetAll()
        {
            var colors = await _unitOfWork.ColorRepository.GetAllAsync();
            if (colors.Count > 0)
            {
                return new DataResult<ColorListDto>(new ColorListDto { Colors = colors, ResultStatus = ResultStatus.Success }, ResultStatus.Success);
            }
            return new DataResult<ColorListDto>(new ColorListDto
            {
                Colors = colors,
                ResultStatus = ResultStatus.Error,
                Message = "Renk bulunamadı"
            }, ResultStatus.Error);
        }

        public async Task<IDataResult<ColorListDto>> GetAllByNonDeleted()
        {
            var colors = await _unitOfWork.ColorRepository.GetAllAsync(c=>c.IsDeleted == false);
            if (colors.Count > 0)
            {
                return new DataResult<ColorListDto>(new ColorListDto { Colors = colors, ResultStatus = ResultStatus.Success }, ResultStatus.Success);
            }
            return new DataResult<ColorListDto>(new ColorListDto
            {
                Colors = colors,
                ResultStatus = ResultStatus.Error,
                Message = "Silinmemiş renk bulunamadı"
            }, ResultStatus.Error);
        }

        public async Task<IResult> HardDelete(int colorId)
        {
            var result = await _unitOfWork.ColorRepository.AnyAsync(b => b.ID == colorId);
            if (result)
            {
                var color = await _unitOfWork.ColorRepository.GetAsync(b => b.ID == colorId);
                await _unitOfWork.ColorRepository.RemoveAsync(color);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{color.Name} adlı renk başarıyla veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Success, $"Silmek istediğiniz renk bilgisi bulunamamaktadır.");
        }

        public async Task<IResult> Update(ColorUpdateDto colorUpdateDto)
        {
            var result = await _unitOfWork.ColorRepository.AnyAsync(b => b.ID == colorUpdateDto.ID);
            if (result)
            {
                var color = _mapper.Map<Color>(colorUpdateDto);
                await _unitOfWork.ColorRepository.UpdateAsync(color);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, message: $"{color.Name} adlı renk başarıyla güncellenmiştir.");
            }
            return new Result(ResultStatus.Success, message: $"Güncellemek istediğiniz renk bulunamamaktadır.");
        }
    }
}
