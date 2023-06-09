﻿using BLI_GA_Test.Classes.Data;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes
{
    public class ActiveUser
    {
        private static ActiveUser instance;
        public static ActiveUser GetInstance()
        {
            if(instance == null)
                instance = new ActiveUser();
            return instance;
        }
        public List<Rating> Ratings { get;
            set;
        }
        private ActiveUser() 
        {
            long maxRatingId = DataHolder.GetInstance().MaxRatingID;
            Ratings = new List<Rating>()
            {
                new Rating()
                {
                    MovieId = 802, //------
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 5
                },
                new Rating()
                {
                    MovieId = 209,//------
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 4
                },
                new Rating()
                {
                    MovieId = 1197,//------
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 2
                },

                new Rating()
                {
                    MovieId = 1444,
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 5
                },
                new Rating()
                {
                    MovieId = 518,
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 3
                },
                new Rating()
                {
                    MovieId = 294,
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 3
                },
                new Rating()
                {
                    MovieId = 21,
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 5
                },
                new Rating()
                {
                    MovieId = 328,
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 5
                },
                new Rating()
                {
                    MovieId = 96,
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 4
                },
                new Rating()
                {
                    MovieId = 796,
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 4
                }
            };
        }
    }
}
