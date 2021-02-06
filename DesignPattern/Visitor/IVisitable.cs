using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Visitor
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}
