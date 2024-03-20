using AvansDevOps.Observer.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps
{
    public class Activity
    {
        public Developer? Developer { get; set; }
        public string Task { get; set; } = string.Empty;
    }
}
