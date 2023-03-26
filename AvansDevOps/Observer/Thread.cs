using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Observer
{
    public class Thread : Publisher
    {
        // content string property
        public string Content { get; set; }

        public Thread(string content)
        {
            Content = content;
        }

        public string GetContent()
        {
            return Content;
        }
    }
}
