using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Novel.Domain.Data
{
    public interface INovelDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
