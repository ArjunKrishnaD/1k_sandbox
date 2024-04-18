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
        private readonly Dictionary<string, ProcedureStatus> _statuses = new Dictionary<string, ProcedureStatus>();
        public int SuccessCount()
        {
            return _statuses.Where(x => x.Value == ProcedureStatus.SUCCESS).Count();
        }

        internal void Record(ProcedureStatus result)
        {
            _index.Next();
            _statuses[_index.Value()] = result;
        }
        internal void RecordNested(ProcedureStatus resultNested)
        {
            _index.Down();
            _statuses[_index.Value()] = resultNested;
        }
    }
}
