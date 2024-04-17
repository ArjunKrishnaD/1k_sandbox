
namespace Engine.Procedures
{
    public class SimpleProcedure
    {
        private readonly ProcedureTask _successfulTask;
        private State CurrentState = new Initial();  
        public SimpleProcedure(ProcedureTask procedureTask)
        {
            _successfulTask = procedureTask;
        }

        public ProcedureStatus Execute()
        {
            return CurrentState.Execute(this);
        }
        private interface State
        {
            public ProcedureStatus Execute(SimpleProcedure procedure);
           
        }
        
        private class Initial : State
        {
            public ProcedureStatus Execute(SimpleProcedure procedure)
            {
               procedure.CurrentState = new Success();
               return procedure._successfulTask.Execute();  
            }
        }

        private class Success : State
        {
            public ProcedureStatus Execute(SimpleProcedure procedure)
            {
                return ProcedureStatus.SUCCESS;
            }
        }
    }
}
