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
                switch (_status)
                {
                    case ProcedureStatus.SUCCESS:
                        Executed = true;
                        break;
                    case ProcedureStatus.FAILURE:
                        Failed = true;
                        break;
                    case ProcedureStatus.SUSPEND:
                        throw new NotImplementedException();
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                return _status;
            }

        }

    }
}
