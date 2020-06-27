using System;
using System.Collections.Generic;
using ThucPham.Data.Infrastructure;
using ThucPham.Data.Repositories;
using ThucPham.Model.Models;

namespace ThucPham.Service
{
    public interface IRoleService
    {
        Role GetDetail(string id);
       // IEnumerable<Role> GetAll(string filter);
        IEnumerable<Role> GetAll();
        Role Add(Role role);
        void Update(Role role);
        void Delete(string id);

        //bool AddRolesToGroup(IEnumerable<RoleGroup> roleGroup, int groupId);
        //IEnumerable<Role> GetListRoleByGroup(int groupId);

        void Save();
    }
    public class RoleService : IRoleService
    {
        IRoleRepository _roleRepository;
        //IRoleGroupRepository _roleGroupRepository;
        IUnitOfWork _unitOfWork;

        public RoleService (IRoleRepository roleRepository, 
            IUnitOfWork unitOfWork) {
            this._roleRepository = roleRepository;
            this._unitOfWork = unitOfWork;
        }


        public Role Add(Role role)
        {
           if(_roleRepository.CheckContains(x => x.Description == role.Description))
            {
                throw new Exception("Tên không được trùng");
            }
            return _roleRepository.Add(role);
        }

        public void Delete(string id)
        {
            _roleRepository.DeleteMulti(x => x.Id == id);
        }

        public IEnumerable<Role> GetAll()
        {
            return _roleRepository.GetAll();
        }

        public Role GetDetail(string id)
        {
            return _roleRepository.GetSingleByCondition(x => x.Id == id);
         
        }

        //public IEnumerable<Role> GetListRoleByGroup(int groupId)
        //{
        //    return _roleRepository.GetListRoleGroupId(groupId);
        //}

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Role role)
        {
            if (_roleRepository.CheckContains(x => x.Description == role.Description && x.Id != role.Id))
            {
                throw new Exception("Tên không được trùng");
            }
            _roleRepository.Update(role);
        }
    }
}
