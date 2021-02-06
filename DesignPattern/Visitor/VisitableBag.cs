using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Visitor
{
    public class VisitableBag
    {
        private List<IVisitable> _lstElements;

        public VisitableBag(List<IVisitable> lst)
        {
            _lstElements = lst;
        }

        public void RemoveElement(IVisitable element)
        {
            _lstElements.Remove(element);
        }

        public void AddElement(IVisitable element)
        {
            _lstElements.Add(element);
        }

        public void ApplyVisitor(IVisitor visitor)
        {
            foreach(var element in _lstElements)
            {
                element.Accept(visitor);
            }
        }
    }
}
