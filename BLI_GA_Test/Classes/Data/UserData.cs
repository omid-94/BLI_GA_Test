﻿using BLI_GA_Test.Interfaces;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Data
{
	public class UserData : IData<User>
	{
		private List<Rating> _ratings;

        public UserData(ref List<Rating> ratings)
		{
            _ratings = ratings;
        }
		
		public List<User> FetchData()
		{
			try
			{
				List<User> Users= new List<User>();
				var userIds = _ratings.Select(r => r.UserId).Distinct().ToArray();
				foreach ( var userid in userIds)
				{
					var lRatedMovieItems = _ratings.Where(r => r.UserId.Equals(userid)).ToList();
					Users.Add(new User() { UserId = userid, Ratings = lRatedMovieItems });
				}
				return Users;
			}
			catch
			{
				return null;
			}
		}
	}
}
