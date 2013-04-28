using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaasOvation.IssueTrack.Domain.Model;
using Shouldly;
using System;

namespace SaasOvation.IssueTrack.Domain.Specs
{
    [TestClass]
    public class Manipulating_an_issue:In_a_system_with_some_active_products
    {
        [TestMethod]
        public void Request_a_feature()
        {
            Setup_the_SUT();

            Products.IssueAssignerActivated(a_tenant, an_assigner);

            When.RequestFeature(a_tenant,a_product,a_feature,a_feature_name,a_feature_description,an_assigner);

            For_products.Verify(x=>x.IssueRegistered(a_tenant,a_product,a_feature,a_feature_name,a_feature_description,IssueType.Feature,an_assigner)); 
            For_domainevents.Verify(x => x.FeatureRequested(a_tenant, a_product, a_feature, a_feature_name, a_feature_description, an_assigner));
        }

        [TestMethod]
        public void Report_a_defect()
        {
            Setup_the_SUT();

            Products.IssueAssignerActivated(a_tenant, an_assigner);

            When.ReportDefect(a_tenant, a_product, a_defect, a_defect_name, a_defect_description, an_assigner);

            For_products.Verify(x=>x.IssueRegistered(a_tenant,a_product,a_feature,a_feature_name,a_feature_description,IssueType.Feature,an_assigner)); 
            For_domainevents.Verify(x=>x.DefectReported(a_tenant,a_product,a_defect,a_defect_name,a_defect_description,an_assigner));
        }

    }
}
