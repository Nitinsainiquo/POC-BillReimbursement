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
    public class ApplyBillRepository : IApplyBillRepository
    {
        private readonly IConfiguration _config;
        public ApplyBillRepository(IConfiguration config)
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
        public void Add(ApplyBillModel bill)
        {
            bill.EmailId = bill.EmailId.ToLower();
            bill.PaymentMode = bill.PaymentMode.ToLower();
            bill.Type = bill.Type.ToLower();
            bill.Status = "pending";
            bill.Status = bill.Status.ToLower();
            using (IDbConnection db = connection)
            {
                string sql = @"INSERT INTO Bill (EmailId,ApplyDate,Type,Amount,PaymentMode,Status,Remarks,ModifiedBy)
                            VALUES(@EmailId,@ApplyDate,@Type,@Amount,@PaymentMode,@Status,@Remarks,@ModifiedBy)";
                db.Open();
                db.Execute(sql, bill);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = connection)
            {
                string sql = @"DELETE FROM Bill WHERE Bill.Id=@id";
                db.Open();
                db.Query<ApplyBillModel>(sql, new { Id = id });
            }
        }

        public IEnumerable<ViewApplyBillModel> GetAll()
        {
            using (IDbConnection db = connection)
            {
                string sql = @"SELECT B.Id,B.EmailId,E.FullName,B.ApplyDate,B.Type,B.Amount,B.PaymentMode,B.Status,B.Remarks,B.ModifiedBy FROM 
                                Employee E INNER JOIN Bill B ON B.EmailId=E.EmailId";
                db.Open();
                return db.Query<ViewApplyBillModel>(sql);
            }
        }

        public IEnumerable<ViewApplyBillModel> GetByIdAll(string EmailId)
        {
            using (IDbConnection db = connection)
            {
                string sql = @"SELECT B.Id,B.EmailId,E.FullName,B.ApplyDate,B.Type,B.Amount,B.PaymentMode,B.Status,B.Remarks,B.ModifiedBy FROM 
                                Employee E INNER JOIN Bill B ON B.EmailId=E.EmailId WHERE E.EmailId=@EmailId";
                db.Open();
                var result =  db.Query<ViewApplyBillModel>(sql, new {EmailId = EmailId });
                return result;
            }
        }

        public void update(ApplyBillModel bill)
        {
            bill.EmailId = bill.EmailId.ToLower();
            bill.PaymentMode = bill.PaymentMode.ToLower();
            bill.Type = bill.Type.ToLower();
            bill.Status = bill.Status.ToLower();

            using (IDbConnection db = connection)
            {
                string sql = @"UPDATE [Bill] SET [EmailId]=@EmailId,[ApplyDate]=@ApplyDate,[Type]=@Type,[Amount]=@Amount,[PaymentMode]=@PaymentMode,[Status]=@Status,[Remarks]=@Remarks,[ModifiedBy]=@ModifiedBy WHERE Id=@Id";
                db.Open();
                db.Query<ApplyBillModel>(sql, bill);
            }
        }
        public void updateApproved(ApplyBillModel bill)
        {
            bill.EmailId = bill.EmailId.ToLower();
            bill.PaymentMode = bill.PaymentMode.ToLower();
            bill.Type = bill.Type.ToLower();
            bill.Status= "approved";
            bill.Status = bill.Status.ToLower();

            using (IDbConnection db = connection)
            {
                string sql = @"UPDATE [Bill] SET [EmailId]=@EmailId,[ApplyDate]=@ApplyDate,[Type]=@Type,[Amount]=@Amount,[PaymentMode]=@PaymentMode,[Status]=@Status,[Remarks]=@Remarks,[ModifiedBy]=@ModifiedBy WHERE Id=@Id";
                db.Open();
                db.Query<ApplyBillModel>(sql, bill);
            }
        }
        public void updateDeclined(ApplyBillModel bill)
        {
            bill.EmailId = bill.EmailId.ToLower();
            bill.PaymentMode = bill.PaymentMode.ToLower();
            bill.Type = bill.Type.ToLower();
            bill.Status = "declined";
            bill.Status = bill.Status.ToLower();

            using (IDbConnection db = connection)
            {
                string sql = @"UPDATE [Bill] SET [EmailId]=@EmailId,[ApplyDate]=@ApplyDate,[Type]=@Type,[Amount]=@Amount,[PaymentMode]=@PaymentMode,[Status]=@Status,[Remarks]=@Remarks,[ModifiedBy]=@ModifiedBy WHERE Id=@Id";
                db.Query<ApplyBillModel>(sql, bill);
            }
        }
    }
}
 