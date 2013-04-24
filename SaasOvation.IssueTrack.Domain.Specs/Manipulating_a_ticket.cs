﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaasOvation.IssueTrack.Domain.Model;
using Shouldly;
using System;

namespace SaasOvation.IssueTrack.Domain
{
    [TestClass]
    public class Manipulating_a_ticket
    {
        Product SUT;
        TenantId a_tenant = new TenantId(Guid.NewGuid());

        ProductId a_product=new ProductId(Guid.NewGuid());
        string a_product_name = "SaasOvational";
        string a_product_description = "Are you talkin' to me?";

        TicketId a_feature = new TicketId(Guid.NewGuid());
        string a_feature_name = "I would like to see the Lion King movie when I press Alt-F4";
        string a_feature_description = "Hakuna matata";

        TicketId a_defect = new TicketId(Guid.NewGuid());
        string a_defect_name = "Do not show the Lion King movie when I press return";
        string a_defect_description = "Say WHUT?";

        ProductState State;

        [TestMethod]
        public void Request_a_feature()
        {
            Setup_the_SUT_and_activate_the_product();

            SUT.RequestFeature(a_tenant,a_product,a_feature,a_feature_name,a_feature_description);

            var result = State.GetById(a_tenant,a_product,a_feature);
            result.Id.ShouldBe(a_feature);
            result.Name.ShouldBe(a_feature_name);
            result.Description.ShouldBe(a_feature_description);
        }

        [TestMethod]
        public void Report_a_defect()
        {
            Setup_the_SUT_and_activate_the_product();

            SUT.ReportDefect(a_tenant, a_product, a_defect, a_defect_name, a_defect_description);

            var result = State.GetById(a_tenant, a_product, a_defect);
            result.Id.ShouldBe(a_defect);
            result.Name.ShouldBe(a_defect_name);
            result.Description.ShouldBe(a_defect_description);
        }

        void Setup_the_SUT_and_activate_the_product()
        {
            State = new ProductState();

            SUT = new Product(State);

            State.TenantActivated(a_tenant);
            State.ProductActivated(a_tenant, a_product, a_product_name, a_product_description);
        }


    }
}
