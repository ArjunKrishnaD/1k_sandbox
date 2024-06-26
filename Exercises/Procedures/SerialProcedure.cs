﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Procedures
{
    public class SerialProcedure : Procedure
    {
        private List<Procedure> procedures;

        public SerialProcedure(List<Procedure> procedures)
        {
            this.procedures = procedures;
        }
        public ProcedureStatus Execute(ProcedureLog log)
        {
            log.Down();
            var result = RecursiveExecute(log);
            log.Up();
            return result;
        }
        private ProcedureStatus RecursiveExecute(ProcedureLog log)
        {
            switch (procedures.First().Execute(log))
            {
                case ProcedureStatus.FAILURE: 
                    return ProcedureStatus.FAILURE;
                case ProcedureStatus.SUSPEND:
                    return ProcedureStatus.SUSPEND;
                case ProcedureStatus.SUCCESS:
                    if (procedures.Count() == 1)
                        return ProcedureStatus.SUCCESS;
                    switch( new SerialProcedure(procedures.Skip(1).ToList()).RecursiveExecute(log))
                    {
                        case ProcedureStatus.SUCCESS:
                            return ProcedureStatus.SUCCESS;
                        case ProcedureStatus.FAILURE:
                            return ProcedureStatus.FAILURE;
                        case ProcedureStatus.SUSPEND:
                            return ProcedureStatus.SUSPEND;
                        default: throw new NotImplementedException();
                    }
                default: throw new NotImplementedException();
            }
        }

        public ProcedureStatus Undo(ProcedureLog log)
        {
            throw new NotImplementedException();
        }
    }
}
