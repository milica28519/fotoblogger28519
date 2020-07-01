using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Domain.Entities
{
    public class UseCase : IUseCase
    {
        public int Id { get ; set; }
        public string Name { get; set ; }
        public virtual ICollection<RoleUseCase>? RoleUseCases { get; set; }
        public virtual ICollection<UserUseCase>? UserUseCases { get; set; }
        public static Dictionary<int, string> UseCaseDictionary { get; } = new Dictionary<int, string>()
        {
            { 1, "Get Posts" },                 // 1 - EfGetPostsQuery
            { 2, "Create Posts" },              // 2 - EfCreatePostCommand
            { 3, "Edit Post" },                 // 3 - EfEditPostCommand
            { 4, "Get Roles" },                 // 4 - EfGetRolesQuery
            { 5, "User Registration" },         // 5 - EfRegisterUserCommand
            { 6, "Create Role" },               // 6 - EfCreateRoleCommand
            { 7 , "Edit Role" },                // 7 - EfEditRoleCommand
            { 8 , "Get Role" },                 // 8 - EfGetRoleQuery
            { 9 , "Delete Role" },              // 9 - EfDeleteRoleCommand
            { 10 , "Delete Post" },             // 10 - EfDeletePostCommand
            { 11 , "Get Post" },                // 11 - EfGetPostQuery
            { 12 , "Get Photos" },              // 12 - EfGetPhotosQuery
            { 13 , "Get Photo" },               // 13 - EfGetPhotoQuery
            { 14 , "Score Photo" },             // 14 - EfScorePhotoCommand
            { 15 , "Remove Score for Photo" },  // 15 - EfRemovePhotoScoreCommand
            { 16 , "Add Post Comment" },        // 16 - EfAddPostCommentCommand
            { 17 , "Edit Post Comment" },       // 17 - EfEditPostCommentCommand
            { 18 , "Delete Post Comment" },     // 18 - EfDeletePostCommentCommand
            { 19 , "Get Post Comments" },       // 19 - EfGetPostCommentsQuery
            { 20 , "Get Post Comment Replies" },// 20 - EfGetPostCommentRepliesQuery
            { 21 , "Get User" },                // 21 - EfGetUserQuery
            { 22 , "Get Users" },               // 22 - EfGetUsersQuery
            { 23 , "Edit User" },               // 23 - EfEditUserCommand
            { 24 , "Delete User" },             // 24 - EfDeleteUsersCommand
            { 25 , "Set Profile Photo" },       // 25 - EfSetUserProfilePhotoCommand
            { 26 , "Remove Profile Photo" },    // 26 - EfRemoveUserProfilePhotoCommand
            { 27 , "Deactivate User" },         // 27 - EfDeactivateUserCommand
            { 28 , "Activate User" },           // 28 - EfActivateUserCommand
            { 29 , "Change User Role" },        // 29 - EfChangeUserRoleCommand
            { 30 , "Change User Allowed UseCases" },// 30 - EfChangeUserUseCasesCommand
            { 31 , "Get User Permissions" },    // 31 - EfGetUserPermissionsCommand
            { 32 , "Comment Vote" },            // 32 - EfAddCommentVoteCommand
            { 33 , "Remove Comment Vote" },     // 33 - EfRemoveCommentVoteCommand
            { 34 , "Get Use Case Logs" }        // 34 - EfGetUseCaseLogsQuery
        };

        public static UseCase getUseCase(int id)
        {
            return new UseCase { Id = id, Name = UseCaseDictionary[id] };
        }
    }

    public interface IUseCase
    {
        int Id { get; }
        string Name { get; }
    }
}
