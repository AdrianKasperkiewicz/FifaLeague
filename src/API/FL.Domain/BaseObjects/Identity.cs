using System;
using System.Collections.Generic;
using System.Text;

namespace FL.Domain.BaseObjects
{
    public class Identity
    {
        public Identity()
        {
            this.Value = Guid.NewGuid();
        }

        public Guid Value { get; }
    }
}