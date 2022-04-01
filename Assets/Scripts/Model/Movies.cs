using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class Movie
    {
        public string id; 
        public string name; 
        public List<string> showTimes;
        public string lastShowDate;
        public string screenName;
    }
    
    [Serializable]
    public class Movies
    {
        public List<Movie> availableMovies; 
    }
}
