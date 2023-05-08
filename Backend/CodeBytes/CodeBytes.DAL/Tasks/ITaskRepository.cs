using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.DAL.Tasks
{
    interface ITaskRepository
    {
        void Save(TaskEntity entity);

        TaskEntity Get(int id);
    }
}
