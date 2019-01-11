using System;
using System.Collections.Generic;
using System.Linq;
using PlutoInsiders.Models;

namespace PlutoInsiders.Repository
{
    public class CefInsiderRepository : ICefInsiderRepository
    {
        CefInsiderEntities entities = new CefInsiderEntities();
        private const int DisplaySize = 10;

        public bool Add(CefInsider cefInsider)
        {
            try
            {
                entities.CefInsiders.Add(cefInsider);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CefInsider Find(int id)
        {
            return entities.CefInsiders.Find(id);
        }

        public List<CefInsider> FindAll()
        {
            return entities.CefInsiders.ToList();
        }

        public bool IsExistedRecordDate(Category DataType, string RecordDate)
        {
            return entities.CefInsiders.Where(c => c.DataType == (int)DataType && c.RecordDate == RecordDate).FirstOrDefault() != null;
        }

        public List<CefInsider> GetAllBuyWriteRecently()
        {
            return entities.CefInsiders.Where(c => c.DataType == (int)Category.BuyWriteSubIndex).OrderByDescending(c => c.RecordDate).Take(DisplaySize).OrderBy(c => c.RecordDate).ToList();
        }

        public double[] GetAverageBuyWriteRecently()
        {
            List<double> result = new List<double>();
            foreach (CefInsider item in GetAllBuyWriteRecently())
            {
                double avg = item.Average;
                result.Add(avg);
            }

            return result.ToArray();
        }

        public string[] GetDateBuyWriteRecently()
        {
            List<string> result = new List<string>();
            foreach (CefInsider item in GetAllBuyWriteRecently())
            {
                string _date = item.DisplayDate;
                result.Add(_date);
            }

            result.Add("...");

            return result.ToArray();
        }

        public List<CefInsider> GetAllTaxableBondRecently()
        {
            return entities.CefInsiders.Where(c => c.DataType == (int)Category.TaxableBondSubIndex).OrderByDescending(c => c.RecordDate).Take(DisplaySize).OrderBy(c => c.RecordDate).ToList();
        }

        public double[] GetAverageTaxableBondRecently()
        {
            List<double> result = new List<double>();
            foreach (CefInsider item in GetAllTaxableBondRecently())
            {
                double avg = item.Average;
                result.Add(avg);
            }

            return result.ToArray();
        }

        public string[] GetDateTaxableBondRecently()
        {
            List<string> result = new List<string>();
            foreach (CefInsider item in GetAllTaxableBondRecently())
            {
                string _date = item.DisplayDate;
                result.Add(_date);
            }

            result.Add("...");

            return result.ToArray();
        }

        public List<CefInsider> GetAllTaxFreeBondRecently()
        {
            return entities.CefInsiders.Where(c => c.DataType == (int)Category.TaxFreeBondSubIndex).OrderByDescending(c => c.RecordDate).Take(DisplaySize).OrderBy(c => c.RecordDate).ToList();
        }

        public double[] GetAverageTaxFreeBondRecently()
        {
            List<double> result = new List<double>();
            foreach (CefInsider item in GetAllTaxFreeBondRecently())
            {
                double avg = item.Average;
                result.Add(avg);
            }

            return result.ToArray();
        }

        public string[] GetDateTaxFreeBondRecently()
        {
            List<string> result = new List<string>();
            foreach (CefInsider item in GetAllTaxFreeBondRecently())
            {
                string _date = item.DisplayDate;
                result.Add(_date);
            }

            result.Add("...");

            return result.ToArray();
        }

        public List<CefInsider> GetAllForeignRecently()
        {
            return entities.CefInsiders.Where(c => c.DataType == (int)Category.ForeignSubIndex).OrderByDescending(c => c.RecordDate).Take(DisplaySize).OrderBy(c => c.RecordDate).ToList();
        }

        public double[] GetAverageForeignRecently()
        {
            List<double> result = new List<double>();
            foreach (CefInsider item in GetAllForeignRecently())
            {
                double avg = item.Average;
                result.Add(avg);
            }

            return result.ToArray();
        }

        public string[] GetDateForeignRecently()
        {
            List<string> result = new List<string>();
            foreach (CefInsider item in GetAllForeignRecently())
            {
                string _date = item.DisplayDate;
                result.Add(_date);
            }

            result.Add("...");

            return result.ToArray();
        }

        public List<CefInsider> GetAllDisplayDataEquityRecently()
        {
            return entities.CefInsiders.Where(c => c.DataType == (int)Category.EquitySubIndex).OrderByDescending(c => c.RecordDate).Take(DisplaySize).OrderBy(c => c.RecordDate).ToList();
        }

        public double[] GetAverageEquityRecently()
        {
            List<double> result = new List<double>();
            foreach (CefInsider item in GetAllDisplayDataEquityRecently())
            {
                double avg = item.Average;
                result.Add(avg);
            }

            return result.ToArray();
        }

        public string[] GetDateEquityRecently()
        {
            List<string> result = new List<string>();
            foreach (CefInsider item in GetAllDisplayDataEquityRecently())
            {
                string _date = item.DisplayDate;
                result.Add(_date);
            }

            result.Add("...");

            return result.ToArray();
        }

        public Category GetMaximumDisplayDate()
        {
            int countBuyWrite = entities.CefInsiders.Where(c => c.DataType == (int)Category.BuyWriteSubIndex).ToList().Count;
            int countTaxableBond = entities.CefInsiders.Where(c => c.DataType == (int)Category.TaxableBondSubIndex).ToList().Count;
            int countTaxFreeBond = entities.CefInsiders.Where(c => c.DataType == (int)Category.TaxFreeBondSubIndex).ToList().Count;
            int countForeign = entities.CefInsiders.Where(c => c.DataType == (int)Category.ForeignSubIndex).ToList().Count;
            int countEquity = entities.CefInsiders.Where(c => c.DataType == (int)Category.EquitySubIndex).ToList().Count;

            List<CountData> count = new List<CountData>()
            {
                new CountData() { Count=countBuyWrite, DataType=Category.BuyWriteSubIndex },
                new CountData() { Count=countTaxableBond, DataType=Category.TaxableBondSubIndex },
                new CountData() { Count=countTaxFreeBond, DataType=Category.TaxFreeBondSubIndex},
                new CountData() { Count=countForeign, DataType=Category.ForeignSubIndex },
                new CountData() { Count=countEquity, DataType=Category.EquitySubIndex }
            };

            return count.Where(c => c.Count == count.Max(m => m.Count)).FirstOrDefault().DataType;
        }

        public double[] GetAverageBuyWriteLastMonth()
        {
            List<double> result = new List<double>();
            foreach (CefInsider item in GetAllBuyWriteLastMonth())
            {
                double avg = item.Average;
                result.Add(avg);
            }

            return result.ToArray();
        }

        public string[] GetDateBuyWriteLastMonth()
        {
            List<string> result = new List<string>();
            foreach (CefInsider item in GetAllBuyWriteLastMonth())
            {
                string _date = item.DisplayDate;
                result.Add(_date);
            }

            result.Add("...");

            return result.ToArray();
        }

        public double[] GetAverageBuyWriteLastYear()
        {
            List<double> result = new List<double>();
            foreach (CefInsider item in GetAllBuyWriteLastYear())
            {
                double avg = item.Average;
                result.Add(avg);
            }

            return result.ToArray();
        }

        public string[] GetDateBuyWriteLastYear()
        {
            List<string> result = new List<string>();
            foreach (CefInsider item in GetAllBuyWriteLastYear())
            {
                string _date = item.DisplayDate;
                result.Add(_date);
            }

            result.Add("...");
            result.Add("...");
            result.Add("...");
            result.Add("...");
            result.Add("...");

            return result.ToArray();
        }

        public List<CefInsider> GetAllBuyWriteLastMonth()
        {
            return entities.CefInsiders.Where(c => c.DataType == (int)Category.BuyWriteSubIndex).OrderByDescending(c => c.RecordDate).Take(30).OrderBy(c => c.RecordDate).ToList();
        }

        public List<CefInsider> GetAllBuyWriteLastYear()
        {
            return entities.CefInsiders.Where(c => c.DataType == (int)Category.BuyWriteSubIndex).OrderBy(c => c.RecordDate).ToList();
        }

        public List<CefInsider> GetAllTaxableBondLastMonth()
        {
            return entities.CefInsiders.Where(c => c.DataType == (int)Category.TaxableBondSubIndex).OrderByDescending(c => c.RecordDate).Take(30).OrderBy(c => c.RecordDate).ToList();
        }

        public double[] GetAverageTaxableBondLastMonth()
        {
            List<double> result = new List<double>();
            foreach (CefInsider item in GetAllTaxableBondLastMonth())
            {
                double avg = item.Average;
                result.Add(avg);
            }
            return result.ToArray();
        }

        public string[] GetDateTaxableBondLastMonth()
        {
            List<string> result = new List<string>();
            foreach (CefInsider item in GetAllTaxableBondLastMonth())
            {
                string _date = item.DisplayDate;
                result.Add(_date);
            }
            result.Add("...");
            return result.ToArray();
        }

        public List<CefInsider> GetAllTaxableBondLastYear()
        {
            return entities.CefInsiders.Where(c => c.DataType == (int)Category.TaxableBondSubIndex).OrderBy(c => c.RecordDate).ToList();
        }

        public double[] GetAverageTaxableBondLastYear()
        {
            List<double> result = new List<double>();
            foreach (CefInsider item in GetAllTaxableBondLastYear())
            {
                double avg = item.Average;
                result.Add(avg);
            }
            return result.ToArray();
        }

        public string[] GetDateTaxableBondLastYear()
        {
            List<string> result = new List<string>();
            foreach (CefInsider item in GetAllTaxableBondLastYear())
            {
                string _date = item.DisplayDate;
                result.Add(_date);
            }
            result.Add("...");
            result.Add("...");
            result.Add("...");
            result.Add("...");
            result.Add("...");
            return result.ToArray();
        }

        public List<CefInsider> GetAllTaxFreeBondLastMonth()
        {
            return entities.CefInsiders.Where(c => c.DataType == (int)Category.TaxFreeBondSubIndex).OrderByDescending(c => c.RecordDate).Take(30).OrderBy(c => c.RecordDate).ToList();
        }

        public double[] GetAverageTaxFreeBondLastMonth()
        {
            List<double> result = new List<double>();
            foreach (CefInsider item in GetAllTaxFreeBondLastMonth())
            {
                double avg = item.Average;
                result.Add(avg);
            }
            return result.ToArray();
        }

        public string[] GetDateTaxFreeBondLastMonth()
        {
            List<string> result = new List<string>();
            foreach (CefInsider item in GetAllTaxFreeBondLastMonth())
            {
                string _date = item.DisplayDate;
                result.Add(_date);
            }
            result.Add("...");
            return result.ToArray();
        }

        public List<CefInsider> GetAllTaxFreeBondLastYear()
        {
            return entities.CefInsiders.Where(c => c.DataType == (int)Category.TaxFreeBondSubIndex).OrderBy(c => c.RecordDate).ToList();
        }

        public double[] GetAverageTaxFreeBondLastYear()
        {
            List<double> result = new List<double>();
            foreach (CefInsider item in GetAllTaxFreeBondLastYear())
            {
                double avg = item.Average;
                result.Add(avg);
            }
            return result.ToArray();
        }

        public string[] GetDateTaxFreeBondLastYear()
        {
            List<string> result = new List<string>();
            foreach (CefInsider item in GetAllTaxFreeBondLastYear())
            {
                string _date = item.DisplayDate;
                result.Add(_date);
            }
            result.Add("...");
            result.Add("...");
            result.Add("...");
            return result.ToArray();
        }

        public List<CefInsider> GetAllForeignLastMonth()
        {
            return entities.CefInsiders.Where(c => c.DataType == (int)Category.ForeignSubIndex).OrderByDescending(c => c.RecordDate).Take(30).OrderBy(c => c.RecordDate).ToList();
        }

        public double[] GetAverageForeignLastMonth()
        {
            List<double> result = new List<double>();
            foreach (CefInsider item in GetAllForeignLastMonth())
            {
                double avg = item.Average;
                result.Add(avg);
            }
            return result.ToArray();
        }

        public string[] GetDateForeignLastMonth()
        {
            List<string> result = new List<string>();
            foreach (CefInsider item in GetAllForeignLastMonth())
            {
                string _date = item.DisplayDate;
                result.Add(_date);
            }
            result.Add("...");
            return result.ToArray();
        }

        public List<CefInsider> GetAllForeignLastYear()
        {
            return entities.CefInsiders.Where(c => c.DataType == (int)Category.ForeignSubIndex).OrderBy(c => c.RecordDate).ToList();
        }

        public double[] GetAverageForeignLastYear()
        {
            List<double> result = new List<double>();
            foreach (CefInsider item in GetAllForeignLastYear())
            {
                double avg = item.Average;
                result.Add(avg);
            }
            return result.ToArray();
        }

        public string[] GetDateForeignLastYear()
        {
            List<string> result = new List<string>();
            foreach (CefInsider item in GetAllForeignLastYear())
            {
                string _date = item.DisplayDate;
                result.Add(_date);
            }
            result.Add("...");
            result.Add("...");
            result.Add("...");
            return result.ToArray();
        }

        public List<CefInsider> GetAllEquityLastMonth()
        {
            return entities.CefInsiders.Where(c => c.DataType == (int)Category.EquitySubIndex).OrderByDescending(c => c.RecordDate).Take(30).OrderBy(c => c.RecordDate).ToList();
        }

        public double[] GetAverageEquityLastMonth()
        {
            List<double> result = new List<double>();
            foreach (CefInsider item in GetAllEquityLastMonth())
            {
                double avg = item.Average;
                result.Add(avg);
            }
            return result.ToArray();
        }

        public string[] GetDateEquityLastMonth()
        {
            List<string> result = new List<string>();
            foreach (CefInsider item in GetAllEquityLastMonth())
            {
                string _date = item.DisplayDate;
                result.Add(_date);
            }
            result.Add("...");
            return result.ToArray();
        }

        public List<CefInsider> GetAllEquityLastYear()
        {
            return entities.CefInsiders.Where(c => c.DataType == (int)Category.EquitySubIndex).OrderBy(c => c.RecordDate).ToList();
        }

        public double[] GetAverageEquityLastYear()
        {
            List<double> result = new List<double>();
            foreach (CefInsider item in GetAllEquityLastYear())
            {
                double avg = item.Average;
                result.Add(avg);
            }
            return result.ToArray();
        }

        public string[] GetDateEquityLastYear()
        {
            List<string> result = new List<string>();
            foreach (CefInsider item in GetAllEquityLastYear())
            {
                string _date = item.DisplayDate;
                result.Add(_date);
            }
            result.Add("...");
            result.Add("...");
            result.Add("...");
            return result.ToArray();
        }
    }
}

class CountData
{
    public Category DataType { get; set; }
    public int Count { get; set; }
}