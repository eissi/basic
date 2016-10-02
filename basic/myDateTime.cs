using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic
{
    class myDateTime
    {
        public static void Test()
        {
            DateTime now = DateTime.Now;

            Console.Write(@"datetime.now.tostring(yyyyMMddHHMMss) ->");
            Console.WriteLine("{0}",now.ToString("yyyyMMddHHMMss"));
            
            Console.WriteLine(now);
            Console.WriteLine(now.ToUniversalTime());
            Console.WriteLine(now.ToString("s"));
            //Stream analytics type
            Console.WriteLine(now.ToUniversalTime().ToString("O"));
            Console.WriteLine(now.Kind);

            Console.WriteLine("'d' standard format string:");
            foreach (var customString in DateTimeFormatInfo.CurrentInfo.GetAllDateTimePatterns('d'))
                Console.WriteLine("   {0}", customString);

            DateTime dat = new DateTime(2009, 6, 15, 13, 45, 30,
                            DateTimeKind.Unspecified);
            Console.WriteLine("{0} ({1}) --> {0:O}", dat, dat.Kind);

            DateTime uDat = new DateTime(2009, 6, 15, 13, 45, 30,
                                         DateTimeKind.Utc);
            Console.WriteLine("{0} ({1}) --> {0:O}", uDat, uDat.Kind);

            DateTime lDat = new DateTime(2009, 6, 15, 13, 45, 30,
                                         DateTimeKind.Local);
            Console.WriteLine("{0} ({1}) --> {0:O}\n", lDat, lDat.Kind);

            DateTimeOffset dto = new DateTimeOffset(lDat);
            Console.WriteLine("{0} --> {0:O}", dto);
        }
    }
}
