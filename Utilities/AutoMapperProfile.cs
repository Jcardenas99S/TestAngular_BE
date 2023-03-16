using AutoMapper;
using TestAngular_BE.DTOs;
using TestAngular_BE.Models;
using System.Globalization;

namespace TestAngular_BE.Utilities
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            #region CustomerType
            CreateMap<CustomerTypeJc, CustomerTypeDTO>().ReverseMap();
            #endregion

            #region Customer
            CreateMap<CustomerJc, CustomerDTO>()
                .ForMember(end => end.CustomerTypeIdName, opt => opt.MapFrom(origin => origin.CustomerType.CustomerTypeCode));

            CreateMap<CustomerDTO, CustomerJc>()
                .ForMember(end => end.CustomerType, opt => opt.Ignore());
            #endregion

            #region Employee
            CreateMap <EmployeeJc, EmployeeDTO>().ReverseMap();
            #endregion

            #region PetType
            CreateMap<PetTypeJc, PettypeDTO>().ReverseMap();
            #endregion

            #region Pet
            CreateMap<PetJc, PetDTO>()
                .ForMember(end => end.CustomerIdName, opt => opt.MapFrom(origin => origin.Customer.CustomerName));
            CreateMap<PetDTO, PetJc>()
                .ForMember(end => end.Customer, opt => opt.Ignore());
            #endregion

            #region ServiceType
            CreateMap<ServiceTypeJc, ServiceTypeDTO>().ReverseMap();
            #endregion

            #region Service
            CreateMap<ServiceJc, ServiceDTO>()
                .ForMember(end => end.ServiceTypeIdName, opt => opt.MapFrom(origin => origin.ServiceType.ServiceTypeName))
                .ForMember(end => end.PetIdName, opt => opt.MapFrom(origin => origin.Pet.PetName))
                .ForMember(end => end.EmployeeIdName, opt => opt.MapFrom(origin => origin.Employee.EmployeeName))
                .ForMember(end => end.ServiceDate, opt => opt.MapFrom(origin => origin.ServiceDate.Value.ToString("dd/MM/yyyy")));
            CreateMap<ServiceDTO, ServiceJc>()
                .ForMember(end => end.ServiceType, opt => opt.Ignore())
                .ForMember(end => end.Pet, opt => opt.Ignore())
                .ForMember(end => end.Employee, opt => opt.Ignore())
                .ForMember(end => end.ServiceDate, opt => opt.MapFrom(origin => DateTime.ParseExact(origin.ServiceDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)));  
            #endregion

        }
    }
}
