using AutoMapper;
using StoreSampleAPI.Models;
using StoreSampleAPI.Models.CreateDTO;
using StoreSampleAPI.Models.DTO;

namespace StoreSampleAPI
{
	public class MappingConfig:Profile
	{
		public MappingConfig()
		{
			CreateMap<Category, CategoryDTO>().ReverseMap();
			CreateMap<Customer, CustomerDTO>().ReverseMap();
			CreateMap<Employee, EmployeeDTO>().ReverseMap();
			CreateMap<Order, OrderDTO>().ReverseMap();
			CreateMap<OrderDetails, OrderDetailsDTO>().ReverseMap();
			CreateMap<Product, ProductDTO>().ReverseMap();
			CreateMap<Shipper, ShipperDTO>().ReverseMap();
			CreateMap<Supplier, SupplierDTO>().ReverseMap();

			CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Customer, CustomerCreateDTO>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDTO>().ReverseMap();
            CreateMap<Order, OrderCreateDTO>().ReverseMap();
            CreateMap<OrderDetails, OrderDetailsCreateDTO>().ReverseMap();
            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<Shipper, ShipperCreateDTO>().ReverseMap();
            CreateMap<Supplier, SupplierCreateDTO>().ReverseMap();

            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();
            CreateMap<Customer, CustomerUpdateDTO>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDTO>().ReverseMap();
            CreateMap<Order, OrderUpdateDTO>().ReverseMap();
            CreateMap<OrderDetails, OrderDetailsUpdateDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();
            CreateMap<Shipper, ShipperUpdateDTO>().ReverseMap();
            CreateMap<Supplier, SupplierUpdateDTO>().ReverseMap();

            CreateMap<OrderInsertParameters, OrderInsertParametersDTO>().ReverseMap();
        }
	}
}

