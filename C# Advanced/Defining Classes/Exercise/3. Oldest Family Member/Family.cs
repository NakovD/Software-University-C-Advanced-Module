using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members;

        public List<Person> Members
        {
            get { return members; }
            set { members = value; }
        }

        public Family()
        {
            this.Members = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.Members.Add(member);
        }

        public Person GetOldestMember()
        {
            var sortedMembers = this.Members.OrderByDescending(p => p.Age).ToList();
            var oldest = sortedMembers[0];

            return oldest;
        }
    }
}
