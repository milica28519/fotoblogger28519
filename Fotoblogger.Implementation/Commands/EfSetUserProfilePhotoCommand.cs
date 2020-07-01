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
using System.IO;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Commands
{
    public class EfSetUserProfilePhotoCommand : ISetUserProfilePhotoCommand
    {
        private readonly FotobloggerContext _context;
        private readonly SetUserProfilePhotoValidator _validator;
        private readonly IApplicationActor _actor;

        public EfSetUserProfilePhotoCommand(FotobloggerContext context, SetUserProfilePhotoValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 25;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(SetUserProfilePhotoDto request)
        {
            var user = _context.Users.FirstOrDefault(u => !u.IsDeleted && u.Id == request.Id);

            if (user == null)
                throw new EntityNotFoundException(request.Id, typeof(User));

            if (user.Id != _actor.Id && _actor.RoleType != RoleType.Administrator && _actor.RoleType != RoleType.Moderator)
                throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, "You can only edit your own profile photo.");

            _validator.ValidateAndThrow(request);

            var newFileName = Guid.NewGuid() + Path.GetExtension(request.ProfilePhoto.FileName);

            using (Image image = Image.Load(request.ProfilePhoto.OpenReadStream()))
            {
                image.Mutate(x => x.Resize(150, 150));

                image.Save(Path.Combine("wwwroot", User.PofileImageFolderPath, newFileName));
            }

            user.ProfilePhotoFileName = newFileName;

            _context.SaveChanges(_actor.Id);

            // if up to here all went without errors: delete old photo forms erver if one is set
            if (user.ProfilePhotoFileName != null && File.Exists(user.getProfilePhotoPath()))
            {
                File.Delete(user.getProfilePhotoPath());
            }
        }
    }
}
