using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Manager_4.SerializableObjects
{
    [Serializable]
    public class DatMonAnSessionData
    {
        public List<int> Bans { get; set; } = new List<int>();
        public List<int> MonAns { get; set; } = new List<int>();
    }
}