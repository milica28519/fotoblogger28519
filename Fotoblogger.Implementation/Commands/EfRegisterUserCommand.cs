using FluentValidation;
using Fotoblogger.Application.Commands;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Application.Email;
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
    public class EfRegisterUserCommand : IRegisterUserCommand
    {
        private readonly FotobloggerContext _context;
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender _sender;

        public EfRegisterUserCommand(FotobloggerContext context, RegisterUserValidator validator, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
        }
        public int Id => 5;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(RegisterUserDto request)
        {
            _validator.ValidateAndThrow(request); // ValidationException

            var defaultUserRole = _context.Roles.Where(r => r.Name.Trim().ToLower() == "user").FirstOrDefault();

            if(defaultUserRole == null)
                defaultUserRole = _context.Roles.Where(r => r.RoleType == RoleType.User).OrderBy(r => r.Id).FirstOrDefault();

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
                RoleId = defaultUserRole.Id,
            };

            // if profile image is provided then upload image and set it for user
            if (request.ProfilePhoto != null)
            {
                var newFileName = Guid.NewGuid() + Path.GetExtension(request.ProfilePhoto.FileName);

                using (Image image = Image.Load(request.ProfilePhoto.OpenReadStream()))
                {
                    image.Mutate( x => x.Resize(150, 150) );

                    image.Save(Path.Combine("wwwroot", User.PofileImageFolderPath, newFileName));
                }

                user.ProfilePhotoFileName = newFileName;
            }

            _context.Users.Add(user);
            
            _context.SaveChanges();

            _sender.Send(new SendEmailDto
            {
                Content = "<h1>Successful registration!</h1><p>Welcome to Fotoblogger!</p>",
                SendTo = request.Email,
                Subject = "Registration - Fotoblogger"
            });
        }
    }
}
