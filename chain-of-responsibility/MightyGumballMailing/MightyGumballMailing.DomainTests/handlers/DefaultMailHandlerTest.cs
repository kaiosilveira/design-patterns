using Xunit;
using Moq;
using MightyGumballMailing.Domain.Handlers;
using MightyGumballMailing.Domain.Entities;
using MightyGumballMailing.Domain.Enumerators;
using MightyGumballMailing.Domain.Services;

namespace MightyGumballMailing.DomainTests;

public class DefaultMailHandlerTest
{
  [Fact]
  public void TestHandlesEmailOfTypeUnknown()
  {
    var mockedMailSvc = new Mock<MailService>();
    var email = new Email(
      id: "abcd-1234",
      type: EmailType.UNKNOWN,
      subject: "Candidate application - Sr Software Engineer",
      body: "Hello, I would like to apply to the senior software engineer role"
    );

    var handler = new DefaultMailHandler(mailService: mockedMailSvc.Object);

    handler.HandleIncomingEmail(email);

    mockedMailSvc.Verify(instance => instance.MoveToInbox(email), Times.Once());
  }
}