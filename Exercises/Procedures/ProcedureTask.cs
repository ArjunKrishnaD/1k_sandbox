using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Procedures
{
    public interface Procedure
    {
        ProcedureStatus Execute(ProcedureLog log);
        ProcedureStatus Undo(ProcedureLog log);
    }

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
    public class EmptyTask : ProcedureTask
    {
        private EmptyTask() { }
        public static EmptyTask Instance = new EmptyTask();
        public ProcedureStatus Execute()
        {
            return ProcedureStatus.SUCCESS;
        }
    }
}
