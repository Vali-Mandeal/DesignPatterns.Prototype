using System.Collections.Generic;
using DesignPatterns.Prototype.UserPrototype.Concrete;

namespace DesignPatterns.Prototype.UserPrototype
{
    /// <summary>
    /// Type-safe prototype manager
    /// </summary>
    class UsersManager
    {
        private readonly Dictionary<UserType, User> _users = new();

        // Gets or sets users
        public User this[UserType type]
        {   
            get => _users[type];   
            set => _users.Add(type, value);
        }
    }
}
