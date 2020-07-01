using AutoMapper;
using FluentValidation;
using Fotoblogger.Application;
using Fotoblogger.Application.Commands;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Application.Exceptions;
using Fotoblogger.Domain.Entities;
using Fotoblogger.EfDataAccess;
using Fotoblogger.Implementation.Validators;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Commands
{
    public class EfScorePhotoCommand : IScorePhotoCommand
    {
        private readonly FotobloggerContext _context;
        private readonly ScorePhotoValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfScorePhotoCommand(FotobloggerContext context, ScorePhotoValidator validator, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 14;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(ScorePhotoDto request)
        {
            _validator.ValidateAndThrow(request);

            if(_context.Photos.Find(request.PhotoId) == null)
                throw new EntityNotFoundException(request.PhotoId, typeof(Photo));

            if (_context.UserPhotoScores.Any(s => s.PhotoId == request.PhotoId && s.UserId == _actor.Id))
                throw new ActionNotRepeatableException(UseCase.getUseCase(this.Id), _actor);

            var userPhotoScore = _mapper.Map<UserPhotoScore>(request);

            userPhotoScore.UserId = _actor.Id;

            _context.UserPhotoScores.Add(userPhotoScore);

            _context.SaveChanges();
        }
    }
}
