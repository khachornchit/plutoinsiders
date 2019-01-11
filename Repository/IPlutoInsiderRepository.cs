using System.Collections.Generic;
using PlutoInsiders.Models;

namespace PlutoInsiders.Repository
{
    public interface ICefInsiderRepository
    {
        List<CefInsider> FindAll();
        CefInsider Find(int id);
        bool Add(CefInsider cefInsider);
        bool IsExistedRecordDate(Category DataType, string RecordDate);

        List<CefInsider> GetAllBuyWriteRecently();
        double[] GetAverageBuyWriteRecently();
        string[] GetDateBuyWriteRecently();
        List<CefInsider> GetAllBuyWriteLastMonth();
        double[] GetAverageBuyWriteLastMonth();
        string[] GetDateBuyWriteLastMonth();
        List<CefInsider> GetAllBuyWriteLastYear();
        double[] GetAverageBuyWriteLastYear();
        string[] GetDateBuyWriteLastYear();

        List<CefInsider> GetAllTaxableBondRecently();
        double[] GetAverageTaxableBondRecently();
        string[] GetDateTaxableBondRecently();
        List<CefInsider> GetAllTaxableBondLastMonth();
        double[] GetAverageTaxableBondLastMonth();
        string[] GetDateTaxableBondLastMonth();
        List<CefInsider> GetAllTaxableBondLastYear();
        double[] GetAverageTaxableBondLastYear();
        string[] GetDateTaxableBondLastYear();

        List<CefInsider> GetAllTaxFreeBondRecently();
        double[] GetAverageTaxFreeBondRecently();
        string[] GetDateTaxFreeBondRecently();
        List<CefInsider> GetAllTaxFreeBondLastMonth();
        double[] GetAverageTaxFreeBondLastMonth();
        string[] GetDateTaxFreeBondLastMonth();
        List<CefInsider> GetAllTaxFreeBondLastYear();
        double[] GetAverageTaxFreeBondLastYear();
        string[] GetDateTaxFreeBondLastYear();

        List<CefInsider> GetAllForeignRecently();
        double[] GetAverageForeignRecently();
        string[] GetDateForeignRecently();
        List<CefInsider> GetAllForeignLastMonth();
        double[] GetAverageForeignLastMonth();
        string[] GetDateForeignLastMonth();
        List<CefInsider> GetAllForeignLastYear();
        double[] GetAverageForeignLastYear();
        string[] GetDateForeignLastYear();

        List<CefInsider> GetAllDisplayDataEquityRecently();
        double[] GetAverageEquityRecently();
        string[] GetDateEquityRecently();
        List<CefInsider> GetAllEquityLastMonth();
        double[] GetAverageEquityLastMonth();
        string[] GetDateEquityLastMonth();
        List<CefInsider> GetAllEquityLastYear();
        double[] GetAverageEquityLastYear();
        string[] GetDateEquityLastYear();

        Category GetMaximumDisplayDate();
    }
}
