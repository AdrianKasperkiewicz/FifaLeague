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

        public Identity(Guid id)
        {
            this.Value = id;
        }

        public Guid Value { get; }
    }
}