using Engine.Procedures;
using System.Collections.Generic;
using Xunit;

namespace Engine.Tests.Unit
{
    public class MultipleProcudureTest
    {
        [Fact]
        public void Success()
        {
            var log = new ProcedureLog();
            SerialProcedure procedure = new SerialProcedure(new List<Procedure>()
                {
                    new SimpleProcedure(new TestTask(ProcedureStatus.SUCCESS)),
                    new MultipleProcedures(new List<ProcedureStatus>{ProcedureStatus.SUCCESS, ProcedureStatus.SUCCESS, ProcedureStatus.SUCCESS}),
                    new SimpleProcedure(new TestTask(ProcedureStatus.SUCCESS)),
                });
            Assert.Equal(ProcedureStatus.SUCCESS, procedure.Execute(log));
            Assert.Equal(5, log.SuccessCount());
        }
    }
}
