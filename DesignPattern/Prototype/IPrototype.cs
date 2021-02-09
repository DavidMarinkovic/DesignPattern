using System.Collections.Generic;

namespace DesignPattern.Prototype
{
    public interface IPrototype
    {
        public IPrototype Clone();
    }

    public class PrototypeManager
    {
        private Dictionary<string, IPrototype> _dic = new Dictionary<string, IPrototype>();

        public IPrototype this[string key]
        {
            get
            {
                return _dic[key];
            }

            set
            {
                if (!_dic.ContainsKey(key))
                    _dic.Add(key, value);
            }
        }
    }
}
