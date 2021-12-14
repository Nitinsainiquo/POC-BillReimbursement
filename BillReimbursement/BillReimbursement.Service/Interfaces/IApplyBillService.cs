using BillReimbursement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillReimbursement.Service.Interfaces
{
    public interface IApplyBillService
    {
        public void Add(ApplyBillModelService bill);
        public IEnumerable<ViewApplyBillModelService> GetAll();
        public IEnumerable<ViewApplyBillModelService> GetByIdAll(string EmailId);
        public void update(ApplyBillModelService bill);
        public void updateApproved(ApplyBillModelService bill);
        public void updateDeclined(ApplyBillModelService bill);
        public void Delete(int id);

    }
}
