using System;
using FubuPersistence;

namespace Findly.Admin.Organization
{
    public class Organization : IEntity
    {
        public Guid Id { get; set; }

        public string ShortCode { get; set; }

        public string Name { get; set; }
    }
}