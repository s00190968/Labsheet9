using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieListing
{
    public class Movie
    {
        public string Name { get; set; }
        public string movieGenre { get; set; }
        //enum Genre { Comedy, Action, Horror, Fantasy, Drama, Thriller, Documentation, Adventure, Romance, Animation, Unknown };
        //Genre genre;
        public int Rating { get; set; }

        #region Construstor
        public Movie():this("Unknown")
        {

        }
        public Movie(string title) : this(title, "Unknown", 0)
        {

        }
        public Movie(string name, string g, int rating)
        {
            Name = name;
            Rating = rating;
            movieGenre = g;

            //switch (g)
            //{
            //    case "0":
            //        genre = Genre.Comedy;
            //        break;

            //    case "1":
            //        genre = Genre.Action;
            //        break;

            //    case "2":
            //        genre = Genre.Horror;
            //        break;

            //    case "3":
            //        genre = Genre.Fantasy;
            //        break;

            //    case "4":
            //        genre = Genre.Drama;
            //        break;

            //    case "5":
            //        genre = Genre.Thriller;
            //        break;
            //    case "Document":
            //        genre = Genre.Documentation;
            //        break;

            //    case "6":
            //       genre = Genre.Adventure;
            //        break;

            //    case "7":
            //        genre = Genre.Romance;
            //        break;

            //    case "8":
            //        genre = Genre.Animation;
            //        break;

            //    default:
            //        genre = Genre.Unknown;
            //        break;
            //}
        }
        #endregion Constructors

        public override string ToString()
        {
            return string.Format($"Title: {Name}, Genre: {movieGenre}, Rating: {Rating}");
        }
    }
    }
