﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Contracts
{
    public interface ISoldier
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string Id { get; }
    }
}
