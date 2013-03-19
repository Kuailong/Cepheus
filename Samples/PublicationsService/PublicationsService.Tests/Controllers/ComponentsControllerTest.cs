using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Promob.Entities;
using PublicationsService.Controllers;
using PublicationsService.Models;
using Moq;
using System.Web;
using System.Web.Http.SelfHost;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Web.Http.Dependencies;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using Procad.DataAccess.Interfaces;
using PublicationsService.Tests.DependencyResolversHelpers;
using Procad.DataAccess.RepositoryBase;

namespace PublicationsService.Tests.Controllers
{
    [TestFixture]
    public class ComponentsControllerTest
    {
        public readonly IRepository<Component> MockComponentsRepository;
        public readonly PromobPublicationsEntities MockContext;
        public ComponentsControllerTest()
        {
            var components = new List<Component>() {
                    new GeneralComponent { 
                        ComponentId = 1, ComponentType = new ComponentType(){ComponentTypeId=1,Name="",RequiresCompatibility=true}, Name = "Program", Publications = null 
                        },
                    new GeneralComponent { 
                        ComponentId = 2, ComponentType = new ComponentType(){ComponentTypeId=2,Name="",RequiresCompatibility=true}, Name = "Program", Publications = null 
                        },
                    new ProductRelatedComponent { 
                        ComponentId = 3, ComponentType = new ComponentType(){ComponentTypeId=3,Name="",RequiresCompatibility=true}, Name = "Program", Publications = null, ProductId = 1 
                        }
                };

            
            var mockRepository = new Mock<IRepository<Component>>();
            mockRepository.Setup(m => m.Get()).Returns(components.AsQueryable());
            this.MockComponentsRepository = mockRepository.Object;

            var dbContextMock = Mock.Of<PromobPublicationsEntities>();
            this.MockContext = dbContextMock;
        }

        [Test]
        public void Get_ReturnAllComponents()
        {
            //Arrange
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/Components/");
            var route = config.Routes.MapHttpRoute("Api", "api/{controller}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "components" } });
            var controller = new ComponentsController();

            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;

            //Act
            var result = controller.Get();
            var resultExpected = this.MockComponentsRepository.Get(); ;

            //Assert
            Assert.AreEqual(resultExpected, result);
        }

        [Test]
        public void Get_UsingSelfHost_ReturnStatusCodeOK()
        {
            //Arrange
            var baseAddress = @"http://localhost:8080/";
            var selfHostConfig = new HttpSelfHostConfiguration(baseAddress);

            selfHostConfig.Routes.MapHttpRoute(
                "Api", 
                "api/{controller}/{id}", 
                new { id = RouteParameter.Optional}
                );
            selfHostConfig.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            var DR = new ComponentControllerDR(this.MockComponentsRepository, this.MockContext);
            DR.GetService(typeof(ComponentsController));
            selfHostConfig.DependencyResolver = DR;

            var server = new HttpSelfHostServer(selfHostConfig);
            var client = new HttpClient();
            if(server.OpenAsync().IsCompleted)
                server.OpenAsync().Wait();

            client.BaseAddress = new Uri(baseAddress);

            //Act
            var getAsync = client.GetStringAsync("api/Components/1/ComponentType");
            var components = this.MockComponentsRepository.Get();
            var resultExpected = components.Where(e => e.ComponentId == 1).FirstOrDefault().ComponentType;

            //Assert
            Assert.IsNotNull(resultExpected);
            Assert.AreEqual(resultExpected, getAsync.Result);

            server.CloseAsync();
        }

        [Test]
        public void Delete_PassingID_ReturnStatusCodeOK()
        {
            //Arrange
            var repository = this.MockComponentsRepository;
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/Components");
            var route = config.Routes.MapHttpRoute("Api", "api/{controller}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "components" } });
            var controller = new ComponentsController();

            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;

            //Act
            var result = controller.Delete(2);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, result);
        }
    }
}
