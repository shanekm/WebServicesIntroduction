namespace ProteinTrackerWebService.Models.Abstract
{
    using System.Collections.ObjectModel;

    public interface IUserRepository
    {
        #region Public Methods and Operators

        void Add(User user);

        ReadOnlyCollection<User> GetAll();

        User GetById(int id);

        void Save(User updatedUser);

        #endregion
    }
}