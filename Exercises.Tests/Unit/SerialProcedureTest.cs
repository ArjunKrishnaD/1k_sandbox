using Engine.Procedures;
using System.Collections.Generic;
using Xunit;

namespace Engine.Tests.Unit
{
    public class SerialProcedureTest
    {
        [Fact]
        public void Success()
        {
            SerialProcedure procedure = new SerialProcedure(new List<Procedure>()
            {
                new SimpleProcedure(new TestTask(ProcedureStatus.SUCCESS)),
                new SimpleProcedure(new TestTask(ProcedureStatus.SUCCESS)),
            });
            Assert.Equal(ProcedureStatus.SUCCESS, procedure.Execute());           
        } 
    }
}
