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

        IEnumerable<ProductCategory> GetAll(string keyword = null);

        void Save();
    }

    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;
        private IProductRepository _productRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
            this._productRepository = productRepository;
        }

        public ProductCategory Add(ProductCategory ProductCategory)
        {
            return _productCategoryRepository.Add(ProductCategory);
        }

        public ProductCategory Delete(int id)
        {
            if (_productRepository.Count(x => x.CategoryID == id) > 0)
            {
                _productRepository.DeleteMulti(x => x.CategoryID == id);
            }
           
            return _productCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll(string keyword = null)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _productCategoryRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            else
            {
                return _productCategoryRepository.GetAll();
            }
           
        }

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

