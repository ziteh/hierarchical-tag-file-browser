using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagBaseFileBrowser.IO
{
    public interface IObjDatabaseIO
    {
        List<Obj> Read(string path);
    }
}