using PetShopDan.Models;

namespace PetShopDan.Repository
{
    public interface ICommentRepository
    {

        IEnumerable<Comment> GetAllComments();
        Comment GetCommentById(int CommentId);

        void AddComment(Comment comment);

        void UpdateComment(Comment comment);
        void DeleteComment(int CommentId);
    }
}
