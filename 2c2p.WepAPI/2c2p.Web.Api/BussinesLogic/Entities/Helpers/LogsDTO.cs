
using System.Collections.Generic;

namespace BussinesLogic.Entities.Helpers
{
    public partial class LogsDTO
    {
        public int AuditLogKey { get; set; }
        public string LogTypeKey { get; set; }
        public System.DateTime EventDate { get; set; }
        public string Message { get; set; }
        public string DataContext { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
        public string IP { get; set; }
        public string ExceptionType { get; set; }
        public string request { get; set;  }
        public string Response { get; set; }

        public virtual LogType LogType { get; set; }
    }
    public class Logs
    {
        public string Message { get; set; }
        public string ExceptionType { get; set; }
        public string Response { get; set; }
        public string Url { get; set; }
    }

    public partial class LogType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LogType()
        {
            this.AuditLog = new HashSet<LogsDTO>();
        }

        public int LogTypeKey { get; set; }
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LogsDTO> AuditLog { get; set; }
    }
}
