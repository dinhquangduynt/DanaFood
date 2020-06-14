using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucPham.Data.Infrastructure;
using ThucPham.Data.Repositories;
using ThucPham.Model.Models;

namespace ThucPham.Service
{
    public interface IPostService
    {
        Post Add(Post postCategory);

        void Update(Post posCategory);

        Post Delete(int id);

        Post GetById(int id);

        IEnumerable<Post> GetAll(string keyword = null);

        //IEnumerable<Post> GetAllPaging();

        IEnumerable<Post> GetAllByTag(string tag);

        IEnumerable<Post> GetAllByCategory(int categoryId);

        void Save();
    }
    public class PostService : IPostService
    {

        private IPostRepository _postRepository;
        private IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork; 
        }

        public Post Add(Post post)
        {
            return _postRepository.Add(post);
        }

        public Post Delete(int id)
        {
            return _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll(string keyword = null)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _postRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            return _postRepository.GetAll();
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public IEnumerable<Post> GetAllByTag(string tag)
        {
            return _postRepository.GetAllByTag(tag);
        }

        public IEnumerable<Post> GetAllByCategory(int categoryId)
        {
            return _postRepository.GetMulti(x =>x.CategoryID == categoryId, new string[] { "PostCategory" });
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);

        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
