using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AttendanceDAO
    {
        private static readonly object InstanceLock = new object();
        private static AttendanceDAO instance = null;

        public static AttendanceDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AttendanceDAO();
                    }
                    return instance;
                }
            }
        }

    }
}
