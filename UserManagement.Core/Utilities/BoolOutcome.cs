using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Core.Utilities
{
    public class BoolOutcome<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public BoolOutcome(bool success, string message = "", T data = default)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
