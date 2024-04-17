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
            foreach (Procedure procedure in procedures)
            {
                procedure.Execute();
            }
            return ProcedureStatus.SUCCESS;
        }
    }
}
