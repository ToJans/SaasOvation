using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaasOvation.IssueTrack.Domain.Model;
using Shouldly;
using System;

namespace SaasOvation.IssueTrack.Domain
{
    [TestClass]
    public class Manipulating_an_issue
    {
        Product SUT;
        TenantId a_tenant = new TenantId(Guid.NewGuid());

        IssueAssignerId an_assigner = new IssueAssignerId(Guid.NewGuid());

        ProductId a_product=new ProductId(Guid.NewGuid());
        string a_product_name = "SaasOvational";
        string a_product_description = "Are you talkin' to me?";

        IssueId a_feature = new IssueId(Guid.NewGuid());
        string a_feature_name = "I would like to see the Lion King movie when I press Alt-F4";
        string a_feature_description = "Hakuna matata";

        IssueId a_defect = new IssueId(Guid.NewGuid());
        string a_defect_name = "Do not show the Lion King movie when I press return";
        string a_defect_description = "Say WHUT?";

        ProductState State;
        
        Moq.Mock<IPublishDomainEvents> DomainEventPublisherMock;

        [TestMethod]
        public void Request_a_feature()
        {
            Setup_the_SUT();

            State.TenantActivated(a_tenant);
            State.ProductActivated(a_tenant, a_product, a_product_name, a_product_description);
            State.IssueAssignerActivated(a_tenant, an_assigner);

            SUT.RequestFeature(a_tenant,a_product,a_feature,a_feature_name,a_feature_description,an_assigner);

            var result = State.GetById(a_tenant,a_product,a_feature);
            result.Id.ShouldBe(a_feature);
            result.Name.ShouldBe(a_feature_name);
            result.Description.ShouldBe(a_feature_description);

            DomainEventPublisherMock.Verify(x => x.FeatureRequested(a_tenant, a_product, a_feature, a_feature_name, a_feature_description, an_assigner));
        }

        [TestMethod]
        public void Report_a_defect()
        {
            Setup_the_SUT();

            State.TenantActivated(a_tenant);
            State.ProductActivated(a_tenant, a_product, a_product_name, a_product_description);
            State.IssueAssignerActivated(a_tenant, an_assigner);

            SUT.ReportDefect(a_tenant, a_product, a_defect, a_defect_name, a_defect_description, an_assigner);

            var result = State.GetById(a_tenant, a_product, a_defect);
            result.Id.ShouldBe(a_defect);
            result.Name.ShouldBe(a_defect_name);
            result.Description.ShouldBe(a_defect_description);

            DomainEventPublisherMock.Verify(x=>x.DefectReported(a_tenant,a_product,a_defect,a_defect_name,a_defect_description,an_assigner));
        }

        void Setup_the_SUT()
        {
            DomainEventPublisherMock = new Moq.Mock<IPublishDomainEvents>(Moq.MockBehavior.Loose);

            State = new ProductState(DomainEventPublisherMock.Object);

            SUT = new Product(State);

        }



    }
}
