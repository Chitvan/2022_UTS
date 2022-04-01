using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class SeatMaps
    {
        public List<SeatMap> screens;
    }
    
    [Serializable]
    public class SeatMap
    {
        public string name;
        public int rowsCount;
        public Map map;
    }
    
    [Serializable]
    public class Map
    {
        public List<int> a;
        public List<int> b;
        public List<int> c;
    }
}
