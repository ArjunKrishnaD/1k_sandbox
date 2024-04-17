using System;
using Engine.Procedures;
using Xunit;
// ReSharper disable RedundantDefaultMemberInitializer

namespace Engine.Tests.Unit
{
    public class SimpleProcedureTest
    {
        [Fact]
        public void Success()
        {
            var task = new TestTask(ProcedureStatus.SUCCESS);
            SimpleProcedure procedure = new SimpleProcedure(task);
            Assert.Equal(ProcedureStatus.SUCCESS, procedure.Execute());
            Assert.Equal(1,task.ExecutedCount);
            Assert.Equal(0,task.FailedCount);
            Assert.Equal(ProcedureStatus.SUCCESS,procedure.Execute());
            Assert.Equal(1, task.ExecutedCount);
            Assert.Equal(0, task.FailedCount);
        }

        [Fact]
        public void Failure()
        {
            var task = new TestTask( ProcedureStatus.FAILURE);
            SimpleProcedure procedure = new SimpleProcedure(task);
            Assert.Equal(ProcedureStatus.FAILURE, procedure.Execute());
            Assert.Equal(0, task.ExecutedCount);
            Assert.Equal(1, task.FailedCount);
            Assert.Throws<InvalidOperationException>(() => procedure.Execute());
        }

        [Fact]
        public void Suspension()
        {
            var task = new TestTask(ProcedureStatus.SUSPEND);
            SimpleProcedure procedure = new SimpleProcedure(task);
            Assert.Equal(ProcedureStatus.SUSPEND, procedure.Execute());
            Assert.Equal(0, task.ExecutedCount);
            Assert.Equal(0, task.FailedCount);
            Assert.Equal(1, task.SuspendCount);
            Assert.Equal(ProcedureStatus.SUSPEND, procedure.Execute());
            Assert.Equal(0, task.ExecutedCount);
            Assert.Equal(0, task.FailedCount);
            Assert.Equal(2, task.SuspendCount);
        }   

    }
}
