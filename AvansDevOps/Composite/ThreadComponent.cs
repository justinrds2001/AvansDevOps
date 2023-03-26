using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Composite
{
    public abstract class ThreadComponent
    {
        // content string property
        public string Content { get; set; }

        public ThreadComponent(string content)
        {
            Content = content;
        }

        public string GetContent()
        {
            return Content;
        }
    }
}