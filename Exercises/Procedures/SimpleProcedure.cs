using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Procedures
{
    public class SimpleProcedure
    {
        private readonly ProcedureTask _successfulTask;

        public SimpleProcedure(ProcedureTask procedureTask)
        {
            _successfulTask = procedureTask;
        }

        public ProcedureStatus Execute()
        {
            return _successfulTask.Execute();
        }

    }
}
