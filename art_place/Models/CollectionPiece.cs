using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace art_place.Models
{
    public class CollectionPiece
    {
        public int Id { get; set; }
        public int PieceId { get; set; }
        public int CollectionId { get; set; }
    }
}