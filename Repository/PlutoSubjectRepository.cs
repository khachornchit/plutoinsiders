using System;
using System.Collections.Generic;
using System.Linq;
using CefInsiders.Models;

namespace CefInsiders.Repository
{
    public class CefSubjectRepository : ICefSubjectRepository
    {
        CefInsiderEntities entities = new CefInsiderEntities();

        public bool Add(CefSubject cefSubject)
        {
            try
            {
                entities.CefSubjects.Add(cefSubject);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CefSubject Find(int id)
        {
            return entities.CefSubjects.Find(id);
        }

        public List<CefSubject> FindAll()
        {
            return entities.CefSubjects.ToList();
        }

        public bool IsExistedSubject(string subject)
        {
            return entities.CefSubjects.Where(c => c.Subject.Equals(subject)).FirstOrDefault() != null;
        }
    }
}