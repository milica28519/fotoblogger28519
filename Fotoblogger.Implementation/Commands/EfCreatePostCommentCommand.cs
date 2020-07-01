using AutoMapper;
using FluentValidation;
using Fotoblogger.Application;
using Fotoblogger.Application.Commands;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Domain.Entities;
using Fotoblogger.EfDataAccess;
using Fotoblogger.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Implementation.Commands
{
    public class EfCreatePostCommentCommand : ICreatePostCommentCommand
    {
        private readonly FotobloggerContext _context;
        private readonly CreatePostCommentValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfCreatePostCommentCommand(FotobloggerContext context, CreatePostCommentValidator validator, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 16;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(CreatePostCommentDto request)
        {
            _validator.ValidateAndThrow(request);

            _context.Comments.Add(_mapper.Map<Comment>(request));

            _context.SaveChanges(_actor.Id);
        }
    }
}
