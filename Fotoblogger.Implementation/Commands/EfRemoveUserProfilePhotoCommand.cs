using Fotoblogger.Application;
using Fotoblogger.Application.Commands;
using Fotoblogger.Application.Exceptions;
using Fotoblogger.Domain.Entities;
using Fotoblogger.EfDataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Commands
{
    public class EfRemoveUserProfilePhotoCommand : IRemoveUserProfilePhotoCommand
    {
        private readonly FotobloggerContext _context;
        private readonly IApplicationActor _actor;

        public EfRemoveUserProfilePhotoCommand(FotobloggerContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 26;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(int id)
        {
            var user = _context.Users.FirstOrDefault(u => !u.IsDeleted && u.Id == id);

            if (user == null)
                throw new EntityNotFoundException(id, typeof(User));

            if (user.Id != _actor.Id && _actor.RoleType != RoleType.Administrator && _actor.RoleType != RoleType.Moderator)
                throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, $"You can only change your own profile photo.");

            if (user.ProfilePhotoFileName == null)
                throw new ActionNotRepeatableException(UseCase.getUseCase(this.Id), _actor);

            var filePath = user.getProfilePhotoPath();

            _context.SaveChanges(_actor.Id);

            // if up to here all went without errors: delete the photo
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
