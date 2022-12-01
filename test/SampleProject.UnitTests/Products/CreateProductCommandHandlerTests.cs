using AutoMapper;
using Moq;
using ProductMicroservice.Application.Contracts;
using ProductMicroservice.Application.CQRS.Handlers.Commands;
using ProductMicroservice.Application.CQRS.Requests.Commands;
using ProductMicroservice.Application.DTOs;
using ProductMicroservice.Application.Profiles;
using Shouldly;
using Xunit;

namespace SampleProject.UnitTests.Products
{
    public class CreateProductCommandHandlerTests
    {
        private IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        

        public CreateProductCommandHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(k =>
            {
                k.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(mapperConfig);

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockProductRepository = new Mock<IProductRepository>();
            _mockUnitOfWork.Setup(k => k.ProductRepository).Returns(mockProductRepository.Object);
        }

        [Fact]
        public async Task Should_Fail_When_Title_Is_Empty()
        {
            CreateProductDto createProductDto = new CreateProductDto();


            var handler = new CreateProductCommandHandler(_mockUnitOfWork.Object, _mapper);
            var result = await handler.Handle(new CreateProductCommand { CreateProductDto = createProductDto }, CancellationToken.None);

            result.Success.ShouldBeFalse();
        }

        [Fact]
        public async Task Should_Fail_When_Description_Is_Empty()
        {
            CreateProductDto createProductDto = new CreateProductDto();
            createProductDto.Title = "some title";

            var handler = new CreateProductCommandHandler(_mockUnitOfWork.Object, _mapper);
            var result = await handler.Handle(new CreateProductCommand { CreateProductDto = createProductDto }, CancellationToken.None);

            result.Success.ShouldBeFalse();
        }

        [Fact]
        public async Task Should_Fail_When_Price_Is_Zero()
        {
            CreateProductDto createProductDto = new CreateProductDto();
            createProductDto.Title = "some title";
            createProductDto.Description = "some description";

            var handler = new CreateProductCommandHandler(_mockUnitOfWork.Object, _mapper);
            var result = await handler.Handle(new CreateProductCommand { CreateProductDto = createProductDto }, CancellationToken.None);

            result.Success.ShouldBeFalse();
        }

        [Fact]
        public async Task Should_Fail_When_StockCount_Is_Zero()
        {
            CreateProductDto createProductDto = new CreateProductDto();
            createProductDto.Title = "some title";
            createProductDto.Description = "some description";
            createProductDto.Price = 10;

            var handler = new CreateProductCommandHandler(_mockUnitOfWork.Object, _mapper);
            var result = await handler.Handle(new CreateProductCommand { CreateProductDto = createProductDto }, CancellationToken.None);

            result.Success.ShouldBeFalse();
        }

        [Fact]
        public async Task Should_Success_When_Params_Valid()
        {
            CreateProductDto createProductDto = new CreateProductDto();
            createProductDto.Title = "some title";
            createProductDto.Description = "some description";
            createProductDto.Price = 10;
            createProductDto.StockCount = 100;

            var handler = new CreateProductCommandHandler(_mockUnitOfWork.Object, _mapper);
            var result = await handler.Handle(new CreateProductCommand { CreateProductDto = createProductDto }, CancellationToken.None);

            result.Success.ShouldBeTrue();
        }
    }
}
