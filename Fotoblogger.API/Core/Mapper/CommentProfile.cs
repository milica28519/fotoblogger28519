using AutoMapper;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.API.Core.Mapper
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ForMember(dto => dto.Title, opt => opt.MapFrom(comment => comment.IsDeleted ? "Deleted" : comment.Title))
                .ForMember(dto => dto.Text, opt => opt.MapFrom(
                    comment => comment.IsDeleted 
                        ? 
                        (
                            "This comment has been deleted by " 
                            + (comment.CreatedBy == comment.DeletedBy ? "user" : "moderator or administrator" )
                        )
                        : comment.Text
                    ));
            CreateMap<CommentDto, Comment>();

            CreateMap<CreatePostCommentDto, Comment>();
            CreateMap<EditPostCommentDto, Comment>();

            CreateMap<Comment, PostCommentDto>()
                .ForMember(dto => dto.Title, opt => opt.MapFrom(comment => comment.IsDeleted ? "Deleted" : comment.Title))
                .ForMember(dto => dto.Text, opt => opt.MapFrom(
                    comment => comment.IsDeleted
                        ?
                        (
                            "This comment has been deleted by "
                            + (comment.CreatedBy == comment.DeletedBy ? "user" : "moderator or administrator")
                        )
                        : comment.Text
                    ))
                .ForMember(dto => dto.RepliesCount, opt => opt.MapFrom(comment => comment.ChildComments.Count));
        }
    }
}
