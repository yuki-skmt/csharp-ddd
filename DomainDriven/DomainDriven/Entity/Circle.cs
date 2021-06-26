using System;
using System.Collections.Generic;

namespace DomainDriven.Entity
{
    public class Circle
    {
        private readonly CircleId id;
        private User owner;
        private List<User> members;

        public Circle(CircleId id, CircleName name,
            User owner, List<User> members)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (members == null)
            {
                throw new ArgumentNullException(nameof(members));
            }
            Id = id;
            Name = name;
            Owner = owner;
            Members = members;
        }

        public CircleId Id { get; }
        public CircleName Name { get; private set; }
        public User Owner { get; private set; }
        public List<User> Members { get; private set; }

        public void Join(User member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }
            if (IsFull())
            {
                throw new Exception("サークルが満員です。");
            }
            members.Add(member);
        }

        private bool IsFull()
        {
            return members.Count >= 29;
        }
    }

    public class CircleId
    {
        public CircleId(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            Value = value;
        }
        public string Value { get; }
    }

    public class CircleName : IEquatable<CircleName>
    {
        public CircleName(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (value.Length < 3)
            {
                throw new ArgumentException("サークル名は3文字以上です", 
                    nameof(value));
            }
            if (value.Length > 20)
            {
                throw new ArgumentException("サークル名は20文字以下です",
                    nameof(value));
            }
            Value = value;
        }
        public string Value { get; }

        public bool Equals(CircleName other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return false;
            }
            return string.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return false;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((CircleName)obj);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }
    }
}
