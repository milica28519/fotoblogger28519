using AutoMapper;
using FluentValidation;
using Fotoblogger.Application;
using Fotoblogger.Application.Commands;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Domain.Entities;
using Fotoblogger.EfDataAccess;
using Fotoblogger.Implementation.Validators;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Commands
{
    public class EfCreatePostCommand : ICreatePostCommand
    {
        private readonly FotobloggerContext _context;
        private readonly CreatePostValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfCreatePostCommand(FotobloggerContext context, CreatePostValidator validator, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 2;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(CreatePostDto request)
        {
            _validator.ValidateAndThrow(request); // ValidationException

            var newFileName = Guid.NewGuid() + Path.GetExtension(request.Photo.FileName);

            using (Image image = Image.Load(request.Photo.OpenReadStream()))
            {
                image.Save(Path.Combine("wwwroot", Photo.PhotoFolderPath, newFileName));

                image.Mutate(x => x.Resize(250, 250));
                image.Save(Path.Combine("wwwroot", Photo.ThumbnailPhotoFolderPath, newFileName));
            }

            var photo = new Photo
            {
                Caption = request.PhotoCaption,
                FileName = newFileName
            };

            _context.Photos.Add(photo);

            var post = new Post
            {
                Title = request.Title,
                Text = request.Text,
                Photo = photo
            };

            _context.Posts.Add(post);

            _context.SaveChanges(_actor.Id);
        }
    }
}
