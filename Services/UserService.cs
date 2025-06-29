using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementApi.Models;
using UserManagementApi.Validators;

namespace UserManagementApi.Services
{
    public class UserService
    {
        private readonly List<User> _users = new();
        private readonly UserValidator _userValidator;

        public UserService(UserValidator userValidator)
        {
            _userValidator = userValidator;
        }

        public Task<User?> GetUserAsync(int id)
        {
            return Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            return Task.FromResult(_users);
        }

        public async Task<User?> AddUserAsync(User user)
        {
            var validationResult = _userValidator.Validate(user);
            if (!validationResult.IsValid)
            {
                return null; // or throw an exception based on your error handling strategy
            }

            user.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(user);
            return await Task.FromResult(user);
        }

        public async Task<User?> UpdateUserAsync(int id, User updatedUser)
        {
            var user = await GetUserAsync(id);
            if (user == null)
            {
                return null; // or throw an exception
            }

            var validationResult = _userValidator.Validate(updatedUser);
            if (!validationResult.IsValid)
            {
                return null; // or throw an exception
            }

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            return await Task.FromResult(user);
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return Task.FromResult(false); // or throw an exception
            }

            _users.Remove(user);
            return Task.FromResult(true);
        }
    }
}