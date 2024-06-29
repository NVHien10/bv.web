using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Utilities;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hospital.Services
{
    public class RoomService : IRoomService
    {
        private IUnitOfWork _unitOfWork;
        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteRoom(int id)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetById(id);
            _unitOfWork.GenericRepository<Room>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<RoomViewModels> GetAll(int pageNumber, int pageSize)
        {
            var vm = new RoomViewModels();
            int totalCount;
            List<RoomViewModels> vmList = new List<RoomViewModels>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Room>().GetAll(includeProperties:"Hospital")
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Room>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception) 
            {
                throw;
            }
            var result = new PagedResult<RoomViewModels>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        public RoomViewModels GetRoomById(int RoomId)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetById(RoomId);
            var vm = new RoomViewModels(model);
            return vm;
        }
        
        public void InsertRoom(RoomViewModels Room)
        {
            var model = new RoomViewModels().ConvertViewModel(Room);
            _unitOfWork.GenericRepository<Room>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateRoom(RoomViewModels Room)
        {
            var model = new RoomViewModels().ConvertViewModel(Room);
            var ModelById = _unitOfWork.GenericRepository<Room>().GetById(model.Id);
            ModelById.Type = Room.Type;
            ModelById.RoomMumber = Room.RoomNumber;
            ModelById.Status = Room.Status;
            ModelById.HospitalId = Room.HospitalInfoId;

            _unitOfWork.GenericRepository<Room>().Update(ModelById);
            _unitOfWork.Save();
        }
        private List<RoomViewModels> ConvertModelToViewModelList(List<Room> modelList)
        {
            return modelList.Select(x => new RoomViewModels(x)).ToList();
        }


    }
}
