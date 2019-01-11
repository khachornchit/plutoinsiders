using System.Collections.Generic;
using PlutoInsiders.Models;

namespace PlutoInsiders.Repository
{
    interface ICefSubjectRepository
    {
        List<CefSubject> FindAll();
        CefSubject Find(int id);
        bool IsExistedSubject(string subject);
        bool Add(CefSubject cefSubject);
    }
}
