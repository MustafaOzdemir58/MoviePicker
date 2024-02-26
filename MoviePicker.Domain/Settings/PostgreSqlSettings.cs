using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker.Domain.Settings
{
    public class PostgreSqlSettings
    {
        public string ConnectionString { get; set; }
        public string DbName { get; set; }
    }
}
