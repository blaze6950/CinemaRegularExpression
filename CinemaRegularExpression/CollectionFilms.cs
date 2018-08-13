using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CinemaRegularExpression
{
    class CollectionFilms
    {
        private List<Film> _filmList;
        private FileStream _htmlFile;

        public CollectionFilms(String path )
        {
            _filmList = new List<Film>();
            _htmlFile = new FileStream(path, FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.None);
        }

        public void Scan()
        {
            using (StreamReader reader = new StreamReader(_htmlFile))
            {
                string str = reader.ReadToEnd();
                //Console.WriteLine(str);
                string patternName = @">(?<name>\w+.*?)</a></h2>";
                string patternYear = @"(?<year>((1|2)\d{3}))</span>";
                string patternCountry = "Страна</span>: <span class=\"orange\">" + @"(?<country>\p{IsCyrillic}+\D*\p{IsCyrillic}+)</span>";
                string patternGenres = @"/'>(?<genre>\p{IsCyrillic}+)</a>";
                Regex regex = new Regex(patternName, RegexOptions.None);
                MatchCollection matches = regex.Matches(str);
                foreach (Match match in matches)
                {
                    _filmList.Add(new Film());
                    _filmList.Last().Name = match.Groups[1].Value;
                }
                int i = 0;
                regex = new Regex(patternYear, RegexOptions.None);
                matches = regex.Matches(str);
                foreach (Match match in matches)
                {
                    _filmList[i].Year = Int32.Parse(match.Groups[1].Value);
                    i++;
                }
                i = 0;
                regex = new Regex(patternCountry, RegexOptions.None);
                matches = regex.Matches(str);
                foreach (Match match in matches)
                {
                    _filmList[i].Country = match.Groups[1].Value;
                    i++;
                }
                i = 0;
                regex = new Regex(patternGenres, RegexOptions.None);
                matches = regex.Matches(str);
                foreach (Match match in matches)
                {
                    _filmList[i].Genres.Add(match.Groups[1].Value);
                    i++;
                    if (_filmList.Count == i) break;
                }
            }

        }

        public void Print()
        {
            foreach (var film in _filmList)
            {
                Console.WriteLine(film.ToString());
            }
        }
    }
}
