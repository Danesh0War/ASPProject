using PetShopDan.Data;
using PetShopDan.Models;

namespace PetShopDan.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private DataContext _context;
        public CommentRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comments!.ToList();
        }

        public Comment GetCommentById(int CommentId)
        {
            return (_context.Comments!.Single(a => a.CommentId == CommentId));
        }

        public void AddComment(Comment comment)
        {
            _context.Comments!.Add(comment);
            _context.SaveChanges();
        }
        public void DeleteComment(int CommentId)
        {
            var CommentInDb = GetCommentById(CommentId);
            _context.Comments?.Remove(CommentInDb);
            _context.SaveChanges();
        }

        public void UpdateComment(Comment comment)
        {
            var CommentInDb = GetCommentById(comment.CommentId);
            CommentInDb.Text = comment.Text;

            _context.SaveChanges();


        }
    }
}