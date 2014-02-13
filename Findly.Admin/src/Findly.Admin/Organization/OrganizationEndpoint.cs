using System;
using System.Collections.Generic;
using System.Linq;
using FubuMVC.Core;
using FubuMVC.Core.Continuations;
using FubuPersistence;

namespace Findly.Admin.Organization
{
    public class OrganizationEndpoint
    {
        private readonly IEntityRepository _repository;

        public OrganizationEndpoint(IEntityRepository repository)
        {
            _repository = repository;
        }

        public OrganizationIndexModel Index()
        {
            return new OrganizationIndexModel()
                {
                    Organizations = _repository.All<Organization>().ToList()
                };
        }

        public FubuContinuation post_new_organization(NewOrganizationInputModel model)
        {
            _repository.Update(new Organization()
                {
                    Id = Guid.NewGuid(),
                    ShortCode = model.ShortCode,
                    Name = model.Title
                });

            return FubuContinuation.RedirectTo<OrganizationEndpoint>(x => x.Index());
        }
    }

    public class OrganizationIndexModel
    {
        public IEnumerable<Organization> Organizations { get; set; }
    }
}