using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models.Models
{
    public class ImageStorage
    {
        public ImageStorage(Guid id, string path)
        {
            Id = id;
            Path = path;
        }

        public Guid Id { get; set; }
        public string Path { get; set; }
    }
}
