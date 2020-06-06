using System.Collections.Generic;
using ThucPham.Data.Infrastructure;
using ThucPham.Data.Repositories;
using ThucPham.Model.Models;

namespace ThucPham.Service
{
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory postCategory);

        void Update(PostCategory posCategory);

        PostCategory Delete(int id);

        PostCategory GetById(int id);

        IEnumerable<PostCategory> GetAll();

        //IEnumerable<PostCategory> GetAllByParentId(int parentId);

        void Save();
    }
    public class PostCategoryService : IPostCategoryService
    {
        private IPostCategoryRepository _postCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public PostCategory Add(PostCategory postCategory)
        {
            return _postCategoryRepository.Add(postCategory);
        }

        public PostCategory Delete(int id)
        {
            return _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        //public IEnumerable<PostCategory> GetAllByParentId(int parentId)
        //{
        //    return _postCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        //}

        public PostCategory GetById(int id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }

        public void Update(PostCategory posCategory)
        {
            _postCategoryRepository.Update(posCategory);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
