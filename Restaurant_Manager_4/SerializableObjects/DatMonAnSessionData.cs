using Restaurant_Manager_4.DTO;
using Restaurant_Manager_4.SerializableObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Manager_4.SerializableObjects
{
    [Serializable]
    public class DatMonAnSessionData
    {
        public Dictionary<int, Dictionary<PhanMucType, List<int>>> Data { get; set; }
    }
}