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
            postCategory.UpdatedDate = postCategoryVm.UpdatedDate;
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
            post.UpdatedDate = postVm.UpdatedDate;
            post.Status = postVm.Status;


        }
    }
}