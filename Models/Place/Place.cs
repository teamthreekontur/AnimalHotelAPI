using System;

namespace Models.Place
{
    class Place
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Guid IdOwner { get; set; }
    }
}
