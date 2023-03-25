﻿using BLI_GA_Test.Interfaces;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Data
{
	public class UserData : IData<User>, IDisposable
	{
		private UnitOfWork _unitOfWork;
		public UserData()
		{
			_unitOfWork = new UnitOfWork();
		}
		public void Dispose()
		{
			_unitOfWork.Dispose();
		}

		public List<User> FetchData()
		{
			try
			{
				List<User> Users= new List<User>();
				var db = _unitOfWork.GetDB();
				var userIds = db.Ratings.Select(r => r.UserId).Distinct().ToArray();
				foreach ( var userid in userIds)
				{
					var lRatedMovieItems = db.Ratings.Where(r => r.UserId.Equals(userid)).ToList();
					Users.Add(new User() { Id = userid, RatedMovieItems = lRatedMovieItems });
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
