using System;
using Newtonsoft.Json;

namespace DesignPatterns.Prototype.UserPrototype.Concrete
{
    /// <summary>
    /// The 'ConcretePrototype' class
    /// </summary>
    [Serializable]
    public class User : ICloneable
    {
        public string Name { get; set; }    
        public Role Role { get; set; }

        // In a real life scenario, you won't use a shallow clone method
        // This is just for demonstration purposes
        public object Clone()
        {
            return MemberwiseClone();
        }

        // I used serialization to achieve a deep clone
        // However, the deep clone can be achieved with new operator and constructor calls
        public object DeepClone()
        {
            var objectAsJson = JsonConvert.SerializeObject(this);

            var copy = JsonConvert.DeserializeObject<User>(objectAsJson);

            return copy;
        }
    }
}
