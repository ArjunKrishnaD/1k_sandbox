
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
