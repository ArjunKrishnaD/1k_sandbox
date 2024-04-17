using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Procedures
{
    public interface ProcedureTask
    {
        ProcedureStatus Execute();
    }

    public enum ProcedureStatus
    {
        SUCCESS,
        FAILURE,
        SUSPEND
    }
}
