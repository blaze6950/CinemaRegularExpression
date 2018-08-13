using System;
using System.Collections.Generic;

namespace CinemaRegularExpression
{
    class Film
    {
        private String _name;
        private Int32 _year;
        private String _country;
        private List<String> _genres = new List<string>();

        public string Name { get => _name; set => _name = value; }
        public Int32 Year { get => _year; set => _year = value; }
        public string Country { get => _country; set => _country = value; }
        public List<string> Genres { get => _genres; set => _genres = value; }

        public override string ToString()
        {
            String res;
            res = "\n\t" + Name + " ( " + Year + " ) \n Country : " + Country + "\n Genre(s) : ";
            for (int i = 0; i < Genres.Count; i++)
            {
                res += Genres[i];
            }
            res += "\n";
            return res;
        }
    }
}
