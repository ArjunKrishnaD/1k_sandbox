using Engine.Procedures;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Collections.Generic;
using Xunit;

namespace Engine.Tests.Unit
{
    public class SerialProcedureTest
    {
        [Fact]
        public void Success()
        {
            var log = new ProcedureLog();
            SerialProcedure procedure = new SerialProcedure(new List<Procedure>()
            {
                new SimpleProcedure(new TestTask(ProcedureStatus.SUCCESS)),
                new SimpleProcedure(new TestTask(ProcedureStatus.SUCCESS)),
            });
            Assert.Equal(ProcedureStatus.SUCCESS, procedure.Execute(log));
            Assert.Equal(2, log.SuccessCount());
        }
        [Fact]
        public void SecondProcedureFails()
        {
            var log = new ProcedureLog();
            SerialProcedure procedure = new SerialProcedure(new List<Procedure>()
            {
                new SimpleProcedure(new TestTask(ProcedureStatus.SUCCESS)),
                new SimpleProcedure(new TestTask(ProcedureStatus.FAILURE)),
            });
            Assert.Equal(ProcedureStatus.FAILURE, procedure.Execute(log));
        }
    }
}
