﻿using Engine.Procedures;
using System;

namespace Engine.Tests.Unit
{
    internal class TestTask : ProcedureTask
    {
        private readonly ProcedureStatus _status;
        internal int ExecutedCount = 0;
        internal int FailedCount = 0;
        internal int SuspendCount = 0;


        internal TestTask(ProcedureStatus status)
        {
            _status = status;
        }

        public ProcedureStatus Execute()
        {
            switch (_status)
            {
                case ProcedureStatus.SUCCESS:
                    ExecutedCount += 1;
                    break;
                case ProcedureStatus.FAILURE:
                    FailedCount += 1;
                    break;
                case ProcedureStatus.SUSPEND:
                    SuspendCount += 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return _status;
        }

    }
}
