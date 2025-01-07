using Microsoft.Extensions.Configuration;
using QLDKhoa_CNTT.DAL;
using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Identity.Client;
using QLDKhoa_CNTT.BLL.Services;
using QLDKhoa_CNTT.DAL.Repositories;

namespace MAIN_UI
{
    public partial class Login : Form
    {
        // Instance of the data access layer context and repositories
        //private readonly QuanLyDiemKhoaCNTTContext _dbContext;
        //private readonly UserRepository _userRepository;
        //private readonly UserRoleRepository _userRoleRepository;
        // Instances of the Business Logic Layer Services
        private readonly UserService _userService;
        private readonly UserRoleService _userRoleService;
        public Login()
        {
            InitializeComponent();
            //// Initialize data access context and repositories
            //_dbContext = new QuanLyDiemKhoaCNTTContext();
            //_userRepository = new UserRepository(_dbContext);
            //_userRoleRepository = new UserRoleRepository(_dbContext);
            //// Instantiate Services, pass repositories
            //_userService = new UserService(_userRepository);
            //_userRoleService = new UserRoleService(_dbContext);
            _userService = new UserService();
            _userRoleService = new UserRoleService();

        }


        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = tbusername.Text;
            string password = tbpassword.Text;

            User? acc = _userService.CheckLogin(username, password);
            if (acc == null)
            {
                MessageBox.Show("Đăng nhập thất bại. Vui lòng nhập đủ thông tin ", "huhu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Set the current user ID in UserService
            _userService.SetCurrentUserId(acc.UserId);

            // Check if the user has the required role

            // Here we will be checking if the user has a certain role by role id.
            if (!HasRequiredRole(acc, 1)) // Assuming Role ID 2 is an admin or instructor role that is allowed to access to this application.
            {
                MessageBox.Show("Bạn không có quyền để vào hệ thống", "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MainForm mainForm = new MainForm(_userService);
            mainForm.taiKhoan = acc;
            mainForm.Show();
            this.Hide();

        }
        private bool HasRequiredRole(User user, int roleId)
        {
            var userRoles = _userRoleService.GetUserRolesByUserId(user.UserId);
            return userRoles.Any(ur => ur.RoleId == roleId);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
       
        private void tbpassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}