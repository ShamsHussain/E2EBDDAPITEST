using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowBddFramework.Helpers
{
    public class Helper
    {
        public string ReturnFromDate()
        {
            DateTime fromDate = DateTime.UtcNow;
            return fromDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
        }

        public string ReturnToDate()
        {
            DateTime toDate = DateTime.UtcNow;
            toDate = toDate.AddDays(7);
            return toDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
        }

        public string ReturnThuFrmDate()
        {
            var fromDate = DateTime.UtcNow;
            bool isFinished = fromDate.DayOfWeek == DayOfWeek.Thursday;
            int counter = 0;

            do
            {
                if (!isFinished)
                    fromDate.AddDays(counter);
                counter++;
            }
            while (!isFinished);
            return fromDate.ToString("yyyy'-'MM'-'dd'T'09':'00':'ss'.'fff'Z'");
        }

        public string ReturnThuToDate()
        {
            var fromdate = ReturnThuFrmDate();
            DateTime myDate = DateTime.Parse(fromdate).AddDays(1);
            return myDate.ToString("yyyy'-'MM'-'dd'T'11':'00':'ss'.'fff'Z'");
        }

        public string? QueryBuilder(Table table)
        {
            var list = table.Rows[0]
                 .Where(o => !string.IsNullOrEmpty(o.Value.ToString()))
                 .Select(o => $"{o.Key}={o.Value}")
                 .ToList();

            return list.Any()
               ? $"?{string.Join('&', list)}"
               : null;
        }
    }
}
