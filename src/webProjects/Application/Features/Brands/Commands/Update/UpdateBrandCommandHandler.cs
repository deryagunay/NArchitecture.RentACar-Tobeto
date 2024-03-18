using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Update
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        public UpdateBrandCommandHandler(IBrandRepository brandRepository,IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        async Task<UpdatedBrandResponse> IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>.Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brand = await _brandRepository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request, brand);
            Brand updatedBrand = await _brandRepository.UpdateAsync(brand);
            UpdatedBrandResponse response=_mapper.Map<UpdatedBrandResponse>(updatedBrand);
            return response;
        }
    }
}
