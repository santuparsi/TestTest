using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnDBFirst_Demo1.ViewModels
{
    class IssueBookToStudent
    {
        public decimal StudCode { get; set; }
        public string StudName { get; set; }
        public decimal? DeptCode { get; set; }
        public decimal? BookCode { get; set; }
        public string BookName { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpReturnDate { get; set; }
    }
}
