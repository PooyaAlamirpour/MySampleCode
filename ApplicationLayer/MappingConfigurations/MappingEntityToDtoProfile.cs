using ApplicationLayer.DataTransferObjects;
using AutoMapper;
using DomainLayer.AggregatesModels.Books.Models;

namespace ApplicationLayer.MappingConfigurations
{
    public class MappingEntityToDtoProfile : Profile
    {
        public MappingEntityToDtoProfile()
        {
            CreateMap<BookInfo, BookInfoDto>()
                .ForMember(x => x.Title, options => options.MapFrom(x => x.book.title))
                .ForMember(x => x.Description, options => options.MapFrom(x => x.book.description))
                .ForMember(x => x.Price, options => options.MapFrom(x => x.book.price))
                .ForMember(x => x.NumberOfPages, options => options.MapFrom(x => x.book.numberOfPages))
                .ForMember(x => x.Rating, options => options.MapFrom(x => x.book.rating))
                .ForMember(x => x.PublishDate, options => options.MapFrom(x => x.book.publishDate))
                .ForMember(x => x.CurrencyPrice, options => options.MapFrom(x => x.book.currencyPrice));
        }
    }
}