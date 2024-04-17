
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
               switch(procedure._successfulTask.Execute())
                {
                    case ProcedureStatus.SUCCESS: 
                        procedure.CurrentState = new Success();
                        return ProcedureStatus.SUCCESS;
                    case ProcedureStatus.FAILURE:
                        procedure.CurrentState = new Failed();
                        return ProcedureStatus.FAILURE;
                    case ProcedureStatus.SUSPEND:
                        throw new NotImplementedException();
                    default: throw new NotImplementedException();
                }  
            }
        }

        private class Success : State
        {
            public ProcedureStatus Execute(SimpleProcedure procedure)
            {
                return ProcedureStatus.SUCCESS;
            }
        }
        private class Failed : State
        {
            public ProcedureStatus Execute(SimpleProcedure procedure)
            {
                throw new InvalidOperationException("Procedure has already failed");
            }
        }
    }
}
