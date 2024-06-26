﻿
namespace Engine.Procedures
{
    public class SimpleProcedure:Procedure
    {
        private readonly ProcedureTask _successfulTask;
        private State CurrentState = new Ready();  
        public SimpleProcedure(ProcedureTask procedureTask,ProcedureTask undoTask) 
        {
            _successfulTask = procedureTask;
        }

        public SimpleProcedure(ProcedureTask procedureTask):this(procedureTask,EmptyTask.Instance)
        {
           
        }
        public ProcedureStatus Execute(ProcedureLog log)
        {
            ProcedureStatus result = CurrentState.Execute(this);
            log.Record(result);
            return result;
        }

        public ProcedureStatus Undo(ProcedureLog log)
        {
            throw new NotImplementedException();
        }

        private interface State
        {
            public ProcedureStatus Execute(SimpleProcedure procedure);
           
        }
        
        private class Ready : State
        {
            public ProcedureStatus Execute(SimpleProcedure procedure)
            {
               switch(procedure._successfulTask.Execute())
                {
                    case ProcedureStatus.SUCCESS: 
                        procedure.CurrentState = new Succeeded();
                        return ProcedureStatus.SUCCESS;
                    case ProcedureStatus.FAILURE:
                        procedure.CurrentState = new Failed();
                        return ProcedureStatus.FAILURE;
                    case ProcedureStatus.SUSPEND:
                        return ProcedureStatus.SUSPEND;
                    default: throw new NotImplementedException();
                }  
            }
        }

        private class Succeeded : State
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
