﻿using AutoMapper;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.API.Core.Mapper
{
    public class UserCommentVoteProfile : Profile
    {
        public UserCommentVoteProfile()
        {
            CreateMap<UserCommentVoteDto, UserCommentVote>();
        }
    }
}
