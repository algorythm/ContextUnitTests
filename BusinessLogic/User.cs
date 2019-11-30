using System;

namespace ContextUnitTests.BusinessLogic
{
    public class User
    {
        public User() { }

        public User(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}
