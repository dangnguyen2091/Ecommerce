using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace Ecommerce.Common.Struct
{
    public class ResultHandle
    {
        public int Number { get; set; }
        public string Message { get; set; }
        public bool HasError { get { return Number != 0; } }
        public Dictionary<string, object> Outputs { get; set; }

        public ResultHandle()
        {
            Number = 0;
            Message = string.Empty;
            Outputs = new Dictionary<string, object>();
        }

        public ResultHandle(int code, string message)
        {
            Number = code;
            Message = message;
            Outputs = new Dictionary<string, object>();
        }

        public ResultHandle(DbUpdateException dbUpdateException)
        {
            SqlException sqlException = (SqlException)dbUpdateException.InnerException.InnerException;
            Number = sqlException.Number;
            Message = sqlException.Message;
            Outputs = new Dictionary<string, object>();
        }

        public static ResultHandle InvalidInput(string message)
        {
            return new ResultHandle(CommonCode.InvalidInput, message);
        }

        public static ResultHandle DataNotExist()
        {
            return new ResultHandle(CommonCode.DataNotExists, "Cannot find object");
        }

        public static ResultHandle UploadFailed()
        {
            return new ResultHandle(CommonCode.UploadFailed, "Upload failed");
        }
    }
}
