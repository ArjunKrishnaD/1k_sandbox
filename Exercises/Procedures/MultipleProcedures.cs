namespace Engine.Procedures
{
    public class MultipleProcedures : Procedure
    {
        private readonly List<ProcedureStatus> _procedures = new List<ProcedureStatus>();
        public MultipleProcedures(List<ProcedureStatus> procedureTasks)
        {
            _procedures = procedureTasks;
        }
        public ProcedureStatus Execute(ProcedureLog log)
        {
            foreach (ProcedureStatus task in _procedures)
            {
                switch (task)
                {
                    case ProcedureStatus.SUCCESS:
                        log.RecordNested(task);
                        break;
                    case ProcedureStatus.FAILURE:
                        return ProcedureStatus.FAILURE;
                    case ProcedureStatus.SUSPEND:
                        return ProcedureStatus.SUSPEND;
                    default: throw new NotImplementedException();
                }
            }
            return ProcedureStatus.SUCCESS;
        }

    }
}
