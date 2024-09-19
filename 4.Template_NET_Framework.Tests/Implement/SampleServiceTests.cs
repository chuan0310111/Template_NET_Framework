using _0.Template_NET_Framework.Common.Implement;
using _0.Template_NET_Framework.Common.Interface;
using _2.Template_NET_Framework.Services.Dtos;
using _2.Template_NET_Framework.Services.Implement;
using _2.Template_NET_Framework.Services.Infrastructure.AutoMapper;
using _3.Template_NET_Framework.Repositories.DataModels;
using _3.Template_NET_Framework.Repositories.Interface;
using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using FluentAssertions;

namespace _4.Template_NET_Framework.Tests.Implement
{
    [TestFixture()]
    public class SampleServiceTests
    {
        private SampleService _sampleService;
        private ILogger _logger;
        private IMapper _mapper;
        private IAppSettings _appSettings;
        private IHsinChuRepository _hsinChuRepository;


        [SetUp]
        public void SetUp()
        {
            _logger = Substitute.For<ILogger>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ServiceMapperProfiler>());
            _mapper = config.CreateMapper();

            _appSettings = new AppSettings(new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "hsinchuGovUrl" , "http://XXX.XXX.XXX" },
            });

            _hsinChuRepository = Substitute.For<IHsinChuRepository>();

            _sampleService = new SampleService(
                _logger,
                _mapper,
                _hsinChuRepository,
                _appSettings
                );
        }

        [Test()]
        [TestCase(Author = "Mia", Category = "取得鄉鎮市公所名稱_回傳000000_有撈到資料", Description = "查詢成功")]
        public void 取得鄉鎮市公所名稱_回傳000000_有撈到資料()
        {
            // arrange
            var excetped = new List<HsinChuAreaDataModel>()
                {
                    new HsinChuAreaDataModel()
                    {
                        鄉鎮市公所名稱 =  "AAA公所",
                        電話= "(03)0000000",
                        負責人= "甲負責人",
                        傳真機號碼= "(03)0000000",
                        郵遞區號= "311",
                        地址= "新竹縣AAAaa村6鄰95號",
                        網址= "http://www.XXX.gov.tw/",
                        最後更新時間= "113/02/01"
                    },
                    new HsinChuAreaDataModel()
                    {
                        鄉鎮市公所名稱 =  "BBB公所",
                        電話= "(03)1111111",
                        負責人= "乙負責人",
                        傳真機號碼= "(03)1111111",
                        郵遞區號= "311",
                        地址= "新竹縣BBBbb村6鄰95號",
                        網址= "http://www.YYY.gov.tw/",
                        最後更新時間= "113/02/02"
                    }

                };

            _hsinChuRepository.GetArea().Returns(excetped);

            // act
            var actual = this._sampleService.GetArea();

            // assert
            actual.ResultCode.Should().Be("000000");
            actual.Areas.Count.Should().BeGreaterThan(0);

            //Assert.AreEqual("000000", actual.ResultCode);
        }
    }
}
