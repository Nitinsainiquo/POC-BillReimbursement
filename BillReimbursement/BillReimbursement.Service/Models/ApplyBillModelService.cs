using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillReimbursement.Service.Models
{
    public class ApplyBillModelService
    {
        public int Id { get; set; }
        public string EmailId { get; set; }
        public DateTime ApplyDate { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public string PaymentMode { get; set; }
        public string Status { get; set; }
        public string? Remarks { get; set; }
        public string? ModifiedBy { get; set; }

    }
}
