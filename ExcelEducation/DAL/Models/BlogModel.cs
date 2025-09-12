using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace DAL.Models
{
    public class BlogModel
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public string BlogDate { get; set; }
        public string BlogDescription { get; set; }
        public string BlogPhoto { get; set; }
        [Computed]
        public List<PagePhotos> PagePhotos { get; set; } = new List<PagePhotos>();

        [Computed]
        public List<PageFiles> PageFiles { get; set; } = new List<PageFiles>();
    }
}
