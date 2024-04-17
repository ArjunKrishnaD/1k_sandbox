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
            Assert.Equal(ProcedureStatus.FAILURE, new SimpleProcedure(task).Execute());
            Assert.Equal(0, task.ExecutedCount);
            Assert.Equal(1, task.FailedCount);
        }

        internal class TestTask : ProcedureTask
        {
            private readonly ProcedureStatus _status;
            internal int ExecutedCount = 0;
            internal int FailedCount = 0;

            internal TestTask(ProcedureStatus status)
            {
                _status = status;
            }

            public ProcedureStatus Execute()
            {
                switch (_status)
                {
                    case ProcedureStatus.SUCCESS:
                        ExecutedCount+=1;
                        break;
                    case ProcedureStatus.FAILURE:
                        FailedCount+=1;
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
