using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DataAccess.Models;
using Task1_MVS.Models;

namespace Task1_MVS.WorkWithData
{
    public class WorkWithDatabase
    {
        private readonly SetBlogDataContext _context;

        public WorkWithDatabase(SetBlogDataContext context)
        {
            this._context = context;
        }   

        public IEnumerable<Article> GetArticles()
        {
            return _context.Articles.ToList();
        }

        public IEnumerable<RecallData> GetRecalls()
        {
            return _context.Recalls.ToList();
        }

        public Article GetArticle(int id)
        {
            return _context.Articles.FirstOrDefault(o => o.Id == id);
        }

        public void AddArticle(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();

        }

        public void DeletedArticle(int id)
        {
            Article article = GetArticle(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                _context.SaveChanges();
            }
        }
        
        public void EditingArticle(Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public RecallData GetRecall(int id)
        {
            return _context.Recalls.FirstOrDefault(o => o.Id == id);

        }

        public void AddRecall(RecallData recallData)
        {
            _context.Recalls.Add(recallData);
            _context.SaveChanges();
        } 


    }
}