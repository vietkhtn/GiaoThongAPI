using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Api.Routes
{
    public class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

       
        public static class Auth
        {
            public const string Login = Base + "/auth/login";
            public const string Register = Base + "/auth/register";
            public const string RefreshToken = Base + "/auth/refresh-token";
            public const string ResetPassword = Base + "/auth/reset-password";
        }
        public static class Role {
            public const string GetAll = Base + "/roles";
        }
        public static class VehicleType
        {
            public const string GetAll = Base + "/vehicle-type";

        }
        public static class DriversLicensesType
        {
            public const string GetAll = Base + "/drivers-licenses-type";
            public const string GetOne = Base + "/drivers-licenses-type/{Id}";
        }

        public static class Law
        {
            public const string GetAll = Base + "/laws";
            
            public const string FindLaw = Base + "/laws/find";
            
            public const string GetOne = Base + "/laws/{lawid}";
        }
        public static class RecordProfile
        {
            public const string GetAll = Base + "/record-profiles";
            public const string GetOne = Base + "/record-profiles/{Id}";
            public const string Delete = Base + "/record-profiles/{Id}";
            public const string Approval = Base + "/record-profiles/approval/{Id}";
            public const string Update = Base + "/record-profiles/{Id}";
            public const string RegisterVehicle = Base + "/record-profiles/register-vehicle";
        }
        public static class CitizenShipProfile
        {
            public const string GetAll = "/citizenship-profiles";
            public const string GetOne = "/citizenship-profiles/{Id}";
            public const string Delete = "/citizenship-profiles/{Id}";
            public const string Update = "/citizenship-profiles/{Id}";
            public const string Create = "/citizenship-profiles";

        }
        public static class User
        {
            public const string GetAll = "/Users";
        }
        public static class Vehicle
        {
            public const string GetAll = "/Vehicles";
            public const string GetOne = "/Vehicles/{Id}";
            public const string Create = "/Vehicles";
            public const string Update = "/Vehicles/{Id}";
        }
        public static class MarginalSanctionsTable
        {
            public const string Create = Base+ "/MarginalSanctionsTables";
        }
    }
}
