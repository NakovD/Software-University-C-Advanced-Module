using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Contracts
{
    public interface IMission
    {
        public string CodeName { get; }

        public string State { get; }

        void CompleteMission();
    }
}
