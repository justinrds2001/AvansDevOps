using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintState
{
    public interface ISprintState
    {
        public void ChangeName(string name);
        public void ChangeStartDate(DateTime startDate);
        public void ChangeEndDate(DateTime endDate);
    }
}
