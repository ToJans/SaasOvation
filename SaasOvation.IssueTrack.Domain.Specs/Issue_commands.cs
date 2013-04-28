using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace SaasOvation.IssueTrack.Domain
{
    [TestClass]
    public class Issue_commands
    {
        Model.Products.CommandHandler SUT;
        Model.Tenants.Id a_tenant = new Model.Tenants.Id(Guid.NewGuid());

        Model.IssueAssigners.Id an_assigner = new Model.IssueAssigners.Id(Guid.NewGuid());

        Model.Products.Id a_product = new Model.Products.Id(Guid.NewGuid());
        string a_product_name = "SaasOvational";
        string a_product_description = "Are you talkin' to me?";

        Model.Issues.Id a_feature = new Model.Issues.Id(Guid.NewGuid());
        string a_feature_name = "I would like to see the Lion King movie when I press Alt-F4";
        string a_feature_description = "Hakuna matata";

        Model.Issues.Id a_defect = new Model.Issues.Id(Guid.NewGuid());
        string a_defect_name = "Do not show the Lion King movie when I press return";
        string a_defect_description = "Say WHUT?";

        Model.Products.State State;
        
        Moq.Mock<Model.Products.IPublishEvents> ProductEventPublisherMock;
        private Model.Issues.State IssueState;

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

            ProductEventPublisherMock.Verify(x => x.FeatureRequested(a_tenant, a_product, a_feature, a_feature_name, a_feature_description, an_assigner));
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

            ProductEventPublisherMock.Verify(x=>x.DefectReported(a_tenant,a_product,a_defect,a_defect_name,a_defect_description,an_assigner));
        }

        void Setup_the_SUT()
        {
            ProductEventPublisherMock = new Moq.Mock<Model.Products.IPublishEvents>(Moq.MockBehavior.Loose);

            State = new Model.Products.State(ProductEventPublisherMock.Object);
            IssueState = new Model.Issues.State(ProductEventPublisherMock.Object);

            SUT = new Model.Products.CommandHandler(State);

        }



    }
}
