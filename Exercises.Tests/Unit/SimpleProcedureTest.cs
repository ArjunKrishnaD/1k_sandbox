using Engine.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Engine.Tests.Unit
{
    public class SimpleProcedureTest
    {
        [Fact]
        public void Success()
        {
            Assert.Equal(ProcedureStatus.SUCCESS, new SimpleProcedure(new TestTask(ProcedureStatus.SUCCESS)).Execute());
        }

        [Fact]
        public void Failure()
        {
            Assert.Equal(ProcedureStatus.FAILURE, new SimpleProcedure(new TestTask( ProcedureStatus.FAILURE)).Execute());
        }

        internal class TestTask : ProcedureTask
        {
            private readonly ProcedureStatus _status;

            internal TestTask(ProcedureStatus status)
            {
                _status = status;
            }

            public ProcedureStatus Execute()
            {
                return _status;
            }

        }

    }
}
