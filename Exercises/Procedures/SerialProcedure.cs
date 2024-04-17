using System;
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

        public ProcedureStatus Execute()
        {
            switch (procedures.First().Execute())
            {
                case ProcedureStatus.FAILURE: 
                    return ProcedureStatus.FAILURE;
                case ProcedureStatus.SUSPEND:
                    return ProcedureStatus.SUSPEND;
                case ProcedureStatus.SUCCESS:
                    if (procedures.Count() == 1)
                        return ProcedureStatus.SUCCESS;
                    switch( new SerialProcedure(procedures.Skip(1).ToList()).Execute())
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
    }
}
