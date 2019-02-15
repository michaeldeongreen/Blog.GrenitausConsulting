using System;
using System.Collections.Generic;
using System.Linq;
using Blog.GrenitausConsulting.Core.Services.Interfaces;
using Blog.GrenitausConsulting.Core.Common.Interfaces;
using Blog.GrenitausConsulting.Core.Domain;

namespace Blog.GrenitausConsulting.Core.Services
{
    public class ArchiveService : IArchiveService
    {
        IConfigurationManagerWrapper _configurationManagerWrapper;
        private readonly int _archiveMonths;

        public ArchiveService(IConfigurationManagerWrapper configurationManagerWrapper)
        {
            _configurationManagerWrapper = configurationManagerWrapper;
            _archiveMonths = _configurationManagerWrapper.AppSettings.Value.ArchiveMonths;
        }
        public IList<Archive> Get(IEnumerable<PostSummary> posts)
        {
            IList<Archive> archives = new List<Archive>();
            DateTime today = DateTime.Now;

            for (int i = 1; i <= _archiveMonths; i++)
            {
                DateTime archiveDate = today.AddMonths(-i);
                if (posts.Where(p => p.PostDate.Month == archiveDate.Month && p.PostDate.Year == archiveDate.Year).Count() > 0)
                {
                    archives.Add(new Archive()
                    {
                        MonthName = archiveDate.ToString("MMMM"),
                        Year = archiveDate.Year,
                        Month = archiveDate.Month
                    });
                }
            }

            return archives;
        }
    }
}
