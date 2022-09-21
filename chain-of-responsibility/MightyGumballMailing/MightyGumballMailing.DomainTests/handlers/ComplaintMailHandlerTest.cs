using Xunit;
using Moq;
using MightyGumballMailing.Domain.Handlers;
using MightyGumballMailing.Domain.Entities;
using MightyGumballMailing.Domain.Enumerators;
using MightyGumballMailing.Domain.Services;

namespace MightyGumballMailing.DomainTests;

public class ComplaintMailHandlerTest
{
  [Fact]
  public void TestHandlesComplaintEmail()
  {
    var mockedMailSvc = new Mock<MailService>();
    var mockedSuccessorMailHandler = new Mock<MailHandler>();
    var email = new Email(
      id: "abcd-1234",
      type: EmailType.COMPLAINT,
      subject: "Platform not working",
      body: "Hello, this morning I tried to use the web platform and it wasn't loading"
    );

    var handler = new ComplaintMailHandler(
      mailService: mockedMailSvc.Object,
      successor: mockedSuccessorMailHandler.Object
    );

    handler.HandleIncomingEmail(email);

    mockedMailSvc.Verify(instance => instance.ForwardToLegalDepartment(email), Times.Once());
  }

  [Fact]
  public void TestDoesNothingIfEmailTypeIsNotComplaintAndThereIsSuccessor()
  {
    var mockedMailSvc = new Mock<MailService>();
    var email = new Email(
      id: "abcd-1234",
      type: EmailType.UNKNOWN,
      subject: "Candidate application - Sr Software Engineer",
      body: "Hello, I would like to apply to the senior software engineer role"
    );

    var handler = new ComplaintMailHandler(mailService: mockedMailSvc.Object, successor: null);

    handler.HandleIncomingEmail(email);
  }

  [Fact]
  public void TestDelegatesHandlingToSuccessorIfMailTypeIsNotComplaint()
  {
    var mockedMailSvc = new Mock<MailService>();
    var mockedSuccessorMailHandler = new Mock<MailHandler>();
    var email = new Email(
      id: "abcd-1234",
      type: EmailType.UNKNOWN,
      subject: "Candidate application - Sr Software Engineer",
      body: "Hello, I would like to apply to the senior software engineer role"
    );

    var handler = new ComplaintMailHandler(
      mailService: mockedMailSvc.Object,
      successor: mockedSuccessorMailHandler.Object
    );

    handler.HandleIncomingEmail(email);

    mockedSuccessorMailHandler.Verify(instance => instance.HandleIncomingEmail(email), Times.Once());
  }
}