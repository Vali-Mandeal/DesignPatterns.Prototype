using System;
using System.Collections.Generic;
using DesignPatterns.Prototype.UserPrototype;
using DesignPatterns.Prototype.UserPrototype.Concrete;

namespace DesignPatterns.Prototype
{
    class Program
    {
        private static UsersManager _usersManager;
        private static  Dictionary<UserType, User> _clones;

        static void Main()  
        {
            _usersManager = new UsersManager();
            _clones = new Dictionary<UserType, User>();

            InitializeUsers();
            InitializeClones();

            CompareOriginalsWithClones();
        }

        private static void InitializeUsers()
        {
            _usersManager[UserType.Normal] = new User {Name = "Derp", Role = new Role {Name = "Normal"}};
            _usersManager[UserType.Admin] = new User {Name = "Derpina", Role = new Role {Name = "Admin"}};
        }

        private static void InitializeClones()
        {
            _clones[UserType.Normal] = _usersManager[UserType.Normal].Clone() as User;
            _clones[UserType.Admin] = _usersManager[UserType.Admin].DeepClone() as User;
        }

        private static void CompareOriginalsWithClones()
        {
            Console.WriteLine("Applying shallow clone on normal user.");

            var areHashKeysIdentical = AreRoleHashKeysIdentical(_usersManager[UserType.Normal], _clones[UserType.Normal]);
            if (areHashKeysIdentical)
            {
                Console.WriteLine(@$"When shallow cloning an object, its reference types are not being copied, but rather referenced.
Normal user role hash: {_usersManager[UserType.Normal].Role.GetHashCode()}
Its clone role hash: {_clones[UserType.Normal].Role.GetHashCode()}");
            }
            else
            {
                Console.WriteLine("Oops, something went wrong.");
            }


            Console.WriteLine("\nApplying deep clone on admin user.");

            areHashKeysIdentical = AreRoleHashKeysIdentical(_usersManager[UserType.Admin], _clones[UserType.Admin]);
            if (areHashKeysIdentical)
            {
                Console.WriteLine("Oops, something went wrong.");
            }
            else
            {
                Console.WriteLine(@$"When deep cloning an object, its reference types are being copied, not referenced.
Admin user role hash: {_usersManager[UserType.Admin].Role.GetHashCode()}
Its clone role hash: {_clones[UserType.Admin].Role.GetHashCode()}");
            }
        }

        private static bool AreRoleHashKeysIdentical(User original, User clone)
        {
            return original.Role.GetHashCode() == clone.Role.GetHashCode();
        }

        public User this[UserType type]
        {
            get => _clones[type];
            set => _clones.Add(type, value);
        }
    }
}
