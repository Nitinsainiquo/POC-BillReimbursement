using BillReimbursement.Repository.Interfaces;
using BillReimbursement.Repository.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillReimbursement.Repository.Services
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly IConfiguration _config;
        public EmployeeRepository(IConfiguration config)
        {
            _config = config;

        }
        public IDbConnection connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public void Add(EmployeeModel employee)
        {
            employee.EmailId =  employee.EmailId.ToLower();
            using (IDbConnection db = connection)
            {
                string sql = @"INSERT INTO Employee (FullName,EmailId,Password,Role)
                            VALUES(@FullName,@EmailId,@Password,@Role)";
                db.Open();
                db.Execute(sql, employee);
            }
        }

        public IEnumerable<EmployeeModel> GetAll()
        {
            using (IDbConnection db = connection)
            {
                string sql = @"SELECT * FROM Employee";
                db.Open();
                return db.Query<EmployeeModel>(sql);
            }

        }
        public EmployeeModel? GetById(string EmailId)
        {
            using (IDbConnection db = connection)
            {
                string sql = @"SELECT * FROM Employee WHERE Employee.EmailId=@EmailId";
                db.Open();
                return db.Query<EmployeeModel>(sql,new {EmailId=EmailId}).FirstOrDefault();
            }

        }

        public void update(EmployeeModel employee)
        {
            using (IDbConnection db = connection)
            {
                string sql = @"UPDATE Employee SET FullName=@FullName,
                    Password=@Password";
                db.Open();
                db.Query<EmployeeModel>(sql,employee);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = connection)
            {
                string sql = @"DELETE FROM Employee WHERE Employee.Id=@id";
                db.Open();
                db.Query<EmployeeModel>(sql, new {Id = id});
            }

        }
    }
}
