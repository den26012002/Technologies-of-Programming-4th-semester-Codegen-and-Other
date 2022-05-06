using Cats.Server;

namespace Cats.Entities
{
    public class Cat
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Color Color { get; set; }

        public int OwnerId { get; set; }

        public System.Collections.Generic.List<int?> FriendIds { get; set; }
    }

    ;
}

;