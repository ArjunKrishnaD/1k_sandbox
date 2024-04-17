using Engine.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Engine.Tests.Unit
{
    public class SimpleProcedureTest
    {
        [Fact]
        public void Success()
        {
            var task = new TestTask(ProcedureStatus.SUCCESS);
            Assert.Equal(ProcedureStatus.SUCCESS, new SimpleProcedure(task).Execute());
            Assert.True(task.Executed);
            Assert.False(task.Failed);
        }

        [Fact]
        public void Failure()
        {
            var task = new TestTask( ProcedureStatus.FAILURE);
            Assert.Equal(ProcedureStatus.FAILURE, new SimpleProcedure(task).Execute());
            Assert.False(task.Executed);
            Assert.True(task.Failed);
        }

        internal class TestTask : ProcedureTask
        {
            private readonly ProcedureStatus _status;
            internal bool Executed = false;
            internal bool Failed = false;
            internal TestTask(ProcedureStatus status)
            {
                _status = status;
            }

            public ProcedureStatus Execute()
            {
                if (_status == ProcedureStatus.SUCCESS) Executed = true;
                if (_status == ProcedureStatus.FAILURE) Failed = true;
                return _status;
            }

        }

    }
}
