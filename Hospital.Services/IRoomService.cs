﻿using Hospital.Utilities;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IRoomService
    {
       
            PagedResult<RoomViewModels> GetAll(int pageNumber, int pageSize);
            RoomViewModels GetRoomById(int RoomId);
            void UpdateRoom (RoomViewModels Room);
            void InsertRoom(RoomViewModels Room);
            void DeleteRoom (int Id);
        
    }
}
