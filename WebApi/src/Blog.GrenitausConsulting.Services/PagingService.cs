using Blog.GrenitausConsulting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.GrenitausConsulting.Domain;

namespace Blog.GrenitausConsulting.Services
{
    public class PagingService : IPagingService
    {
        private int _skip;

        public PagedResponse Get(PagedCriteria criteria)
        {
            ApplyCriteriaLogic(criteria);
            var posts = criteria.Posts.Where(p => p.IsActive == criteria.IsActive);

            return new PagedResponse() { Total = posts.Count(),
                Posts = posts.Skip(_skip).Take(criteria.PageSize).OrderByDescending(p => p.Id)
            };
        }

        public PagedResponse Search(PagedCriteria criteria)
        {
            ApplyCriteriaLogic(criteria);
            var posts = criteria.Posts.Where(p => p.IsActive == criteria.IsActive);

            var query = posts.Where(p =>  
                p.Title.ToLower().Contains(criteria.SearchCriteria.ToLower()) ||
                p.Snippet.ToLower().Contains(criteria.SearchCriteria.ToLower())
                );

            if (query.ToList().Count > 0)
            {
                var results = posts.Where(p => 
                p.Title.ToLower().Contains(criteria.SearchCriteria.ToLower()) || 
                p.Snippet.ToLower().Contains(criteria.SearchCriteria.ToLower()))
                .Skip(_skip).Take(criteria.PageSize).OrderByDescending(p => p.Id);

                return new PagedResponse() { Total = query.ToList().Count(), Posts = results.ToList() };                
            }
            else
            {
                return new PagedResponse() { Total = 0, Posts = null };
            }
        }

        public PagedResponse GetByCategory(PagedCriteria criteria)
        {
            ApplyCriteriaLogic(criteria);
            var posts = criteria.Posts.Where(p => p.IsActive == criteria.IsActive);

            var query = posts.Where(p =>
                p.Categories.Any(c => c.Name.ToLower().Trim() == criteria.SearchCriteria.ToLower().Trim())
                );

            if (query.ToList().Count > 0)
            {
                var results = posts.Where(p =>
                p.Categories.Any(c => c.Name.ToLower().Trim() == criteria.SearchCriteria.ToLower().Trim()))
                .Skip(_skip).Take(criteria.PageSize).OrderByDescending(p => p.Id);

                return new PagedResponse() { Total = query.ToList().Count(), Posts = results.ToList() };
            }
            else
            {
                return new PagedResponse() { Total = 0, Posts = null };
            }
        }

        public PagedResponse GetByTag(PagedCriteria criteria)
        {
            ApplyCriteriaLogic(criteria);
            var posts = criteria.Posts.Where(p => p.IsActive == criteria.IsActive);

            var query = posts.Where(p =>
                p.Tags.Any(c => c.Name.ToLower().Trim() == criteria.SearchCriteria.ToLower().Trim())
                );

            if (query.ToList().Count > 0)
            {
                var results = posts.Where(p =>
                p.Tags.Any(c => c.Name.ToLower().Trim() == criteria.SearchCriteria.ToLower().Trim()))
                .Skip(_skip).Take(criteria.PageSize).OrderByDescending(p => p.Id);

                return new PagedResponse() { Total = query.ToList().Count(), Posts = results.ToList() };
            }
            else
            {
                return new PagedResponse() { Total = 0, Posts = null };
            }
        }

        private void ApplyCriteriaLogic(PagedCriteria criteria)
        {
            ApplyPageNumberLogic(criteria);
            ApplySkipLogic(criteria);
        }

        private void ApplyPageNumberLogic(PagedCriteria criteria)
        {
            if (criteria.PageNumber == 0)
                criteria.PageNumber = 1;
        }

        private void ApplySkipLogic(PagedCriteria criteria)
        {
            _skip = (criteria.PageNumber - 1) * criteria.PageSize;
        }
    }
}
