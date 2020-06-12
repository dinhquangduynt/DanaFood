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
    public interface IProductCategoryService {
        ProductCategory Add(ProductCategory ProductCategory);

        void Update(ProductCategory posCategory);

        ProductCategory Delete(int id);

        ProductCategory GetById(int id);

        IEnumerable<ProductCategory> GetAll();

        void Save();
    }

    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public ProductCategory Add(ProductCategory ProductCategory)
        {
            return _productCategoryRepository.Add(ProductCategory);
        }

        public ProductCategory Delete(int id)
        {
            return _productCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        //public IEnumerable<ProductCategory> GetAllByParentId(int parentId)
        //{
        //    return _ProductCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        //}

        public ProductCategory GetById(int id)
        {
            return _productCategoryRepository.GetSingleById(id);
        }

        public void Update(ProductCategory posCategory)
        {
            _productCategoryRepository.Update(posCategory);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}

