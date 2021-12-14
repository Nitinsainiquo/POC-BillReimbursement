using BillReimbursement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillReimbursement.Repository.Interfaces
{
    public interface IApplyBillRepository
    {
        public void Add(ApplyBillModel bill);
        public IEnumerable<ViewApplyBillModel> GetAll();
        public IEnumerable<ViewApplyBillModel> GetByIdAll(string EmailId);
        public void update(ApplyBillModel bill);
        public void updateApproved(ApplyBillModel bill);
        public void updateDeclined(ApplyBillModel bill);
        public void Delete(int id);
    }
}
