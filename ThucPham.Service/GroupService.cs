using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucPham.Data.Infrastructure;
using ThucPham.Data.Repositories;
using ThucPham.Data.Repository;
using ThucPham.Model.Models;

namespace ThucPham.Service
{
    public interface IGroupService
    {
        Group GetDetail(int id);

        IEnumerable<Group> GetAll(int page, int pageSize, out int totalRow, string filter);

        IEnumerable<Group> GetAll();

        Group Add(Group appGroup);

        void Update(Group appGroup);

        Group Delete(int id);

        bool AddUserToGroups(IEnumerable<UserGroup> groups, string userId);

        IEnumerable<Group> GetListGroupByUserId(string userId);

        IEnumerable<User> GetListUserByGroupId(int groupId);

        void Save();
    }
    public class GroupService : IGroupService
    {
        private IGroupRepository _appGroupRepository;
        private IUnitOfWork _unitOfWork;
        private IUserGroupRepository _appUserGroupRepository;

        public GroupService(IUnitOfWork unitOfWork,
            IUserGroupRepository appUserGroupRepository,
            IGroupRepository appGroupRepository)
        {
            this._appGroupRepository = appGroupRepository;
            this._appUserGroupRepository = appUserGroupRepository;
            this._unitOfWork = unitOfWork;
        }

        public Group Add(Group appGroup)
        {
            if (_appGroupRepository.CheckContains(x => x.Name == appGroup.Name))
                throw new Exception("Tên không được trùng");
            return _appGroupRepository.Add(appGroup);
        }

        public Group Delete(int id)
        {
            var appGroup = this._appGroupRepository.GetSingleById(id);
            return _appGroupRepository.Delete(appGroup);
        }

        public IEnumerable<Group> GetAll()
        {
            return _appGroupRepository.GetAll();
        }

        public IEnumerable<Group> GetAll(int page, int pageSize, out int totalRow, string filter = null)
        {
            var query = _appGroupRepository.GetAll();
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Name.Contains(filter));

            totalRow = query.Count();
            return query.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);
        }

        public Group GetDetail(int id)
        {
            return _appGroupRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Group appGroup)
        {
            if (_appGroupRepository.CheckContains(x => x.Name == appGroup.Name && x.ID != appGroup.ID))
                throw new Exception("Tên không được trùng");
            _appGroupRepository.Update(appGroup);
        }

        public bool AddUserToGroups(IEnumerable<UserGroup> userGroups, string userId)
        {
            _appUserGroupRepository.DeleteMulti(x => x.UserId == userId);
            foreach (var userGroup in userGroups)
            {
                _appUserGroupRepository.Add(userGroup);
            }
            return true;
        }

        public IEnumerable<Group> GetListGroupByUserId(string userId)
        {
            return _appGroupRepository.GetListGroupByUserId(userId);
        }

        public IEnumerable<User> GetListUserByGroupId(int groupId)
        {
            return _appGroupRepository.GetListUserByGroupId(groupId);
        }
    }
}
