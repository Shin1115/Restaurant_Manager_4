using Restaurant_Manager_4.DTO;
using Restaurant_Manager_4.SerializableObjects;
using Restaurant_Manager_4.SerializableObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Manager_4.Utils
{
    public class DatBanRequestCreator
    {
        private DatMonAnSessionData _datMonAnSessionData;
        private Dictionary<int, MonAnDTO> _monAnDic;
        private Dictionary<int, BanDTO> _banDic;

        public DatBanRequestCreator(DatMonAnSessionData datMonAnSessionData)
        {
            _datMonAnSessionData = datMonAnSessionData;
            _monAnDic = new Dictionary<int, MonAnDTO>();
            _banDic = new Dictionary<int, BanDTO>();
        }

        public int AddBanToPhanMuc(int idBan, int idPhanMuc)
        {
            return 0;
        }
    }
}