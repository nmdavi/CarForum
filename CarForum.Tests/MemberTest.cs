using CarForum.Controllers;
using CarForum.Models;
using CarForum.Models.Repository;
using Moq;
using System.Collections.Generic;
using System.Data.Objects;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace CarForum.Tests
{
    public class MemberTest
    {
        public readonly Mock<IGenericRepository> _repository;
        public readonly MemberController controller;
        public MemberTest()
        {
            _repository = new Mock<IGenericRepository>();
            controller = new MemberController(_repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
        }

        [Fact]
        public void GetAllMembers()
        {
            _repository.Setup(x => x.GetAll<Member>()).Returns(new List<Member>
            {
                new Member() { Id = 1, Username = "Jonh", Email = "jonh@doe.com", Password = "1234567"},
                new Member() { Id = 2, Username = "Doe", Email = "doe@jonh.com", Password = "1234567"},
                new Member() { Id = 3, Username = "Marie", Email = "marie@doe.com", Password = "1234567"}
            });

            var response = controller.Get();

            IList<Member> member;
            var result = response.TryGetContentValue(out member);

            Assert.NotNull(member);
            Assert.Equal(1, member[0].Id);
        }

        [Theory]
        [InlineData(1)]
        public void GetOneMemberById(int id)
        {
            _repository.Setup(x => x.Get<Member>(It.IsAny<int>())).Returns(new Member{ Id = 1});

            var result = controller.Get(id);

            Member member;
            result.TryGetContentValue<Member>(out member);

            Assert.Equal(id, member.Id);
        }
    }
}