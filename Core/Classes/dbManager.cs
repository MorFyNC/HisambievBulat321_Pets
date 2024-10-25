using HisambievBulat321_Pets.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace HisambievBulat321_Pets.Core.Classes
{
    internal static class dbManager
    {
        private static PetsEntities _dbEntities = new PetsEntities();
        public static List<Photo> GetPhotos() => _dbEntities.Photo.ToList();
        public static List<Pets> GetPets() => _dbEntities.Pets.ToList();
        public static List<Users> GetUsers() => _dbEntities.Users.ToList();
        public static void AddPhoto(string description, string imagePath, Pets pet, Pets secondPet)
        {
            _dbEntities.Photo.Add(new Photo() { ID = Guid.NewGuid().ToString(), Description = description, Pets = pet, Pet = pet.ID, Image = imagePath });
            
            if (secondPet != null)
            {
                _dbEntities.Photo.Add(new Photo() { ID=Guid.NewGuid().ToString(), Description = description, Pets = secondPet, Image = imagePath});
            }
            
            _dbEntities.SaveChanges();
        }
    }
}
