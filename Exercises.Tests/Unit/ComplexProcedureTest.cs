using Engine.Procedures;
using System.Collections.Generic;
using Xunit;

namespace Engine.Tests.Unit
{
    public class ComplexProcedureTest
    {
        [Fact]
        public void Success()
        {
            var log = new ProcedureLog();
            SerialProcedure procedure = new SerialProcedure(new List<Procedure>()
                {
                    new SimpleProcedure(new TestTask(ProcedureStatus.SUCCESS)),
                    new SerialProcedure(new List<Procedure>{ 
                        new SimpleProcedure(new TestTask(ProcedureStatus.SUCCESS)),
                        new SimpleProcedure(new TestTask(ProcedureStatus.FAILURE)),
                        new SimpleProcedure(new TestTask(ProcedureStatus.SUCCESS))
                    }),
                    new SimpleProcedure(new TestTask(ProcedureStatus.SUCCESS)),
                });
            Assert.Equal(ProcedureStatus.FAILURE, procedure.Execute(log));
            Assert.Equal(2, log.SuccessCount());

        }
    }
}
