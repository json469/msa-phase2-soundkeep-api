using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundKeepAPI.Models
{
    public class TrackItem
    {
        public int ID { get; set; }
        public string TrackID { get; set; }
        public string TrackURL { get; set; }
        public string ArtworkURL { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public string DateAdded { get; set; }
    }
}
