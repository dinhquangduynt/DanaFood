﻿using System.Collections.Generic;
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

        IEnumerable<PostCategory> GetAll(string keyword = null);

        void Save();
    }
    public class PostCategoryService : IPostCategoryService
    {
        private IPostCategoryRepository _postCategoryRepository;
        private IUnitOfWork _unitOfWork;
        private IPostRepository _postRepository;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork, IPostRepository postRepository)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
            this._postRepository = postRepository;
        }

        public PostCategory Add(PostCategory postCategory)
        {
            return _postCategoryRepository.Add(postCategory);
        }

        public PostCategory Delete(int id)
        {
            if(_postRepository.Count(x => x.CategoryID == id) > 0)
            {
                _postRepository.DeleteMulti(x => x.CategoryID == id);
            }
           
            return _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll(string keyword = null)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _postCategoryRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            else
            {
                return _postCategoryRepository.GetAll();
            }
               
        }


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
