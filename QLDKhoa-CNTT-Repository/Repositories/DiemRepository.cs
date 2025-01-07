using Microsoft.EntityFrameworkCore;
using QLDKhoa_CNTT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class DiemRepository
    {
        private readonly QuanLyDiemKhoaCNTTContext _context;

        public DiemRepository()
        {
            _context = new QuanLyDiemKhoaCNTTContext();
        }

        public List<Diem> GetAll()
        {
            return _context.Diems.ToList();
        }

        public List<Diem> GetAllIncluding(params System.Linq.Expressions.Expression<Func<Diem, object>>[] includes)
        {
            IQueryable<Diem> query = _context.Diems;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.ToList();
        }

        public Diem Get(int id)
        {
            return _context.Diems.Find(id);
        }

        public Diem GetIncluding(int id, params System.Linq.Expressions.Expression<Func<Diem, object>>[] includes)
        {
            IQueryable<Diem> query = _context.Diems;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(e => e.Id == id);
        }

        public void Create(Diem entity)
        {
            _context.Diems.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Diem entity)
        {
            _context.Diems.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entityToDelete = _context.Diems.Find(id);
            if (entityToDelete != null)
            {
                _context.Diems.Remove(entityToDelete);
                _context.SaveChanges();
            }
        }

        public IQueryable<Diem> FindBy(System.Linq.Expressions.Expression<Func<Diem, bool>> predicate)
        {
            return _context.Diems.Where(predicate);
        }

        public List<Diem> GetBySinhVien(int idSinhVien)
        {
            return _context.Diems.Where(d => d.IdSinhVien == idSinhVien).ToList();
        }
    }
}

//using QLDKhoa_CNTT.DAL.Entities;
//using System;
//using System.Collections.Generic;
//using Microsoft.Data.SqlClient;

//namespace QLDKhoa_CNTT.DAL.Repositories
//{
//    public class DiemRepository
//    {
//        private readonly DbConnection _dbConnection; // Thêm một field để lưu trữ instance của DbConnection

//        public DiemRepository() // Constructor để tạo instance của DbConnection
//        {
//            _dbConnection = new DbConnection();
//        }

//        public List<Diem> GetAll()
//        {
//              var ThuKieuMoi = new DbConnection();
//            List<Diem> diems = new List<Diem>();
//            using (SqlConnection connection = ThuKieuMoi.GetSqlConnection()) // Sử dụng instance để gọi phương thức
//            {
//                connection.Open();
//                string query = "SELECT ID, ID_SinhVien, ID_LanThi, Diem FROM Diem";
//                using (SqlCommand command = new SqlCommand(query, connection))
//                {
//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            Diem diem = new Diem
//                            {
//                                Id = Convert.ToInt32(reader["ID"]),
//                                IdSinhVien = Convert.ToInt32(reader["ID_SinhVien"]),
//                                IdLanThi = Convert.ToInt32(reader["ID_LanThi"]),
//                                Diem1 = reader["Diem"] == DBNull.Value ? null : Convert.ToDouble(reader["Diem"])
//                            };
//                            diems.Add(diem);
//                        }
//                    }
//                }
//            }
//            return diems;
//        }

//        public Diem Get(int id)
//        {
//            using (SqlConnection connection = _dbConnection.GetSqlConnection())
//            {
//                connection.Open();
//                string query = "SELECT ID, ID_SinhVien, ID_LanThi, Diem FROM Diem WHERE ID = @Id";
//                using (SqlCommand command = new SqlCommand(query, connection))
//                {
//                    command.Parameters.AddWithValue("@Id", id);
//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        if (reader.Read())
//                        {
//                            return new Diem
//                            {
//                                Id = Convert.ToInt32(reader["ID"]),
//                                IdSinhVien = Convert.ToInt32(reader["ID_SinhVien"]),
//                                IdLanThi = Convert.ToInt32(reader["ID_LanThi"]),
//                                Diem1 = reader["Diem"] == DBNull.Value ? null : Convert.ToDouble(reader["Diem"])
//                            };
//                        }
//                        return null;
//                    }
//                }
//            }
//        }

//        public List<Diem> GetBySinhVien(int idSinhVien)
//        {
//            List<Diem> diems = new List<Diem>();
//            using (SqlConnection connection = _dbConnection.GetSqlConnection())
//            {
//                connection.Open();
//                string query = "SELECT ID, ID_SinhVien, ID_LanThi, Diem FROM Diem WHERE ID_SinhVien = @IdSinhVien";
//                using (SqlCommand command = new SqlCommand(query, connection))
//                {
//                    command.Parameters.AddWithValue("@IdSinhVien", idSinhVien);
//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            Diem diem = new Diem
//                            {
//                                Id = Convert.ToInt32(reader["ID"]),
//                                IdSinhVien = Convert.ToInt32(reader["ID_SinhVien"]),
//                                IdLanThi = Convert.ToInt32(reader["ID_LanThi"]),
//                                Diem1 = reader["Diem"] == DBNull.Value ? null : Convert.ToDouble(reader["Diem"])
//                            };
//                            diems.Add(diem);
//                        }
//                    }
//                }
//            }
//            return diems;
//        }

//        public void Create(Diem diem)
//        {
//            using (SqlConnection connection = _dbConnection.GetSqlConnection())
//            {
//                connection.Open();
//                string query = "INSERT INTO Diem (ID_SinhVien, ID_LanThi, Diem) VALUES (@IdSinhVien, @IdLanThi, @Diem)";
//                using (SqlCommand command = new SqlCommand(query, connection))
//                {
//                    command.Parameters.AddWithValue("@IdSinhVien", diem.IdSinhVien);
//                    command.Parameters.AddWithValue("@IdLanThi", diem.IdLanThi);
//                    command.Parameters.AddWithValue("@Diem", diem.Diem1.HasValue ? (object)diem.Diem1.Value : DBNull.Value);
//                    command.ExecuteNonQuery();
//                }
//            }
//        }

//        public void Update(Diem diem)
//        {
//            using (SqlConnection connection = _dbConnection.GetSqlConnection())
//            {
//                connection.Open();
//                string query = "UPDATE Diem SET ID_SinhVien = @IdSinhVien, ID_LanThi = @IdLanThi, Diem = @Diem WHERE ID = @Id";
//                using (SqlCommand command = new SqlCommand(query, connection))
//                {
//                    command.Parameters.AddWithValue("@Id", diem.Id);
//                    command.Parameters.AddWithValue("@IdSinhVien", diem.IdSinhVien);
//                    command.Parameters.AddWithValue("@IdLanThi", diem.IdLanThi);
//                    command.Parameters.AddWithValue("@Diem", diem.Diem1.HasValue ? (object)diem.Diem1.Value : DBNull.Value);
//                    command.ExecuteNonQuery();
//                }
//            }
//        }

//        public bool Delete(int id)
//        {
//            try
//            {
//                using (SqlConnection connection = _dbConnection.GetSqlConnection())
//                {
//                    connection.Open();
//                    string query = "DELETE FROM Diem WHERE ID = @Id";
//                    using (SqlCommand command = new SqlCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@Id", id);
//                        int rowsAffected = command.ExecuteNonQuery();
//                        return rowsAffected > 0;
//                    }
//                }
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }
//    }
//}
