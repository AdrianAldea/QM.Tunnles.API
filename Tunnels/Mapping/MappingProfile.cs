using AutoMapper;
using Tunnels.Core.Models;
using Tunnels.DTOs.Product;
using Tunnels.DTOs.User;

namespace Tunnels.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile() {
            // Domain to DTO
            CreateMap<User, CreateUserResponse>();
            CreateMap<User, GetUserResponse>();
            CreateMap<Product, GetProductResponse>();
            CreateMap<Order, CreateOrderRequest>();
            CreateMap<Order, CreateOrderResponse>();

            // DTO to Domain
            CreateMap<CreateUserRequest, User>();
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<CreateOrderResponse, Order>();
        }
    }
}
