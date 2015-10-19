namespace ProteinTrackerWebService.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using ProteinTrackerWebService.Models.Abstract;

    public class UserRepository : IUserRepository
    {
        #region Static Fields

        private static readonly List<User> users = new List<User>();

        private static int nextId = 0;

        #endregion

        #region Public Methods and Operators

        public void Add(User user)
        {
            user.UserId = nextId;
            nextId++;
            users.Add(user);
        }

        public ReadOnlyCollection<User> GetAll()
        {
            return users.AsReadOnly();
        }

        public User GetById(int id)
        {
            var user = users.SingleOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return null;
            }

            return new User { Goal = user.Goal, Name = user.Name, UserId = user.UserId, Total = user.Total };
        }

        public void Save(User updatedUser)
        {
            var user = this.GetById(updatedUser.UserId);
            user.Total = updatedUser.Total;
        }

        #endregion
    }
}