using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Procedures
{
    public class ProcedureLog
    {
        private readonly IndexId _index = new IndexId();
        private readonly List<KeyValuePair<string,ProcedureStatus>> _statuses = new List<KeyValuePair<string, ProcedureStatus>>();

        public int FailureCount() => StatusCount(ProcedureStatus.FAILURE);

        public int SuccessCount() => StatusCount(ProcedureStatus.SUCCESS);
        public int SuspendCount() => StatusCount(ProcedureStatus.SUSPEND);
        private int StatusCount(ProcedureStatus status) => _statuses.Where(x => x.Value == status).Count();

        internal void Record(ProcedureStatus result)
        {
            _index.Next();
            _statuses.Add(new KeyValuePair<string, ProcedureStatus>(_index.Value().ToString(), result));
        }
    }
}
