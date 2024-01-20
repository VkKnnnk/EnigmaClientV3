using EnigmaClientV3.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaClientV3.Model
{
    public static class AppSession
    {
        private static compclub_dbContext _context;
        public static compclub_dbContext Context
        {
            get
            {
                if (_context is null)
                    _context = new compclub_dbContext();
                return _context;
            }
        }
    }
}
