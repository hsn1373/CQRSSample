﻿using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Images.Commands
{
    public class CreateImageRequest : IRequest<bool>
    {
        public NewImageDto NewImageDto { get; set; }

        public CreateImageRequest(NewImageDto newImageDto)
        {
            NewImageDto = newImageDto;
        }
    }

    public class CreateImageRequestHandler : IRequestHandler<CreateImageRequest, bool>
    {
        private readonly IImageRepo _imageRepo;
        private readonly IMapper _mapper;

        public CreateImageRequestHandler(IImageRepo imageRepo, IMapper mapper)
        {
            _imageRepo = imageRepo;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateImageRequest request, CancellationToken cancellationToken)
        {
            Image image = _mapper.Map<Image>(request.NewImageDto);
            await _imageRepo.AddNewAsync(image);
            return true;
        }
    }
}
