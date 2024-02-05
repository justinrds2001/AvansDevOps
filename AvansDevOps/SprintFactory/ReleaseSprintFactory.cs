﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintFactory
{
    public class ReleaseSprintFactory : SprintFactory
    {
        public Sprint CreateSprint()
        {
            return new ReleaseSprint { };
        }
    }
}
