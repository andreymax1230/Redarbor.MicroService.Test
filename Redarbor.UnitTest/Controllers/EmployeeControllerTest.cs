using Bogus;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Redarbor.Presentation.Api.Controllers;
using Redarbor.RequestReply.Eda.Interface;
using Redarbor.System.Domain.DTOs;
using Redarbor.UnitTest.Fake;
using System.Runtime.CompilerServices;
using Xunit;

namespace Redarbor.UnitTest.Controllers;

[TestFixture]
public class EmployeeControllerTest
{
    [Fact]
    public async Task GetListEmployeeTest()
    {
        var response = new Faker<ResponseListEmployeeDto>().GenerateItemFake();
        Mock<IRequestReplayService> mockRequestReplyService = new();
        mockRequestReplyService.Setup(a => a.WaitProducer<ResponseListEmployeeDto>(It.IsAny<RequestListEmployeeDto>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<TimeSpan>()))
           .Returns(Task.FromResult(response));

        var controller = new RedarborController(mockRequestReplyService.Object);
        var responseController = ((OkObjectResult)(await controller.Get()).Result).Value as ResponseListEmployeeDto;

        NUnit.Framework.Assert.Multiple(() =>
        {
            NUnit.Framework.Assert.That(responseController, Is.Not.Null);
            NUnit.Framework.Assert.That(responseController.Response, Is.Not.Null);
            NUnit.Framework.Assert.AreEqual(6, responseController.Response.Count);
        });
    }

    [Fact]
    public async Task GetEmployeeById()
    {
        var response = new Faker<ResponseEmployeeDto>().GenerateItemFake();
        Mock<IRequestReplayService> mockRequestReplyService = new();
        mockRequestReplyService.Setup(a => a.WaitProducer<ResponseEmployeeDto>(It.IsAny<RequestEmployeeById>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<TimeSpan>()))
           .Returns(Task.FromResult(response));

        var controller = new RedarborController(mockRequestReplyService.Object);
        var responseController = ((OkObjectResult)(await controller.GetById(1)).Result).Value as ResponseEmployeeDto;
        NUnit.Framework.Assert.Multiple(() =>
        {
            NUnit.Framework.Assert.That(responseController, Is.Not.Null);
            NUnit.Framework.Assert.That(responseController.Response, Is.Not.Null);
        });
    }

    [Fact]
    public async Task PostEmployee()
    {
        var request = new Faker<RequestCreateEmployeeDto>().GenerateItemFake();
        var response = new Faker<ResponseCreateEmployeeDto>().GenerateItemFake();
        Mock<IRequestReplayService> mockRequestReplyService = new();
        mockRequestReplyService.Setup(a => a.WaitProducer<ResponseCreateEmployeeDto>(It.IsAny<RequestCreateEmployeeDto>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<TimeSpan>()))
          .Returns(Task.FromResult(response));
        var controller = new RedarborController(mockRequestReplyService.Object);
        var responseController = ((OkObjectResult)(await controller.Post(request)).Result).Value as ResponseCreateEmployeeDto;

        NUnit.Framework.Assert.Multiple(() =>
        {
            NUnit.Framework.Assert.That(responseController, Is.Not.Null);
            NUnit.Framework.Assert.AreEqual(responseController.Response, true);
            NUnit.Framework.Assert.AreEqual(responseController.Id, 1);
        });
    }

    [Fact]
    public async Task PutEmployee()
    {
        var request = new Faker<RequestUpdateEmployeeDto>().GenerateItemFake();
        var response = new Faker<ResponseUpdateEmployeeDto>().GenerateItemFake();
        Mock<IRequestReplayService> mockRequestReplyService = new();
        mockRequestReplyService.Setup(a => a.WaitProducer<ResponseUpdateEmployeeDto>(It.IsAny<RequestUpdateEmployeeDto>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<TimeSpan>()))
          .Returns(Task.FromResult(response));

        var controller = new RedarborController(mockRequestReplyService.Object);
        var responseController = ((OkObjectResult)(await controller.Update(request)).Result).Value as ResponseUpdateEmployeeDto;

        NUnit.Framework.Assert.Multiple(() =>
        {
            NUnit.Framework.Assert.That(responseController, Is.Not.Null);
            NUnit.Framework.Assert.AreEqual(responseController.Response, true);
        });
    }

    [Fact]
    public async Task DeleteEmployee()
    {
        var response = new Faker<ResponseDeleteEmployeeDto>().GenerateItemFake();
        Mock<IRequestReplayService> mockRequestReplyService = new();

        mockRequestReplyService.Setup(a => a.WaitProducer<ResponseDeleteEmployeeDto>(It.IsAny<RequestDeleteEmployeeDto>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<TimeSpan>()))
          .Returns(Task.FromResult(response));

        var controller = new RedarborController(mockRequestReplyService.Object);
        var responseController = ((OkObjectResult)(await controller.Delete(1)).Result).Value as ResponseDeleteEmployeeDto;

        NUnit.Framework.Assert.Multiple(() =>
        {
            NUnit.Framework.Assert.That(responseController, Is.Not.Null);
            NUnit.Framework.Assert.IsTrue(responseController.Response);
        });
    }
}
