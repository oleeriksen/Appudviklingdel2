using System;
using Core;
namespace Backend.Repositories.BikeRepo
{
	public interface IBikeRepository
	{
		Bike[] GetAll();
		void Add(Bike bike);
		void Delete(int id);
	}
}

