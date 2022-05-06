using Cats.Server;

namespace Cats.Entities
{
    public class CatsOwner
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public System.Collections.Generic.List<int?> CatIds { get; set; }
    }

    ;
}

;