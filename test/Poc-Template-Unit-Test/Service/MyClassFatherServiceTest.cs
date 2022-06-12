using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using FluentAssertions;
using Microsoft.IdentityModel.Tokens;
using Poc_Template_Api.Services;
using Poc_Template_Api.ViewModel;
using Poc_Template_Core_Test.Mock;
using Xunit;

namespace Poc_Template_Unit_Test.Service
{
    public class MyClassFatherServiceTest
    {
        private readonly MyClassFatherService _service;

        public MyClassFatherServiceTest()
        {
            _service = new();
        }

        [Fact]
        public void GetById()
        {
            var result = _service.GetById(1);
            result.Should().NotBeNull().And.BeAssignableTo<MyClassFatherViewModel>();
        }
        
    }
}
