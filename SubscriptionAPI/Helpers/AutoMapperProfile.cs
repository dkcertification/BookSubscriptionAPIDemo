using AutoMapper;
using SubscriptionAPI.Entities;
using SubscriptionAPI.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionAPI.Helpers
{
    // mappings between model and entity objects
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountResponse>(); /*Mapping From Entities.Account => Models.Accounts.AccountResponse */
            CreateMap<Account, AuthenticateResponse>(); /*Mapping From Entities.Account => Models.Accounts.AuthenticateResponse*/
            CreateMap<RegisterRequest, Account>(); /*Mapping From Models.Accounts.RegisterRequest => Entities.Account*/
            CreateMap<CreateRequest, Account>();/*Mapping From Models.Accounts.CreateRequest => Entities.Account*/

            CreateMap<UpdateRequest, Account>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        //if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                )); //TODO :: To be worked upon
        }

    }
}
