// QLDKhoa_CNTT.BLL/Services/UserService.cs
using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;

namespace QLDKhoa_CNTT.BLL.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private int _currentUserId; // Thêm trường để lưu ID người dùng hiện t
        public UserService()
        {
            _userRepository = new UserRepository();
        }
        // Phương thức để thiết lập ID người dùng hiện tại (gọi sau khi đăng nhập)
        public void SetCurrentUserId(int userId)
        {
            _currentUserId = userId;
        }
        public User? GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }
        public User? GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }
        public int GetCurrentUserId()
        {
            // Trả về ID người dùng đã được thiết lập
            return _currentUserId;
        }
        public User? CheckLogin(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
                return null;
            if (user.Password == password)
                return user;

            return null;
        }
        //public User? Get(string tendangnhap)
        //{
        //    return _userRepository.Get(tendangnhap);
        //}
        public void AddAnUser(User user)
        {
            _userRepository.AddAnUser(user);
        }

        public void UpdateAnUser(User user)
        {
            _userRepository.UpdateAnUser(user);
        }

        public void DeleteAnUser(int userId)
        {
            _userRepository.DeleteAnUser(userId);
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public User? GetAUser(int userId)
        {
            return _userRepository.GetUserById(userId);
        }
    }
}