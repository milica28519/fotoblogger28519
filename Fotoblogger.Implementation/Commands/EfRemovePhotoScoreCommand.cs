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
    public class EfRemovePhotoScoreCommand : IRemovePhotoScoreCommand
    {
        private readonly FotobloggerContext _context;
        private readonly ScorePhotoValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfRemovePhotoScoreCommand(FotobloggerContext context, ScorePhotoValidator validator, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 15;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(int photoId)
        {
            var pk = new int[] { photoId, _actor.Id };
            var userScore = _context.UserPhotoScores.Find(pk[0], pk[1]);

            if (userScore == null)
                throw new EntityNotFoundException(pk, typeof(UserPhotoScore));

            _context.UserPhotoScores.Remove(userScore);

            _context.SaveChanges();
        }
    }
}
