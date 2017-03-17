using Blog.GrenitausConsulting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.GrenitausConsulting.Domain;
using Blog.GrenitausConsulting.Common;
using System.Globalization;

namespace Blog.GrenitausConsulting.Services
{
    public class PagingService : IPagingService
    {
        private int _skip;

        public PagedResponse Get(PagedCriteria criteria)
        {
            ApplyCriteriaLogic(criteria);
            var posts = criteria.Posts.Where(p => p.IsActive == criteria.IsActive).OrderByDescending(p => p.PostDate);

            return new PagedResponse() { Total = posts.Count(),
                Posts = posts.Skip(_skip).Take(criteria.PageSize).OrderByDescending(p => p.PostDate)
            };
        }

        public PagedResponse Search(PagedCriteria criteria)
        {
            ApplyCriteriaLogic(criteria);
            var posts = criteria.Posts.Where(p => p.IsActive == criteria.IsActive).OrderByDescending(p => p.PostDate);

            var query = posts.Where(p =>  
                p.Title.ToLower().Contains(criteria.SearchCriteria.ToLower()) ||
                p.Snippet.ToLower().Contains(criteria.SearchCriteria.ToLower()) ||
                BlogContextManager.PostHtmlList.Where(h => h.Link.ToLower() == p.Link.ToLower() && h.Hmtl.Contains(criteria.SearchCriteria)).Count() > 0
                );

            if (query.ToList().Count > 0)
            {
                var results = posts.Where(p => 
                p.Title.ToLower().Contains(criteria.SearchCriteria.ToLower()) || 
                p.Snippet.ToLower().Contains(criteria.SearchCriteria.ToLower()) ||
                BlogContextManager.PostHtmlList.Where(h => h.Link.ToLower() == p.Link.ToLower() && h.Hmtl.Contains(criteria.SearchCriteria)).Count() > 0)
                .Skip(_skip).Take(criteria.PageSize).OrderByDescending(p => p.PostDate);

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
            var posts = criteria.Posts.Where(p => p.IsActive == criteria.IsActive).OrderByDescending(p => p.PostDate);

            var query = posts.Where(p =>
                p.Categories.Any(c => c.Name.ToLower().Trim() == criteria.SearchCriteria.ToLower().Trim())
                );

            if (query.ToList().Count > 0)
            {
                var results = posts.Where(p =>
                p.Categories.Any(c => c.Name.ToLower().Trim() == criteria.SearchCriteria.ToLower().Trim()))
                .Skip(_skip).Take(criteria.PageSize).OrderByDescending(p => p.PostDate);

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
            var posts = criteria.Posts.Where(p => p.IsActive == criteria.IsActive).OrderByDescending(p => p.PostDate);

            var query = posts.Where(p =>
                p.Tags.Any(c => c.Name.ToLower().Trim() == criteria.SearchCriteria.ToLower().Trim())
                );

            if (query.ToList().Count > 0)
            {
                var results = posts.Where(p =>
                p.Tags.Any(c => c.Name.ToLower().Trim() == criteria.SearchCriteria.ToLower().Trim()))
                .Skip(_skip).Take(criteria.PageSize).OrderByDescending(p => p.PostDate);

                return new PagedResponse() { Total = query.ToList().Count(), Posts = results.ToList() };
            }
            else
            {
                return new PagedResponse() { Total = 0, Posts = null };
            }
        }

        public PagedResponse GetByMonthAndYear(PagedCriteria criteria)
        {
            ApplyCriteriaLogic(criteria);
            var posts = criteria.Posts.Where(p => p.IsActive == criteria.IsActive).OrderByDescending(p => p.PostDate);

            var query = posts.Where(p =>
                p.PostDate.Month == criteria.MonthCriteria && p.PostDate.Year == criteria.YearCriteria
                );

            if (query.ToList().Count > 0)
            {
                var results = posts.Where(p =>
                p.PostDate.Month == criteria.MonthCriteria && p.PostDate.Year == criteria.YearCriteria)
                .Skip(_skip).Take(criteria.PageSize).OrderByDescending(p => p.PostDate);

                return new PagedResponse() { Total = query.ToList().Count(), Posts = results.ToList(), ArchiveYear = criteria.YearCriteria, ArchiveMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(criteria.MonthCriteria) };
            }
            else
            {
                return new PagedResponse() { Total = 0, Posts = null };
            }
        }

        public PagedResponse GetAlsoOn(PagedCriteria criteria)
        {
            var posts = criteria.Posts.Where(p => p.IsActive == criteria.IsActive).OrderBy(p => p.PostDate);

            var post = posts.Where(p => p.Id == criteria.SearchCriteriaInt).SingleOrDefault();

            if (post != null)
            {
                var query = posts.Where(p => p.PostDate > post.PostDate && p.Id != criteria.SearchCriteriaInt).Take(2);
                if (query.ToList().Count >= 2)
                    return new PagedResponse() { Total = query.ToList().Count(), Posts = query.ToList() };
                else
                    return new PagedResponse() { Total = 0, Posts = null };
            }
            else
            {
                return new PagedResponse() { Total = 0, Posts = null };
            }
        }

        public PagedResponse GetPreviews()
        {
            var query = BlogContextManager.PostSummaries.Where(p => p.CanPreview && p.PreviewExpirationDate.Value.Date >= DateTime.Now.Date).OrderBy(p => p.Id);

            if (query.ToList().Count > 0)
            {

                return new PagedResponse() { Total = query.ToList().Count(), Posts = query.ToList() };
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
