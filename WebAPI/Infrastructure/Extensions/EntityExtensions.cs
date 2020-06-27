using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThucPham.Model.Models;

namespace WebAPI.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategory postCategoryVm)
        {
            postCategory.ID = postCategoryVm.ID;
            postCategory.Name = postCategoryVm.Name;

            postCategory.Alias = postCategoryVm.Alias;
            postCategory.Description = postCategoryVm.Description;
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
            postCategory.Image = postCategoryVm.Image;
            postCategory.HomeFlag = postCategoryVm.HomeFlag;

            postCategory.CreatedBy = postCategoryVm.CreatedBy;
            postCategory.CreatedDate = postCategoryVm.CreatedDate;
            postCategory.UpdatedBy = postCategoryVm.UpdatedBy;
            postCategory.UpdatedDate = DateTime.Now;
            postCategory.Status = postCategoryVm.Status;
        }

        public static void UpdatePost(this Post post, Post postVm)
        {
            post.ID = postVm.ID;
            post.Name = postVm.Name;

            post.Alias = postVm.Alias;
            post.Description = postVm.Description;
            post.CategoryID = postVm.CategoryID;
            post.Content = postVm.Content;
            post.Image = postVm.Image;

            post.HomeFlag = postVm.HomeFlag;
            post.HotFlag = postVm.HotFlag;

            post.CreatedBy = postVm.CreatedBy;
            post.CreatedDate = postVm.CreatedDate;
            post.UpdatedBy = postVm.UpdatedBy;
            post.UpdatedDate = DateTime.Now;
            post.Status = postVm.Status;


        }


        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategory productCategoryVm)
        {
            productCategory.Name = productCategoryVm.Name;
            productCategory.Alias = productCategoryVm.Alias;
            productCategory.Description = productCategoryVm.Description;
            productCategory.DisplayOrder = productCategoryVm.DisplayOrder;
            productCategory.Image = productCategoryVm.Image;
            productCategory.HomeFlag = productCategoryVm.HomeFlag;
            productCategory.CreatedBy = productCategoryVm.CreatedBy;
            productCategory.CreatedDate = productCategoryVm.CreatedDate;
            productCategory.UpdatedBy = productCategoryVm.UpdatedBy;
            productCategory.UpdatedDate = DateTime.Now;
            productCategory.Status = productCategoryVm.Status;
        }

        public static void UpdateProduct(this Product product, Product productVm)
        {
           // product.ID = productVm.ID;
            product.Name = productVm.Name;
            product.Description = productVm.Description;
            product.Alias = productVm.Alias;
            product.CategoryID = productVm.CategoryID;
            product.Content = productVm.Content;
            product.Image = productVm.Image;
            product.MoreImages = productVm.MoreImages;
            product.Price = productVm.Price;
            product.PromotionPrice = productVm.PromotionPrice;
            product.Warranty = productVm.Warranty;
            product.HomeFlag = productVm.HomeFlag;
            product.HotFlag = productVm.HotFlag;
            product.CreatedDate = productVm.CreatedDate;
            product.CreatedBy = productVm.CreatedBy;
            product.UpdatedDate = DateTime.Now;
            product.UpdatedBy = productVm.UpdatedBy;
            product.Status = productVm.Status;
            product.Tags = productVm.Tags;
            product.Quantity = productVm.Quantity;
        }

        public static void UpdateFeedback(this Feedback feedback, Feedback feedbackVm)
        {
            feedback.Name = feedbackVm.Name;
            feedback.Email = feedbackVm.Email;
            feedback.Message = feedbackVm.Message;
            feedback.Status = true;
            feedback.Title = feedbackVm.Title;
            feedback.EmailContent = feedbackVm.EmailContent;
            //feedback.CreatedDate = DateTime.Now;
        }

        public static void UpdateOrder(this Order order, Order orderVm)
        {
            //order.CustomerName = orderVm.CustomerName;
            //order.CustomerAddress = orderVm.CustomerName;
            //order.CustomerEmail = orderVm.CustomerName;
            //order.CustomerMobile = orderVm.CustomerName;
            //order.CustomerMessage = orderVm.CustomerName;
            //order.PaymentMethod = orderVm.CustomerName;
            //order.CreatedDate = DateTime.Now;
            //order.CreatedBy = orderVm.CreatedBy;
            //order.Status = orderVm.Status;
            //order.CustomerId = orderVm.CustomerId;
            
        }

        public static void UpdateGroup(this Group appGroup, Group appGroupViewModel)
        {
            appGroup.ID = appGroupViewModel.ID;
            appGroup.Name = appGroupViewModel.Name;
        }

        public static void UpdateRole(this Role appRole, Role appRoleViewModel, string action = "add")
        {
            if (action == "update")
                appRole.Id = appRoleViewModel.Id;
            else
                appRole.Id = Guid.NewGuid().ToString();
            appRole.Name = appRoleViewModel.Name;
            appRole.Description = appRoleViewModel.Description;
        }
        public static void UpdateUser(this User appUser, User appUserViewModel, string action = "add")
        {

            appUser.Id = appUserViewModel.Id;
            appUser.FullName = appUserViewModel.FullName;
            appUser.BirthDay = appUserViewModel.BirthDay;
            appUser.UserName = appUserViewModel.UserName;
        }

      
    }
}